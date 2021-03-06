﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookkeeping.Models.Partials
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

            [DisplayName("日期")]
            [Required(ErrorMessage = "請輸入日期")]
            public DateTime DateTimes { get; set; }

            [DisplayName("備註")]
            [StringLength(50)]
            public string Notes { get; set; }
        }
    }
}