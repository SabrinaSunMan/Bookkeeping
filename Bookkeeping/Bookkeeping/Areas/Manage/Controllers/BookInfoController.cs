using Bookkeeping.Areas.Manage.Models.ViewModels;
using Bookkeeping.Areas.Manage.Service;
using Bookkeeping.Models;
using PagedList;
using System;
using System.Web.Mvc;

namespace Bookkeeping.Areas.Manage.Controllers
{
    public class BookInfoController : Controller
    {
        private BookInfoService _BookInfoService;

        private readonly int pageSize = 5;

        public BookInfoController()
        {
            _BookInfoService = new BookInfoService();
        }
        // GET: Manage/BookInfo
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Bookkeeping(int page = 1)
        {
            BookkeepingInfoViewModel infoModel = new BookkeepingInfoViewModel();
            int currentPage = page < 1 ? 1 : page;
            infoModel.Content_List = _BookInfoService.GetAllBook_ViewModel(new BookkeepingHeaderViewModel()).ToPagedList(currentPage, pageSize);
            return View(infoModel);
        }

        [HttpPost]
        public ActionResult Bookkeeping(BookkeepingInfoViewModel post_BookkeepingInfoViewModel)
        {

            if (ModelState.IsValid)
            {
                BookInfo book = new BookInfo
                {
                    Id = Guid.NewGuid(),
                    DateTimes = post_BookkeepingInfoViewModel.Header.DateTimes,
                    Money = post_BookkeepingInfoViewModel.Header.Money,
                    Notes = post_BookkeepingInfoViewModel.Header.Notes,
                    Types = post_BookkeepingInfoViewModel.Header.Types
                };

                _BookInfoService.Create(book);
            }
            return RedirectToAction("Bookkeeping");
        }

        //[ChildActionOnly] //避免這個Action被外部連入
        //public ActionResult BookkeepingList()
        //{
        //    //List<BookkeepingMemoListViewModel> bookkeepingList = new List<BookkeepingMemoListViewModel>();
        //    //for (int countDays = 0; countDays < 5; countDays++)
        //    //{
        //    //    bookkeepingList.Add(new BookkeepingMemoListViewModel()
        //    //    {
        //    //        Types = "支出",
        //    //        DateTimes = DateTime.Now.AddDays(-countDays),
        //    //        Money = 10 * Convert.ToInt32(DateTime.Now.Day) * (countDays + 1)
        //    //    });
        //    //} 
        //}
    }
}