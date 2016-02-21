using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BowlingScoreCalculator.Models;

namespace BowlingScoreCalculator.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult SubmitScore2(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public JsonResult GetScore(IList<Frame> frames)
        {
            var score = CalculateScore(frames);

            return new JsonResult()
            {
                Data = new { score = score },
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }

        private static int CalculateScore(IList<Frame> frames)
        {
            var score = 0;

            if (frames == null || !frames.Any())
                return score;

            for (var i = 0; i < frames.Count; i++)
            {

                //If it is the last frame
                if (IsLastFrame(frames))
                {
                    score += frames.ElementAt(i).First + frames.ElementAt(i).Second + frames.ElementAt(i).Third;
                    continue;
                }

                //Score Strike
                if (IsStrike(i,frames))
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

        private static bool IsLastFrame(IList<Frame> frames)
        {
            return frames.Count == 10;
        }

        private static bool IsStrike(int frameNumber, IList<Frame> frames)
        {
            return frames.ElementAt(frameNumber).First == 10;
        }

        private static bool IsSpare(int frameNumber, IList<Frame> frames)
        {
            return frames.ElementAt(frameNumber).First + frames.ElementAt(frameNumber).Second == 10;
        }

        private static int ScoreSpare(int frameNumber, IList<Frame> frames)
        {
            //Return 0 and wait for the next turns result to calculate
            if (frameNumber + 1 >= frames.Count)
                return 0;

            return 10 + frames.ElementAt(frameNumber + 1).First;
        }

        private static int ScoreStrike(int frameNumber, IList<Frame> frames)
        {
            //Return 0 and wait for the next turns result to calculate
            if (frameNumber + 1 >= frames.Count)
                return 0;

            return 10 + frames.ElementAt(frameNumber + 1).First + frames.ElementAt(frameNumber + 1).Second;;
        }

        private static int ScoreOpen(Frame frame)
        {
            return frame.First + frame.Second;
        }
    }
}
