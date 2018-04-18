using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GalaSoft.MvvmLight;

namespace ProjectSpecial.ViewModel
{
    public class DataErrorInfoViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(() => UserName); }
        }
        private string _phoneNum;

        public string PhoneNum
        {
            get { return _phoneNum; }
            set { _phoneNum = value; RaisePropertyChanged(() => PhoneNum); }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(() => Email); }
        }



        public string this[string columnName]
        {
            get
            {
                Regex phoneReg = new Regex(@"^[-]?[1-9]{8,11}\d*$|^[0]{1}$");
                Regex emailReg = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
                if (columnName == "UserName" && string.IsNullOrEmpty(this.UserName))
                    return "用户名不能为空";

                if (columnName == "PhoneNum" && string.IsNullOrEmpty(this.PhoneNum))
                    return "电话号码不能为空";
                if (columnName == "PhoneNum" && !string.IsNullOrEmpty(this.PhoneNum))
                {
                    if (!phoneReg.IsMatch(this.PhoneNum))
                        return "电话号码必须为8-11的数字";
                    else
                    {
                        return null;    
                    }
                }

                if (columnName == "Email" && string.IsNullOrEmpty(this.Email))
                    return "邮箱地址不能为空";
                if (columnName == "Email" && !string.IsNullOrEmpty(this.Email))
                {
                    if(!emailReg.IsMatch(this.Email))
                        return "邮箱地址格式不正确";
                    else
                    {
                        return null;
                    }
                }
                    
                else
                    return null;
            }
        }

        public string Error
        {
            get
            {
                return "从Error返回的错误信息";
            }
        }
    }
}
