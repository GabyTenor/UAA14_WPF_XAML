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

namespace ACT_3bis_Les_Chalets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nbrPersInput.PreviewTextInput += new TextCompositionEventHandler(VerifNombrePersonne);
            beginVisit.PreviewTextInput += new TextCompositionEventHandler(VerifDateEntrees);
            endVisit.PreviewTextInput += new TextCompositionEventHandler(VerifDateEntrees);
            calculeSemaine.Click += new RoutedEventHandler(VerifDonnees);
        }

        public void VerifNombrePersonne(object sender, TextCompositionEventArgs e)
        {
            messageEntier.Text = "";

            int nbrPersonnes;
            if(int.TryParse(e.Text, out nbrPersonnes))
            {                
                /*if(nbrPersonnes < 1 || nbrPersonnes > 6)
                {
                    e.Handled = true;
                    messageEntier.Text = "Vous devez mettre un nombre entre 1 et 6!!";
                }*/
            }
            else
            {
                e.Handled = true;
                messageEntier.Text = "Vous devez mettre un nombre entre 1 et 6!!";
            }
        }

        public void VerifDateEntrees(object sender, TextCompositionEventArgs e)
        {
            int chiffreDate;

            if (!int.TryParse(e.Text, out chiffreDate) && e.Text != "/")
            {
                e.Handled = true;
            }
        }

        public void VerifDonnees(object sender, RoutedEventArgs e)
        {
            DateTime dateA;
            DateTime dateS;

            TimeSpan tempsEcoule = new TimeSpan();

            if (DateTime.TryParse(beginVisit.Text, out dateA) && DateTime.TryParse(beginVisit.Text, out dateS))
            {
                int dateAY = dateA.Year;
                int dateAM = dateA.Month;

                int dateSY = dateS.Year;
                int dateSM = dateS.Month;

                int semaines;

                CalculerNombreSemaines(ref tempsEcoule, dateA, dateS, out semaines);
                affSemaines.Text = (string)semaines;
            }
        }

        public void CalculerNombreSemaines(ref TimeSpan tempsEcoule, DateTime dateA, DateTime dateS, out int semaines)
        {
            tempsEcoule = dateS - dateA;

            semaines = (int)tempsEcoule.TotalDays / 7;
            if(tempsEcoule.TotalDays % 7 != 0)
            {
                semaines++;
            }
        }
    }
}
