using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookkeeping.Filters
{
    public sealed class BanWordAttribute : ValidationAttribute
    {
        public string Input { get; set; }

        public BanWordAttribute(string input)
        {
            this.Input = input;
        }
        public override bool IsValid(object value)
        {
            //權責分清楚，沒有輸入不算錯
            if (value == null)
            {
                return true;
            }

            if (value is string)
            {
                //輸入值是字串才判斷
                if (this.Input.Contains(value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}