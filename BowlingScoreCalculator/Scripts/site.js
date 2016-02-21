var ScoreCalculatorModel = function () {
    var self = this;


    self.sendBidRequest = function () {


        var url = '/Home/MakeBid?idSession=' + self.bidSession() + '&bid=' + self.bidingValue();
        $.ajax({
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            url: url,
            //data: 0, //parseFloat(self.currentBid()),
            success: function(data) {
                if (data) {
                    self.currentBidOwner(data.currentBuyer);
                    self.currentBid(data.currentBid);
                }
            },
            error: function(xhr, err) {
                alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
                alert("responseText: " + xhr.responseText);
            }
        });
    };
};