using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ProjectSpecial.ViewModel
{
    public class AvalonViewModel : ViewModelBase
    {
        public RelayCommand<object> TreeViewItemSelectedCommand
        {
            get
            {
                return new RelayCommand<object>((obj) => ExecuteTreeViewItemSelectedCommand(obj));
            }
        }
        public void ExecuteTreeViewItemSelectedCommand(object obj)
        {
            if(obj is TreeViewItem)
            {
                throw new Exception("error");
            }
            else
            {
                throw new Exception("error");
            }
        }
    }
}
