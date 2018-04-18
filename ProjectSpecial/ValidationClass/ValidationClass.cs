using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ProjectSpecial.ValidationClass
{
    public class UserNameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult(false, "用户名不能为空");
            }
            else if ((value.ToString()).Length>8)
            {
                return new ValidationResult(false, "名字长度不能大于8个字符");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
    public class EmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex emialRegx = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "邮箱地址不能为空");
            else if (!emialRegx.IsMatch(value.ToString()))
            {
                return new ValidationResult(false, "邮箱地址格式不正确");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
