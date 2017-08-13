using Bookkeeping.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bookkeeping.Controllers
{
    public class HomeController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Bookkeeping()
        {
            return View();
        } 

        [ChildActionOnly] //避免這個Action被外部連入
        public ActionResult BookkeepingList()
        { 
            List<BookkeepingMemoListViewModel> bookkeepingList = new List<BookkeepingMemoListViewModel>();
            for (int countDays = 0; countDays < 5; countDays++)
            {
                bookkeepingList.Add(new BookkeepingMemoListViewModel()
                {
                    Types = "支出",
                    DateTimes = DateTime.Now.AddDays(-countDays),
                    Money = 10 * Convert.ToInt32(DateTime.Now.Day) * (countDays + 1)
                });
            }
            return View(bookkeepingList);
        }
    }
}