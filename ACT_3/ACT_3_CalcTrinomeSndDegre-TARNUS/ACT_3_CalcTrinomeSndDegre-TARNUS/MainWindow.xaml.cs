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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACT_3_CalcTrinomeSndDegre_TARNUS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            a.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            b.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            c.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);

            calculate.MouseEnter += new MouseEventHandler(SurvolButton);
            calculate.MouseLeave += new MouseEventHandler(SurvolButtonFin);
            calculate.Click += new RoutedEventHandler(Calculer)
;
           
        }
        public void VerifTextInput(object sender, TextCompositionEventArgs e)
        {
            if(e.Text !="," && e.Text !="-" && !EstEntier(e.Text))
            {
                e.Handled = true;
            }
            else if(e.Text == ",")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }else if(e.Text == "-")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1)
                {
                    e.Handled = true;
                }
            }
            
        }

        public bool EstEntier(string text)
        {
            bool isInt;
            
            int entier;

            if (int.TryParse(text, out entier))
            {
                isInt = true;
            }
            else
            {
                isInt = false;
            }         
                      
            return isInt;
        }

        public void SurvolButton(object sender, MouseEventArgs e)
        {
            hiddenButton.Visibility = Visibility.Visible;
            hiddenButton.Background = Brushes.Red;           
        }

        public void SurvolButtonFin(object sender, MouseEventArgs e)
        {
            hiddenButton.Visibility = Visibility.Hidden;
            hiddenButton.Background = Brushes.Gray;      
        }

        public void Calculer(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(a.Text, out double aValue) && double.TryParse(b.Text, out double bValue) && double.TryParse(c.Text, out double cValue))
            {
                MethodesDuProjet mesOutils = new MethodesDuProjet();

                string message;
                mesOutils.Resolution(aValue, bValue, cValue, out message);

                Resultat affichage = new Resultat();
                affichage.reponse.Text = message;
                affichage.Show();
            }
          
        }
    }
}
