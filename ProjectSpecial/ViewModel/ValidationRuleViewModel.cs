using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace ProjectSpecial.ViewModel
{
    public class ValidationRuleViewModel:ViewModelBase
    {
        #region Properties
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value;RaisePropertyChanged(() => UserName); }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(() => Email); }
        }


        #endregion
    }
}
