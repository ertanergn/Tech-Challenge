var ScoreCalculatorModel = function () {
    var self = this;
    self.firstFrame = ko.observable(0);
    self.secondFrame = ko.observable(0);
    self.bonusFrame = ko.observable(0);
    self.frames = ko.observableArray([]);
    self.isBonusFrameActive = ko.observable(false);
    self.isSecondFrameActive = ko.observable(true);
    self.score = ko.observable(0);
    self.framesPlayed = ko.observable(0);
    self.currentFrame = ko.observable(1);

    self.firstFrame.subscribe(function (value) {

        if (self.currentFrame() == 10 && value == 10)
            self.isBonusFrameActive(true);
        else {
            self.bonusFrame(0);
            self.isBonusFrameActive(true);
        }

        if (self.currentFrame() != 10 && value == 10) {
            self.secondFrame(0);
            self.isSecondFrameActive(false);
        } else
            self.isSecondFrameActive(true);
    });

    self.secondFrame.subscribe(function (value) {

        if (self.currentFrame() == 10 && self.firstFrame() + value == 10)
            self.isBonusFrameActive(true);
    });

    self.submitFrames = function () {

        self.frames.push(
        {
            "First": self.firstFrame(),
            "Second": self.secondFrame(),
            "Third": self.bonusFrame()
        });
        $.ajax({
            type: "POST",
            contentType: "application/json",
            url: '/Home/GetScore',
            data: JSON.stringify(self.frames()),
            success: function(data) {
                if (data) {
                    self.score(data.score);
                    self.firstFrame(0);
                    self.secondFrame(0);
                    self.bonusFrame(0);
                    self.framesPlayed(self.frames().length);
                    self.currentFrame(self.currentFrame() + 1);
                }
            },
            error: function(xhr, err) {
                alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                alert("responseText: " + xhr.responseText);
            }
        });
    };
};