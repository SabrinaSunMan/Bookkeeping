﻿using Bookkeeping.Models;
using Bookkeeping.Models.ViewModels;
using Bookkeeping.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace Bookkeeping.Controllers
{
    public class HomeController : Controller
    {
        private BookInfoService _BookInfoService;

        private readonly int pageSize = 5;

        public HomeController()
        {
            _BookInfoService = new BookInfoService();
        }

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

        [HttpGet]
        public ActionResult Bookkeeping(int page = 1)
        {
            BookkeepingInfoViewModel infoModel = new BookkeepingInfoViewModel(); 
            int currentPage = page < 1 ? 1 : page;

            infoModel.Content_List = _BookInfoService.GetMemoList_ViewModel(new BookkeepingHeaderViewModel(), currentPage, pageSize);
            return View(infoModel);
        }

        [HttpPost]
        public ActionResult Bookkeeping(BookkeepingInfoViewModel post_BookkeepingInfoViewModel)
        {
            int currentPage = post_BookkeepingInfoViewModel.page < 1 ? 1 : post_BookkeepingInfoViewModel.page;
            BookkeepingInfoViewModel infoModel = new BookkeepingInfoViewModel();
            infoModel.Header = post_BookkeepingInfoViewModel.Header;
             
            infoModel.Content_List = _BookInfoService.GetMemoList_ViewModel(infoModel.Header,currentPage, pageSize);
            return View(infoModel);
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