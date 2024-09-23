using System;
using System.Windows;
using System.Windows.Controls;

namespace Yanis_Aoukili_Calculator
{
    public partial class MainWindow : Window
    {
        private double number1 = 0;
        private double number2 = 0;
        private string operation = "";
        private bool resultDisplayed = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Méthode déclenchée lorsqu'un bouton numérique est cliqué
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            if (resultDisplayed)
            {
                TB_Display.Clear();
                resultDisplayed = false;
            }

            TB_Display.Text += (sender as Button).Content.ToString();
        }

        // Méthode déclenchée lorsqu'un bouton d'opération est cliqué (+, -, x, /)
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TB_Display.Text, out number1))
            {
                operation = (sender as Button).Content.ToString();
                TB_Display.Clear();
                resultDisplayed = false;
            }
            else
            {
                MessageBox.Show("Entrée invalide !");
            }
        }

        // Méthode pour le bouton Égal
        private void BTN_egal_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TB_Display.Text, out number2))
            {
                double result = 0;

                switch (operation)
                {
                    case "+":
                        result = number1 + number2;
                        break;
                    case "-":
                        result = number1 - number2;
                        break;
                    case "x":
                        result = number1 * number2;
                        break;
                    case "/":
                        if (number2 != 0)
                        {
                            result = number1 / number2;
                        }
                        else
                        {
                            MessageBox.Show("Division par zéro impossible !");
                            TB_Display.Clear();
                            return;
                        }
                        break;
                    default:
                        MessageBox.Show("Opération invalide !");
                        return;
                }

                TB_Display.Text = result.ToString();
                resultDisplayed = true;
            }
            else
            {
                MessageBox.Show("Entrée invalide !");
            }
        }

        // Méthode pour effacer l'afficheur et réinitialiser les variables (CLEAR)
        private void BTN_CLR_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Clear();
            number1 = 0;
            number2 = 0;
            operation = "";
            resultDisplayed = false;
        }

        // Méthode pour gérer la virgule
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (!TB_Display.Text.Contains(","))
            {
                TB_Display.Text += ",";
            }
        }

        // Méthode pour gérer le bouton Pi
        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            TB_Display.Text = Math.PI.ToString();
            resultDisplayed = true;
        }

        // Méthode pour calculer la racine carrée
        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TB_Display.Text, out number1))
            {
                TB_Display.Text = Math.Sqrt(number1).ToString();
                resultDisplayed = true;
            }
            else
            {
                MessageBox.Show("Entrée invalide !");
            }
        }

        // Méthode pour les opérations scientifiques (sin, cos, tan, x²)
        private void ScientificOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TB_Display.Text, out number1))
            {
                string operation = (sender as Button).Content.ToString();
                double result = 0;

                switch (operation)
                {
                    case "sin":
                        result = Math.Sin(number1);
                        break;
                    case "cos":
                        result = Math.Cos(number1);
                        break;
                    case "tan":
                        result = Math.Tan(number1);
                        break;
                    case "x²":
                        result = Math.Pow(number1, 2);
                        break;
                    default:
                        MessageBox.Show("Opération scientifique invalide !");
                        return;
                }

                TB_Display.Text = result.ToString();
                resultDisplayed = true;
            }
            else
            {
                MessageBox.Show("Entrée invalide !");
            }
        }
    }
}
