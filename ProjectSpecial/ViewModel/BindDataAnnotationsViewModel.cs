using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace ProjectSpecial.ViewModel
{
    [MetadataType(typeof(BindDataAnnotationsViewModel))]
    public class BindDataAnnotationsViewModel : ViewModelBase, IDataErrorInfo
    {

        public BindDataAnnotationsViewModel()
        {

        }
        private Dictionary<string, string> dataErrors = new Dictionary<string, string>();
        private string _userName;
        [Required]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; RaisePropertyChanged(() => UserName); }
        }

        private string _phoneNum;
        [Required]
        [RegularExpression(@"^[-]?[1-9]{8,11}\d*$|^[0]{1}$", ErrorMessage = "用户电话必须为8-11位的数值.")]
        public string PhoneNum
        {
            get { return _phoneNum; }
            set { _phoneNum = value; RaisePropertyChanged(() => PhoneNum); }
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

        #region 命令

        private RelayCommand validFormCommand;
        /// <summary>
        /// 验证表单
        /// </summary>
        public RelayCommand ValidFormCommand
        {
            get
            {
                if (validFormCommand == null)
                    return new RelayCommand(() => ExcuteValidForm());
                return validFormCommand;
            }
            set { validFormCommand = value; }
        }
        /// <summary>
        /// 验证表单
        /// </summary>
        private void ExcuteValidForm()
        {
            if (dataErrors.Count == 0) MessageBox.Show("验证通过！");
            else MessageBox.Show("验证失败！");
        }

        #endregion


        public string this[string columnName]
        {
            get
            {
                ValidationContext vc = new ValidationContext(this, null, null);
                vc.MemberName = columnName;
                var res = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this, null), vc, res);
                if (res.Count > 0)
                {
                    AddDic(dataErrors, vc.MemberName);
                    return string.Join(Environment.NewLine, res.Select(r => r.ErrorMessage).ToArray());
                }
                RemoveDic(dataErrors, vc.MemberName);
                return null;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }


        #region 附属方法

        /// <summary>
        /// 移除字典
        /// </summary>
        /// <param name="dics"></param>
        /// <param name="dicKey"></param>
        private void RemoveDic(Dictionary<String, String> dics, String dicKey)
        {
            dics.Remove(dicKey);
        }

        /// <summary>
        /// 添加字典
        /// </summary>
        /// <param name="dics"></param>
        /// <param name="dicKey"></param>
        private void AddDic(Dictionary<String, String> dics, String dicKey)
        {
            if (!dics.ContainsKey(dicKey))
                dics.Add(dicKey, "");
        }
        #endregion
    }
}
