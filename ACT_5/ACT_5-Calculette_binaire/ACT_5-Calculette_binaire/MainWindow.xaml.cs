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

namespace ACT_5_Calculette_binaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            nbrB1.PreviewTextInput += new TextCompositionEventHandler(VerifTextBinaire);
            nbrB2.PreviewTextInput += new TextCompositionEventHandler(VerifTextBinaire);
            launch.Click += new RoutedEventHandler(Calculer);
        }

        public void VerifTextBinaire(object sender, TextCompositionEventArgs e)
        {
            if (!(EstEntier(e.Text) && (e.Text == "1" || e.Text == "0")))
            {
                e.Handled = true;
            }
            if(((TextBox)sender).Text.Length > 6)
            {
                e.Handled = true;
            }
        }

        public bool EstEntier(string text)
        {
            bool estEntier;

            int entier;

            if(int.TryParse(text, out entier))
            {
                estEntier = true;
            }
            else
            {
                estEntier = false;
            }

            return estEntier;
        }

        public ushort[] RemplirTableau(string nombreBinaire)
        {
            ushort[] tabBin = new ushort[8];

            for (int i = 0; i < tabBin.Length; i++)
            {
                tabBin[i] = 0;
            }

            for (int j = 0; j < nombreBinaire.Length; j++)
            {
                tabBin[7 - j] = ushort.Parse(nombreBinaire[nombreBinaire.Length - 1 - j].ToString());
            }

            return tabBin;
        }

        public void Calculer(object sender, RoutedEventArgs e)
        {
            if(nbrB1.Text != "" && nbrB2.Text != "" && (add.IsChecked = true || sous.IsChecked = true))
            {

            }
            else
            {
                result.Text = "Veuillez remplir tous les chants de texte et sélectionner une option";
            }
        }
    }
}
