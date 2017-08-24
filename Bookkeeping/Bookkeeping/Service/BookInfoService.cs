using Bookkeeping.Models;
using Bookkeeping.Models.ViewModels;
using Bookkeeping.Repositories;
using System.Collections.Generic;
using System.Linq;
using Bookkeeping.Enum;

namespace Bookkeeping.Service
{
    public class BookInfoService
    {
        Repository<BookInfo> book_info = new Repository<BookInfo>();

        public IEnumerable<BookkeepingMemoListViewModel> GetAllBook_ViewModel(BookkeepingHeaderViewModel selectModel)
        {
            var result = GetAllBook().Where(s=>(selectModel.Money == 0 ? s.Money == s.Money : s.Money.Equals(selectModel.Money))

                && (!string.IsNullOrEmpty(selectModel.Notes) ? s.Notes.Contains(selectModel.Notes):s.Notes == s.Notes) 
                 
                ).Select(List => new BookkeepingMemoListViewModel()
                {
                    DateTimes = List.DateTimes,
                    Money = List.Money,
                    Types = List.Types == 1 ? BookType.支出.ToString() : BookType.收入.ToString()
                }).ToList();
           
            return result;
        }

        public void Create(BookInfo selectModel)
        {
            book_info.Create(selectModel); 
        }

        /// <summary>
        /// 取得頁面
        /// </summary>
        /// <param name="selectModel"></param>
        /// <param name="currentPage"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        //public IPagedList<BookkeepingMemoListViewModel> GetMemoList_ViewModel(BookkeepingHeaderViewModel selectModel, int currentPage, int PageSize)
        //{
        //    var GetPageList = GetAllBook_ViewModel(selectModel);
        //    return GetPageList.ToPagedList(GetPageList.Count() < PageSize ? 1 : currentPage, PageSize); 
        //}

        private IEnumerable<BookInfo> GetAllBook()
        { 
            return book_info.GetAll().OrderByDescending(s => s.DateTimes); 
        } 
         

    }
}