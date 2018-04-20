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
using System.Xml;
using System.Reflection;

namespace ProjectSpecial.View
{
    /// <summary>
    /// Interaction logic for FrmAvalon.xaml
    /// </summary>
    public partial class FrmAvalon : Window
    {
        Assembly _assembly = Assembly.GetExecutingAssembly();
        public FrmAvalon()
        {
            InitializeComponent();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is MenuItem item)
            {
                XmlElement element = item.Header as XmlElement;

                if (element.Attributes["Tag"] != null)
                {
                    MessageBox.Show(element.Attributes["Tag"].Value);
                }
                else
                {
                    return;
                }

            }
            else
            {
                MessageBox.Show("选取的不是MenuItem,请检查后重试！", "错误提示");
            }
        }

        private void tView_Selected(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TreeViewItem item)
            {
                XmlElement element = item.Header as XmlElement;
                if (element.Attributes["Tag"] != null)
                {
                    string tag = element.Attributes["Tag"].Value;
                    Window window = (Window)_assembly.CreateInstance("ProjectSpecial.View." + tag);
                    window.Show();
                }
            }
        }
    }
}
