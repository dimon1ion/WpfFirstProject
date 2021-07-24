using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFirstProject.MyControls
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        private List<CheckBox> rbList;
        private List<SolidColorBrush> brushes;
        private int _ratevalue;

        public int Ratevalue
        {
            get { return _ratevalue; }
            set { _ratevalue = value; }
        }

        public static readonly DependencyProperty RateValueProp = DependencyProperty.Register("Ratevalue", typeof(int), typeof(Rate));

        public Rate()
        {
            InitializeComponent();
            brushes = new List<SolidColorBrush>
            {
                Brushes.Red,
                Brushes.Yellow,
                Brushes.Green
            };
            rbList = new List<CheckBox>
            {
                Rb1,Rb2,Rb3
            };
            BindingOperations.SetBinding(Rb1, RateValueProp, new Binding
            {
                Source = this,
                Path = new PropertyPath(RateValueProp)
            });
        }

        private void Rb1_MouseEnter(object sender, MouseEventArgs e)
        {
            CheckBox selectedRb = sender as CheckBox;
            int selectedIndex = Int32.Parse(selectedRb.Name[selectedRb.Name.Length - 1].ToString());

            for (int i = 0; i < selectedIndex; i++)
            {
                rbList[i].Background = brushes[i];
            }
        }

        private void Rb1_Click(object sender, RoutedEventArgs e)
        {
            CheckBox selectedRb = sender as CheckBox;
            int selectedIndex = Convert.ToInt32(selectedRb.Name[selectedRb.Name.Length - 1].ToString());
            for (int i = 0; i < selectedIndex - 1; i++)
            {
                rbList[i].IsChecked = true;
                rbList[i].Background = brushes[i];
            }
            rbList[selectedIndex - 1].Background = brushes[selectedIndex - 1];
            for (int i = selectedIndex; i < rbList.Count; i++)
            {
                rbList[i].IsChecked = false;
                rbList[i].Background = Brushes.White;
            }
        }

        private void Rb1_MouseLeave(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < rbList.Count; i++)
            {
                if (rbList[i].IsChecked == false)
                {
                    rbList[i].Background = Brushes.White;
                }
            }
        }

        private void Rb1_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Ratevalue; i++)
            {
                rbList[i].IsChecked = true;
                rbList[i].Background = brushes[i];
            }
        }
    }
}
