using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.Filters
{
    public sealed class DateTimeRangeAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            //if (value is string)
            //{
            //    Regex regEx = new Regex(RegExString);
            //    return regEx.IsMatch(value.ToString());
            //}
            return false;
        }
    }
}