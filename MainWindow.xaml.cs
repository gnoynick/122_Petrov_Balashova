using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Практическая_работа_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public double Sh(double x)
        {
            return (Math.Exp(x) - Math.Exp(-x)) / 2;
        }

        public string Funk(double x, double b, int i)
        {
            string ans;
            if (i == 1)
            {
                if (x * b > 0.5 && x * b < 10)
                {
                    ans = Convert.ToString(Math.Pow(Math.E, Sh(x) - Math.Abs(b)));
                }
                else if (x * b > 0.1 && x * b < 0.5)
                {
                    ans = Convert.ToString(Math.Sqrt(Math.Abs(Sh(x) + b)));
                }
                else
                {
                    ans = Convert.ToString(2 * Math.Pow(Sh(x), 2));
                }
            }
            else if (i == 2)
            {
                if (x * b > 0.5 && x * b < 10)
                {
                    ans = Convert.ToString(Math.Pow(Math.E, Math.Pow(x, 2) - Math.Abs(b)));
                }
                else if (x * b > 0.1 && x * b < 0.5)
                {
                    ans = Convert.ToString(Math.Sqrt(Math.Abs(Math.Pow(x, 2) + b)));
                }
                else
                {
                    ans = Convert.ToString(2 * Math.Pow(Math.Pow(x, 2), 2));
                }
            }
            else
            {
               if (x * b > 0.5 && x * b < 10)
                {
                    ans = Convert.ToString(Math.Pow(Math.E, Math.Pow(Math.E, x) - Math.Abs(b)));
                }
                else if (x * b > 0.1 && x * b < 0.5)
                {
                    ans = Convert.ToString(Math.Sqrt(Math.Abs(Math.Pow(Math.E, x) + b)));
                }
                else
                {
                    ans = Convert.ToString(2 * Math.Pow(Math.Pow(Math.E, x), 2));
                }

            }
            return ans;
        }

        private void clean_button_Click(object sender, RoutedEventArgs e)
        {
            TextBox_x.Text = "";
            TextBox_b.Text = "";
            TextBox_result.Text = "";
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, 0) && e.Text != ",")
            {
                e.Handled = true;
            }
            if (e.Text == "," && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void calculate_button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_x.Text != "" && TextBox_b.Text != "" && (radioButton1.IsChecked == true || radioButton2.IsChecked == true || radioButton3.IsChecked == true))
            {
                double x = Convert.ToDouble(TextBox_x.Text);
                double b = Convert.ToDouble(TextBox_b.Text);
                if (radioButton1.IsChecked == true)
                {
                    TextBox_result.Text = Funk(x, b, 1);
                }
                else if (radioButton2.IsChecked == true)
                {
                    TextBox_result.Text = Funk(x, b, 2);
                }
                else if (radioButton3.IsChecked == true)
                {
                    TextBox_result.Text = Funk(x, b, 3);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
    }
}
