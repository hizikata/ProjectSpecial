using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace ProjectSpecial.ValidationClass
{
    public class ValidateModelBase : ViewModelBase, IDataErrorInfo
    {
        #region Properties
        private Dictionary<string, string> _dataErrors = new Dictionary<string, string>();
        public bool IsValidated
        {
            get
            {
                if (_dataErrors != null && _dataErrors.Count > 0)
                    return false;
                else
                {
                    return true;
                }
            }
        }
        #endregion
        #region DictionaryEdit
        private void AddDic(Dictionary<string,string>dic,string key)
        {
            if (!dic.ContainsKey(key))
                dic.Add(key, "");
        }
        private void RemoveDic(Dictionary<string,string>dic,string key)
        {
            dic.Remove(key);
        }
        #endregion
        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                ValidationContext vc = new ValidationContext(this,null,null);
                vc.MemberName = columnName;
                List<ValidationResult> res = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this,null), vc, res);
                if (res.Count > 0)
                {
                    this.AddDic(_dataErrors, vc.MemberName);
                    return string.Join(Environment.NewLine, res.Select(r => r.ErrorMessage).ToArray());
                }
                RemoveDic(_dataErrors, vc.MemberName);
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
        #endregion

    }
}
