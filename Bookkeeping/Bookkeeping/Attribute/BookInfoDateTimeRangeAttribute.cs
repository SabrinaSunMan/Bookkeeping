using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.Attribute
{
    public class BookInfoDateTimeRangeAttribute : RangeAttribute
    {
        public BookInfoDateTimeRangeAttribute(): base(typeof(DateTime),
            "1911-01-01",DateTime.Now.ToString("yyyy-MM-dd"))
        {  } 
    }
}