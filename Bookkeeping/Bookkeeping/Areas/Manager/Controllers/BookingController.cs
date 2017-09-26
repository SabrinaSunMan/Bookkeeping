using Bookkeeping.Models;
using Bookkeeping.Models.ViewModels;
using Bookkeeping.Service;
using System;
using System.Web.Mvc;
using PagedList;

namespace Bookkeeping.Areas.Manager.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private BookInfoService _BookInfoService;

        public BookingController()
        {
            _BookInfoService = new BookInfoService();
        }

        private readonly int pageSize = 5;

        // GET: Manager/Booking
        [HttpGet, Authorize(Users = "test@test.test,test123@test.test")] //只有這個登入者可以進來
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

        public JsonResult CheckUserName([Bind(Prefix = "Header.Notes")]string Notes)
        {
            bool isValidate = false;
            if (Url.IsLocalUrl(Request.Url.AbsoluteUri))
            {
                //利用 IsLocalUrl檢查是否為網站呼叫的
                //借此忽略一些不必要的流量
                if (Notes != "demoshop")
                {
                    //因連資料庫麻煩
                    //所以假裝示範不可以註冊某一名字
                    isValidate = true;
                }
            }
            // Remote 驗證是使用 Get 因此要開放
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}