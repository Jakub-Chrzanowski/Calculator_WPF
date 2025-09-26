using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        private string? input = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string value = (string)((Button)sender).Content;
            input += value;
            Display.Text = input;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            input = "";
            Display.Text = "0";
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = new DataTable().Compute(input, null);
                Display.Text = result.ToString();
                input = result.ToString(); 
            }
            catch
            {
                Display.Text = "Błąd";
                input = "";
            }
        }
    }
}
