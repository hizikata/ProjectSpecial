using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ProjectSpecial.ValidationClass;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ProjectSpecial.ViewModel
{
    public class PackedValidateViewModel : ValidateModelBase
    {
        #region Properties
        private string _userName;
        [Required]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(() => UserName); }
        }
        private string _email;
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$", ErrorMessage = "请填写正确的邮箱地址.")]
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(() => Email); }
        }

        private string _phoneNum;
        [Required]
        [RegularExpression(@"^[-]?[1-9]{8,11}\d*$|^[0]{1}$", ErrorMessage = "用户电话必须为8-11位的数值.")]
        public string PhoneNum
        {
            get { return _phoneNum; }
            set { _phoneNum = value; RaisePropertyChanged(() => PhoneNum); }
        }
        #endregion
        #region Commands
        private RelayCommand _submitCommand;

        public RelayCommand SubmitCommand
        {
            get
            {
                if (_submitCommand == null)
                    return new RelayCommand(() => ExecuteSubmitCommand());
                return _submitCommand;
            }
            set { _submitCommand = value; }
        }
        private void ExecuteSubmitCommand()
        {
            if (this.IsValidated)
                System.Windows.MessageBox.Show("验证通过", "系统提示");
            else
                System.Windows.MessageBox.Show("验证失败", "系统提示");
        }


        #endregion
    }
}
