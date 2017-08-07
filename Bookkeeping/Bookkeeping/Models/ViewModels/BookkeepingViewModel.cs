using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.Models.ViewModels
{
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