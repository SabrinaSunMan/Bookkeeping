using Bookkeeping.Models;
using Bookkeeping.Models.ViewModels;
using Bookkeeping.Repositories;
using PagedList;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bookkeeping.Service
{
    public class BookInfoService
    {
        Repository<BookInfo> book_info = new Repository<BookInfo>();
        Repository<BookkeepingMemoListViewModel> bookList_info = new Repository<BookkeepingMemoListViewModel>();

        private IEnumerable<BookkeepingMemoListViewModel> GetAllBook_ViewModel(BookkeepingHeaderViewModel selectModel)
        {
            var result = GetAllBook().Where(s=>(selectModel.Money == 0 ? s.Money == s.Money : s.Money.Equals(selectModel.Money))

                && (!string.IsNullOrEmpty(selectModel.Notes) ? s.Notes.Contains(selectModel.Notes):s.Notes == s.Notes) 
                 
                ).Select(List => new BookkeepingMemoListViewModel()
                {
                    DateTimes = List.DateTimes,
                    Money = List.Money,
                    Types = List.Types == 1 ? "支出" : "收入"
                }).ToList();
           
            return result;
        }

        /// <summary>
        /// 取得頁面
        /// </summary>
        /// <param name="selectModel"></param>
        /// <param name="currentPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public IPagedList<BookkeepingMemoListViewModel> GetMemoList_ViewModel(BookkeepingHeaderViewModel selectModel, int currentPage, int PageSize)
        {
            IEnumerable<BookkeepingMemoListViewModel> GetPageList = GetAllBook_ViewModel(selectModel);
            return bookList_info.ReturnPageList(GetPageList, currentPage, PageSize); 
        }

        private IEnumerable<BookInfo> GetAllBook()
        { 
            return book_info.GetAll().OrderByDescending(s => s.DateTimes); 
        } 
         

    }
}