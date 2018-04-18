using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace ProjectSpecial.ViewModel
{
    public class ValidateExceptionViewModel : ViewModelBase
    {
        private string _userNameEx;

        public string UserNameEx
        {
            get { return _userNameEx; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("用户名不能为空");
                _userNameEx = value;
                RaisePropertyChanged(() => UserNameEx);
            }
        }

    }
}
