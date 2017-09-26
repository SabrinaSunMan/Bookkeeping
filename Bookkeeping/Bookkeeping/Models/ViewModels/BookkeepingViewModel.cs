using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PagedList;
using Bookkeeping.Attribute;
using Bookkeeping.Enum;
using System.Web.Mvc;

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
        [Required(ErrorMessage = "{0} 必須為必填")]
        [DisplayName("金額")]
        [RegularExpression(@"^(0|[1-9][0-9]*)$", ErrorMessage = "請輸入正整數")]
        public int Money { get; set; }

        [Required(ErrorMessage = "{0} 必須為必填")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("日期")]
        [BookInfoDateTimeRange(ErrorMessage = "日期不得大於今日")]
        public DateTime DateTimes { get; set; }

        [Required(ErrorMessage = "{0} 必須為必填")]
        [MaxLength(100, ErrorMessage = "{0} 最大不得過 {1} 個字")]
        [Remote("CheckUserName", "Home", ErrorMessage = "不可輸入demoshop")]
        [DisplayName("備註")]
        public string Notes { get; set; }

        [DisplayName("類別")] 
        [Required(ErrorMessage = "請輸入類別")]
        public int Types { get; set; }
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