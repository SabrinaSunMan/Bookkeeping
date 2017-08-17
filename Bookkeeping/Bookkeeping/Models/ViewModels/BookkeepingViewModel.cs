using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PagedList;

namespace Bookkeeping.Models.ViewModels
{
    /// <summary>
    /// 包括 表頭以及 PageList
    /// </summary>
    public class BookkeepingInfoViewModel
    {
        public BookkeepingHeaderViewModel Header { get; set; }

        public IPagedList<BookkeepingMemoListViewModel> Content_List { get; set; }

        public int page { get; set; }
    }

    /// <summary>
    /// 表頭
    /// </summary>
    public class BookkeepingHeaderViewModel
    {
        [DisplayName("金額")]
        public int Money { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("日期")]
        public DateTime DateTimes { get; set; }

        [DisplayName("備註")]
        public string Notes { get; set; }
    }

    /// <summary>
    /// 表內容
    /// </summary>
    public class BookkeepingMemoListViewModel
    {
        [DisplayName("#")]
        public int ItemsCount { get; set; }

        [DisplayName("類別")]
        public string Types { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("日期")]
        public DateTime DateTimes { get; set; }

        [DisplayName("金額")]
        public int Money { get; set; }
         
    }
}