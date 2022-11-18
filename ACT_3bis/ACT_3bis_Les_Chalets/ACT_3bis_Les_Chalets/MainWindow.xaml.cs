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
        }

        public void VerifNombrePersonne(object sender, TextCompositionEventArgs e)
        {
            int nbrPersonnes;
            if(int.TryParse(e.Text, out nbrPersonnes))
            {
                if(nbrPersonnes < 1 && nbrPersonnes > 6)
                {
                    e.Handled = true;
                }
                else
                {
                    messageEntier.Text = "Vous devez mettre un nombre entre 1 et 6!!";
                }
            }
            else
            {
                messageEntier.Text = "Vous devez mettre un nombre entre 1 et 6!!";
            }
        }
    }
}
