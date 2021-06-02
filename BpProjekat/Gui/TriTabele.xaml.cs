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
using System.Windows.Shapes;

namespace Gui
{
    /// <summary>
    /// Interaction logic for TriTabele.xaml
    /// </summary>
    public partial class TriTabele : Window
    {
        public TriTabele()
        {
            InitializeComponent();
            Read();
        }

        public void Read()
        {
            List<Tuple<string,string,string>> stripovi = CRUD.Funkcije.F_GET_TriTabele();
            for (int x = 0; x < 3; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < stripovi.Count+1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Kategorija";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Strip";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "Stamparija";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);

            for (int x = 1; x <= stripovi.Count; x++)
            {
                Label label1 = new Label();
                label1.Content = stripovi[x-1].Item1;
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = stripovi[x-1].Item2;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Label label3 = new Label();
                label3.Content = stripovi[x-1].Item3;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
            }
        }
    }
}
