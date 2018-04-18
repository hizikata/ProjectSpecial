using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace ProjectSpecial
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Window
    {
        private Assembly _assembly = Assembly.GetExecutingAssembly();
        public Index()
        {
            InitializeComponent();
           
        }

        private void WrapPanel_Click(object sender, RoutedEventArgs e)
        {
            //根据点击button的Tag打开对应窗口 
            //窗口文件必须放在路径：/ProjectSpecial/View 下
            if(e.OriginalSource is Button button)
            {
                if(button.Tag!=null)
                {
                    string windowTag = button.Tag.ToString();
                    Window window = (Window)_assembly.CreateInstance("ProjectSpecial.View." + windowTag);
                    if (window is null)
                    {
                        MessageBox.Show(string.Format("不存在该Tag标签的窗口 Tag:{0}", button.Tag), "系统提示");
                        return;
                    }                                         
                    window.Owner = this;
                    window.Show();
                }
                else
                {
                    MessageBox.Show("无Tag标签，请设置后重试");
                }
            }
            else
            {
                throw new Exception("请点击Button");
            }

            
            
        }
    }
}
