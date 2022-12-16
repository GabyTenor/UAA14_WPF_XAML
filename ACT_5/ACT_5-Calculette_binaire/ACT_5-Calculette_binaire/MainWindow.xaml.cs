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
            if(nbrB1.Text != "" && nbrB2.Text != "" && (add.IsChecked == true || sous.IsChecked == true))
            {
                result.Text = "";
                ushort[] nbr1 = RemplirTableau(nbrB1.Text);
                ushort[] nbr2 = RemplirTableau(nbrB1.Text);
                bool ok;
                ushort[] tRes;
                
                if (add.IsChecked == true)
                {
                    Additionner(nbr1, nbr2, out tRes, out ok);

                    if (!ok)
                    {
                        result.Text = "Le résultat dépasse les 7 bits";
                    }
                    else
                    {
                        for (int i = 0; i < tRes.Length; i++)
                        {
                            result.Text += tRes[i];
                        }
                    }
                }
                if(sous.IsChecked == true)
                {
                    if(!Soustraction(nbr1, nbr2, out tRes))
                    {
                        result.Text = "Le résultat dépasse les 7 bits";
                    }
                    else
                    {
                        for (int i = 0; i < tRes.Length; i++)
                        {
                            result.Text += tRes[i];
                        }
                    }
                }
                
            }
            else
            {
                result.Text = "Veuillez remplir tous les chants de texte et sélectionner une option";
            }
        }

        public void Additionner(ushort[] t1, ushort[] t2, out ushort[] tRes, out bool ok)
        {
            ok = true;
            ushort report = 0;
            ushort res;

            tRes = new ushort[8];

            for (int i = 7; i > -1; i--)
            {
                res = (ushort)(t1[i] + t2[i] + report);

                if(res/2 == 0)
                {
                    report = 0;
                }
                else
                {
                    report = 1;
                }

                if(res == 1)
                {
                    tRes[i] = 1;
                }
                else
                {
                    if(res % 2 == 1)
                    {
                        tRes[i] = 1;
                    }
                    else
                    {
                        tRes[i] = 0;
                    }
                }
                if(report == 1)
                {
                    ok = false;
                }
            }
        }

        public bool Soustraction(ushort[] t1, ushort[] t2, out ushort[] tRes)
        {
            int[] tTemp = new int[8];
            tRes = new ushort[8];

            bool ok = true;

            for (int i = 0; i < 8; i++)
            {
                tTemp[i] = t1[i] - t2[i];
            }

            for(int j = 0; j > -1; j--)
            {
                if(tTemp[j] == -1)
                {
                    t2[j - 1] = (ushort)(t2[j - 1] + 1);
                    t1[j] = (ushort)(t1[j] + 2);
                }

                if(t1[j] < t2[j])
                {
                    t2[j - 1] = (ushort)(t2[j - 1] + 1);
                    t1[j] = (ushort)(t1[j] + 2);
                    tRes[j] = (ushort)(t1[j] - t2[j]);
                }
            }

            if(t1[0] >= t2[0])
            {
                tRes[0] = (ushort)(t1[0] - t2[0]);
            }
            else
            {
                ok = false;
            }

            return ok;
        }
    }
}
