using System.Collections.Generic;
using System.Linq;

namespace ScoreCalculator
{
    public class ScoreCalculator
    {
        public static int CalculateScore(IList<Frame> frames)
        {
            var score = 0;

            if (frames == null || !frames.Any())
                return score;

            for (var i = 0; i < frames.Count; i++)
            {

                //Last frame
                if (IsLastFrame(i,frames))
                {
                    score += frames.ElementAt(i).First + frames.ElementAt(i).Second + frames.ElementAt(i).Third;
                    continue;
                }

                //Score Strike
                if (IsStrike(i, frames))
                {
                    score += ScoreStrike(i, frames);
                    continue;
                }

                //Score Spare
                if (IsSpare(i, frames))
                {
                    score += ScoreSpare(i, frames);
                    continue;
                }

                //Score Open
                score += ScoreOpen(frames.ElementAt(i));

            }

            return score;
        }

        /// <summary>
        /// Checks if it is the last frame played
        /// </summary>
        private static bool IsLastFrame(int frameNumber, IList<Frame> frames)
        {
            return frames.Count == 10 && frameNumber + 1 == frames.Count;
        }

        /// <summary>
        /// Checks if the current frame is a strike
        /// </summary>
        private static bool IsStrike(int frameNumber, IList<Frame> frames)
        {
            return frames.ElementAt(frameNumber).First == 10;
        }

        /// <summary>
        /// Checks if the current frame is a spare
        /// </summary>
        private static bool IsSpare(int frameNumber, IList<Frame> frames)
        {
            return frames.ElementAt(frameNumber).First + frames.ElementAt(frameNumber).Second == 10;
        }

        /// <summary>
        /// For a strike, the score is 10 + the sum of the two rolls in the following frame. 
        /// The bowler who rolls three strikes in a row in the first three frames gets credit for 30 points 
        /// in the first frame rule is not applied.
        /// </summary>
        private static int ScoreStrike(int frameNumber, IList<Frame> frames)
        {
            //Return 0 and wait for the next turns result to calculate
            if (frameNumber + 1 >= frames.Count)
                return 0;

            return 10 + frames.ElementAt(frameNumber + 1).First + frames.ElementAt(frameNumber + 1).Second; ;
        }

        /// <summary>
        /// For a spare, the score is 10 + the number of pins knocked down in the first roll of the following frame.
        /// </summary>
        private static int ScoreSpare(int frameNumber, IList<Frame> frames)
        {
            //Return 0 and wait for the next turns result to calculate
            if (frameNumber + 1 >= frames.Count)
                return 0;

            return 10 + frames.ElementAt(frameNumber + 1).First;
        }

        /// <summary>
        /// For an open frame the score is the total number of pins knocked down. 
        /// </summary>
        private static int ScoreOpen(Frame frame)
        {
            return frame.First + frame.Second;
        }
    }
}
