using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using ScoreCalculator;

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

        [HttpPost]
        public JsonResult GetScore(IList<Frame> frames)
        {
            var score = ScoreCalculator.ScoreCalculator.CalculateScore(frames);

            return new JsonResult()
            {
                Data = new { score = score },
                ContentEncoding = Encoding.UTF8,
                JsonRequestBehavior = JsonRequestBehavior.DenyGet
            };
        }
    }
}
