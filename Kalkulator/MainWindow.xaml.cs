using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        private string input = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string value = (string)((Button)sender).Content;
            input += value switch
            {
                "÷" => "/",
                "×" => "*",
                "," => ".",
                _ => value
            };
            Display.Text = input;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            input = "";
            Display.Text = "0";
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(input))
            {
                input = input.Substring(0, input.Length - 1);
                Display.Text = string.IsNullOrEmpty(input) ? "0" : input;
            }
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

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out double val))
            {
                val = -val;
                input = val.ToString();
                Display.Text = input;
            }
        }

        private void Special_Click(object sender, RoutedEventArgs e)
        {
            string op = (string)((Button)sender).Content;

            try
            {
                double x = double.Parse(Display.Text);
                double result = x;

                switch (op)
                {
                    case "π": result = Math.PI; break;
                    case "e": result = Math.E; break;
                    case "x²": result = Math.Pow(x, 2); break;
                    case "√x": result = Math.Sqrt(x); break;
                    case "1/x": result = 1 / x; break;
                    case "|x|": result = Math.Abs(x); break;
                    case "exp": result = Math.Exp(x); break;
                    case "n!": result = Factorial((int)x); break;
                    case "10ˣ": result = Math.Pow(10, x); break;
                    case "log": result = Math.Log10(x); break;
                    case "ln": result = Math.Log(x); break;
                }

                Display.Text = result.ToString();
                input = result.ToString();
            }
            catch
            {
                Display.Text = "Błąd";
                input = "";
            }
        }

        private double Factorial(int n)
        {
            if (n < 0) throw new ArgumentException("n<0");
            double res = 1;
            for (int i = 1; i <= n; i++) res *= i;
            return res;
        }
    }
}
