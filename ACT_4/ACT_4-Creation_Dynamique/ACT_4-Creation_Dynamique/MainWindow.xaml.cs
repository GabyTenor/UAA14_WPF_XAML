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

namespace ACT_4_Creation_Dynamique
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeInterface();
        }
        public void InitializeInterface()
        {
            InitializeGrid();
            InitializeRow1();
            InitializeRow2();
            InitializeRow3();
        }

        public void InitializeGrid()
        {
            ColumnDefinition colDef0 = new ColumnDefinition();
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            grdMain.ColumnDefinitions.Add(colDef0);
            grdMain.ColumnDefinitions.Add(colDef1);
            grdMain.ColumnDefinitions.Add(colDef2);

            RowDefinition rowDef0 = new RowDefinition();
            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            grdMain.RowDefinitions.Add(rowDef0);
            grdMain.RowDefinitions.Add(rowDef1);
            grdMain.RowDefinitions.Add(rowDef2);
        }
        
        public void InitializeRow1()
        {
            TextBlock txtBck1 = new TextBlock();
            txtBck1.Background = Brushes.Black;
            txtBck1.Text = "Enfin on va faire le plateau d'échec";
            txtBck1.FontSize = 20;
            txtBck1.FontFamily = new FontFamily("Times New Roman");
            txtBck1.Foreground = Brushes.Yellow;

            Grid.SetColumnSpan(txtBck1, 3);
            Grid.SetRow(txtBck1, 0);

            grdMain.Children.Add(txtBck1);
        }
        
        public void InitializeRow2()
        {
            Button btn1 = new Button();
            Button btn2 = new Button();
            Button btn3 = new Button();

            btn1.Content = "Bouton 1";
            btn2.Content = "Bouton 2";
            btn3.Content = "Bouton 3";

            Grid.SetColumn(btn1, 0);
            Grid.SetRow(btn1, 1);

            Grid.SetColumn(btn2, 1);
            Grid.SetRow(btn2, 1);

            Grid.SetColumn(btn3, 2);
            Grid.SetRow(btn3, 1);

            grdMain.Children.Add(btn1);
            grdMain.Children.Add(btn2);
            grdMain.Children.Add(btn3);
        }

        public void InitializeRow3()
        {
            TextBlock txtBck2 = new TextBlock();
            txtBck2.Text = "J'écoute actuellement de la musique de Minecraft, très relaxant";

            TextBox txtBox1 = new TextBox();
            txtBox1.Background = Brushes.Black;

            StackPanel stkPnl1 = new StackPanel();
            stkPnl1.Children.Add(txtBck2);
            stkPnl1.Children.Add(txtBox1);

            Grid.SetColumn(stkPnl1, 0);
            Grid.SetColumnSpan(stkPnl1, 2);
            Grid.SetRow(stkPnl1, 2);

            grdMain.Children.Add(stkPnl1);


           
            ComboBox box = new ComboBox();
            box.Items.Add("Échecs");
            box.Items.Add("Et mat");

            Grid.SetColumn(box, 2);
            Grid.SetRow(box, 2);

            grdMain.Children.Add(box);
        }
    }
}
