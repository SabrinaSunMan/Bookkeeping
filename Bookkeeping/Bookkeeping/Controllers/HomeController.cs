using Bookkeeping.Areas.Manage.Models.ViewModels;
using Bookkeeping.Areas.Manage.Service;
using PagedList;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bookkeeping.Controllers
{
    public class HomeController : Controller
    { 
        public class TEST
        {
            public string Name { get; set; }
            public SelectList test { get; set; }
        }

        public ActionResult Index()
        {
            TEST t = new TEST();
            t.test = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Homeowner", Value = "value1"},
                    new SelectListItem { Text = "Contractor", Value = "value2"}
                }, "Value", "Text"
            ); 

            return View(t);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Users = "test@test.test,test123@test.test")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private BookInfoService _BookInfoService = new BookInfoService();

        private readonly int pageSize = 5;

        [HttpGet]
        public ActionResult Bookkeeping(int page = 1)
        {
            BookkeepingInfoViewModel infoModel = new BookkeepingInfoViewModel();
            int currentPage = page < 1 ? 1 : page;
            infoModel.Content_List = _BookInfoService.GetAllBook_ViewModel(new BookkeepingHeaderViewModel()).ToPagedList(currentPage, pageSize);
            return View(infoModel);
        }

    }
}