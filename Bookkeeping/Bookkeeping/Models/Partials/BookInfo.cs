using Bookkeeping.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookkeeping.Models
{
    /// <summary>
    /// 記帳本
    /// </summary>
    [MetadataType(typeof(BookInfo_MetaData))]
    public partial class BookInfo
    {
        public class BookInfo_MetaData
        { 
            [DisplayName("序號")]
            [Required(ErrorMessage ="請輸入序號")]
            public Guid Id { get; set; }
                
            [DisplayName("類別")]
            [Required(ErrorMessage = "請輸入類別")]
            public int Types { get;set;}

            [DisplayName("金額")]
            [Required(ErrorMessage = "請輸入金額")]
            public int Money { get; set; }

            [UIHint("DateTime")]
            [DisplayName("日期")]
            [Required(ErrorMessage = "請輸入日期")]
            public DateTime DateTimes { get; set; }

            [DisplayName("備註")]
            [Remote("CheckUserName", "Validate", ErrorMessage = "遠端驗證失敗")]
            [StringLength(50)]
            public string Notes { get; set; }
        }
    }
}