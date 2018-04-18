using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;


namespace ProjectSpecial.ViewModel
{
    public class DataValidateViewModel : ViewModelBase
    {
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("用户名不能为空");
                _userName = value;
            }
        }

    }
}
