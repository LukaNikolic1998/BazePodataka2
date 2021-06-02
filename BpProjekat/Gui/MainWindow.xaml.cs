using BpProjekat;
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

namespace Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string entitet = "";

        public MainWindow()
        {
            InitializeComponent();
            ReadTable();
        }

        public void ReadTable()
        {
            switch (entitet)
            {
                case "stamparija": RefreshStamparija(); break;
                case "izdavac": RefreshIzdavac(); break;
                case "striparnica": RefreshStriparnica(); break;
                case "kategorija": RefreshKategorija(); break;
                case "nagrada": RefreshNagrada(); break;
                case "festival": RefreshFestival(); break;
                case "scenarista": RefreshAutor(); break;
                case "crtac": RefreshAutor(); break;
                case "strip": RefreshStrip(); break;
                case "izdaje": RefreshIzdaje(); break;
                case "prodaje": RefreshProdaje(); break;
                case "crta": RefreshCrta(); break;
                case "pise": RefreshPise(); break;
                case "ucestvuje": RefreshUcestvuje(); break;
                case "dodeljuje": RefreshDodeljuje(); break;
                default: break;
            }
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (entitet != "")
            {
                Create create = new Create(entitet);
                if (create.ShowDialog() == false)
                {
                    MyGrid.ColumnDefinitions.Clear();
                    MyGrid.RowDefinitions.Clear();
                    MyGrid.Children.Clear();
                    ReadTable();
                }
            }
        }

        public void Update(object sender, RoutedEventArgs e, int id,int id1,int id2)
        {
            if (entitet != "")
            {
                Create create = new Create(entitet, id,id1,id2);
                if (create.ShowDialog() == false)
                {
                    MyGrid.ColumnDefinitions.Clear();
                    MyGrid.RowDefinitions.Clear();
                    MyGrid.Children.Clear();
                    ReadTable();
                }
            }
        }

        public bool Obrisi()
        {
            if(MessageBox.Show("Delete?", "Delete", MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                return true;
            }

            return false;
        }

        #region stamparija
        public void RefreshStamparija()
        {
            List<Stamparija> st = CRUD.Read.ReadStamparija();

            ReadTableStamparija(3, st.Count, st);
        }

        public void ReadTableStamparija(int columns, int rows,List<Stamparija> st)
        {
            for (int x = 0; x < columns+1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows+1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Ime stamparije";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x-1].idsta.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x-1].imesta;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                int id = st[x - 1].idsta;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteStamparija(s, e,id); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 2);
                Grid.SetRow(button, x);
                
                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 3);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteStamparija(object sender, RoutedEventArgs e,int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteStamparija(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }

        private void BtnStamparija_Click(object sender, RoutedEventArgs e)
        {
            entitet = "stamparija";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }
        #endregion

        #region izdavac
        private void BtnIzdavac_Click(object sender, RoutedEventArgs e)
        {
            entitet = "izdavac";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshIzdavac()
        {
            List<Izdavac> st = CRUD.Read.ReadIzdavac();

            ReadTableIzdavac(3, st.Count, st);
        }

        public void ReadTableIzdavac(int columns, int rows, List<Izdavac> st)
        {
            for (int x = 0; x < columns+1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows+1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Ime izdavaca";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x-1].idi.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x-1].imei;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                int id = st[x - 1].idi;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteIzdavac(s, e, id); }; 
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 2);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 3);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteIzdavac(object sender, RoutedEventArgs e, int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteIzdavac(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region striparnica
        private void BtnStriparnica_Click(object sender, RoutedEventArgs e)
        {
            entitet = "striparnica";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshStriparnica()
        {
            List<Striparnica> st = CRUD.Read.ReadStriparnica();

            ReadTableStriparnica(3, st.Count, st);
        }

        public void ReadTableStriparnica(int columns, int rows, List<Striparnica> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Ime striparnice";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].ids.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x - 1].imes;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                int id = st[x - 1].ids;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteStriparnica(s, e, id); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 2);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 3);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteStriparnica(object sender, RoutedEventArgs e, int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteStriparnica(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region kategorija
        private void BtnKategorija_Click(object sender, RoutedEventArgs e)
        {
            entitet = "kategorija";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshKategorija()
        {
            List<Kategorija> st = CRUD.Read.ReadKategorija();

            ReadTableKategorija(3, st.Count, st);
        }

        public void ReadTableKategorija(int columns, int rows, List<Kategorija> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Kategorija";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].idk.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x - 1].imek;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                int id = st[x - 1].idk;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteKategorija(s, e, id); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 2);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 3);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteKategorija(object sender, RoutedEventArgs e, int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteKategorija(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region nagrada
        private void BtnNagrada_Click(object sender, RoutedEventArgs e)
        {
            entitet = "nagrada";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshNagrada()
        {
            List<Nagrada> st = CRUD.Read.ReadNagrada();

            ReadTableNagrada(3, st.Count, st);
        }

        public void ReadTableNagrada(int columns, int rows, List<Nagrada> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Nagrada";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].idn.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x - 1].imen;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                int id = st[x - 1].idn;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteNagrada(s, e, id); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 2);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 3);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteNagrada(object sender, RoutedEventArgs e, int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteNagrada(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region festival
        private void BtnFestival_Click(object sender, RoutedEventArgs e)
        {
            entitet = "festival";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshFestival()
        {
            List<Festival> st = CRUD.Read.ReadFestival();

            ReadTableFestival(4, st.Count, st);
        }

        public void ReadTableFestival(int columns, int rows, List<Festival> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Festival";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "Godina odrzavanja";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            Label l5 = new Label();
            l5.Content = "";
            l5.BorderThickness = new Thickness(0, 0, 0, 1);
            l5.BorderBrush = Brushes.Black;
            Grid.SetColumn(l5, 4);
            Grid.SetRow(l5, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);
            MyGrid.Children.Add(l5);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].idf.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x - 1].imef;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Label label3 = new Label();
                label3.Content = st[x - 1].gododr;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                int id = st[x - 1].idf;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteFestival(s, e, id); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 4);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteFestival(object sender, RoutedEventArgs e, int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteFestival(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region autor
        private void BtnScenarista_Click(object sender, RoutedEventArgs e)
        {
            entitet = "scenarista";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        private void BtnCrtac_Click(object sender, RoutedEventArgs e)
        {
            entitet = "crtac";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshAutor()
        {
            List<Autor> st = CRUD.Read.ReadAutor(entitet);
            ReadTableAutor(4, st.Count, st);
        }

        public void ReadTableAutor(int columns, int rows, List<Autor> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 0);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Ime";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 1);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "Prezime";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            Label l5 = new Label();
            l5.Content = "";
            l5.BorderThickness = new Thickness(0, 0, 0, 1);
            l5.BorderBrush = Brushes.Black;
            Grid.SetColumn(l5, 4);
            Grid.SetRow(l5, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);
            MyGrid.Children.Add(l5);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].ida.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x - 1].imea;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Label label3 = new Label();
                label3.Content = st[x - 1].prza;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                int id = st[x - 1].ida;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteAutor(s, e, id); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 4);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteAutor(object sender, RoutedEventArgs e, int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteAutor(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region strip
        private void BtnStrip_Click(object sender, RoutedEventArgs e)
        {
            entitet = "strip";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshStrip()
        {
            List<Strip> st = CRUD.Read.ReadStrip();

            ReadTableStrip(3, st.Count, st);
        }

        public void ReadTableStrip(int columns, int rows, List<Strip> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l1 = new Label();
            l1.Content = "Id";
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
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 2);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 3);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].idstr.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = st[x - 1].imestr;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                int id = st[x - 1].idstr;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteStrip(s, e, id); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 2);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, id,-1,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 3);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteStrip(object sender, RoutedEventArgs e, int id)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteStrip(id);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region izdaje
        private void BtnIzdaje_Click(object sender, RoutedEventArgs e)
        {
            entitet = "izdaje";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshIzdaje()
        {
            List<Izdaje> st = CRUD.Read.ReadIzdaje();

            ReadTableIzdaje(4, st.Count, st);
        }

        public void ReadTableIzdaje(int columns, int rows, List<Izdaje> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l = new Label();
            l.Content = "Id";
            l.BorderThickness = new Thickness(0, 0, 0, 1);
            l.BorderBrush = Brushes.Black;
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);

            Label l1 = new Label();
            l1.Content = "Strip";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 1);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Izdavac";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 2);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 3);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 4);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l);
            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].Strip_idstr3.ToString()+"+"+st[x-1].Izdavac_idi.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = CRUD.GetRow.GetRowStrip(st[x - 1].Strip_idstr3).imestr;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Label label3 = new Label();
                label3.Content = CRUD.GetRow.GetRowIzdavac(st[x - 1].Izdavac_idi).imei;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                int idi = st[x - 1].Izdavac_idi;
                int idstr = st[x - 1].Strip_idstr3;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteIzdaje(s, e, idi,idstr); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, idi,idstr,-1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 4);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteIzdaje(object sender, RoutedEventArgs e, int idi,int idstr)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteIzdaje(idi, idstr);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region prodaje
        private void BtnProdaje_Click(object sender, RoutedEventArgs e)
        {
            entitet = "prodaje";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshProdaje()
        {
            List<Prodaje> st = CRUD.Read.ReadProdaje();

            ReadTableProdaje(4, st.Count, st);
        }

        public void ReadTableProdaje(int columns, int rows, List<Prodaje> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l = new Label();
            l.Content = "Id";
            l.BorderThickness = new Thickness(0, 0, 0, 1);
            l.BorderBrush = Brushes.Black;
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);

            Label l1 = new Label();
            l1.Content = "Strip";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 1);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Striparnica";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 2);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 3);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 4);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l);
            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].Strip_idstr4.ToString() + "+" + st[x - 1].Striparnica_ids.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = CRUD.GetRow.GetRowStrip(st[x - 1].Strip_idstr4).imestr;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Label label3 = new Label();
                label3.Content = CRUD.GetRow.GetRowStriparnica(st[x - 1].Striparnica_ids).imes;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                int ids = st[x - 1].Striparnica_ids;
                int idstr = st[x - 1].Strip_idstr4;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteProdaje(s, e, ids, idstr); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, ids, idstr, -1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 4);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteProdaje(object sender, RoutedEventArgs e, int ids, int idstr)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteProdaje(ids, idstr);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region crta
        private void BtnCrta_Click(object sender, RoutedEventArgs e)
        {
            entitet = "crta";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshCrta()
        {
            List<Crta> st = CRUD.Read.ReadCrta();

            ReadTableCrta(4, st.Count, st);
        }

        public void ReadTableCrta(int columns, int rows, List<Crta> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l = new Label();
            l.Content = "Id";
            l.BorderThickness = new Thickness(0, 0, 0, 1);
            l.BorderBrush = Brushes.Black;
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);

            Label l1 = new Label();
            l1.Content = "Strip";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 1);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Crtac";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 2);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 3);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 4);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l);
            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].Strip_idstr2.ToString() + "+" + st[x - 1].Crtac_ida.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = CRUD.GetRow.GetRowStrip(st[x - 1].Strip_idstr2).imestr;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Autor autor = CRUD.GetRow.GetRowAutor(st[x - 1].Crtac_ida);
                Label label3 = new Label();
                label3.Content = autor.imea + " "+autor.prza;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                int ida = st[x - 1].Crtac_ida;
                int idstr = st[x - 1].Strip_idstr2;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteCrta(s, e, ida, idstr); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, ida, idstr, -1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 4);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteCrta(object sender, RoutedEventArgs e, int ida, int idstr)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteCrta(ida, idstr);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region pise
        private void BtnPise_Click(object sender, RoutedEventArgs e)
        {
            entitet = "pise";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshPise()
        {
            List<Pise> st = CRUD.Read.ReadPise();

            ReadTablePise(4, st.Count, st);
        }

        public void ReadTablePise(int columns, int rows, List<Pise> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l = new Label();
            l.Content = "Id";
            l.BorderThickness = new Thickness(0, 0, 0, 1);
            l.BorderBrush = Brushes.Black;
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);

            Label l1 = new Label();
            l1.Content = "Strip";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 1);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Scenarista";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 2);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 3);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 4);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l);
            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].Strip_idstr1.ToString() + "+" + st[x - 1].Scenarista_ida.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = CRUD.GetRow.GetRowStrip(st[x - 1].Strip_idstr1).imestr;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Autor autor = CRUD.GetRow.GetRowAutor(st[x - 1].Scenarista_ida);
                Label label3 = new Label();
                label3.Content = autor.imea + " " + autor.prza;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                int ida = st[x - 1].Scenarista_ida;
                int idstr = st[x - 1].Strip_idstr1;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeletePise(s, e, ida, idstr); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, ida, idstr, -1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 4);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeletePise(object sender, RoutedEventArgs e, int ida, int idstr)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeletePise(ida, idstr);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region ucestvuje
        private void BtnUcestvuje_Click(object sender, RoutedEventArgs e)
        {
            entitet = "ucestvuje";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshUcestvuje()
        {
            List<Ucestvuje> st = CRUD.Read.ReadUcestvuje();

            ReadTableUcestvuje(4, st.Count, st);
        }

        public void ReadTableUcestvuje(int columns, int rows, List<Ucestvuje> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l = new Label();
            l.Content = "Id";
            l.BorderThickness = new Thickness(0, 0, 0, 1);
            l.BorderBrush = Brushes.Black;
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);

            Label l1 = new Label();
            l1.Content = "Strip";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 1);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Festival";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 2);
            Grid.SetRow(l2, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 3);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 4);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l);
            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].Strip_idstr5.ToString() + "+" + st[x - 1].Festival_idf.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = CRUD.GetRow.GetRowStrip(st[x - 1].Strip_idstr5).imestr;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Festival festival = CRUD.GetRow.GetRowFestival(st[x - 1].Festival_idf);
                Label label3 = new Label();
                label3.Content = festival.imef + " " + festival.gododr;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);

                int ida = st[x - 1].Festival_idf;
                int idstr = st[x - 1].Strip_idstr5;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteUcestvuje(s, e, ida, idstr); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 3);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, ida, idstr, -1); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 4);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteUcestvuje(object sender, RoutedEventArgs e, int idf, int idstr)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteUcestvuje(idf, idstr);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region dodeljuje
        private void BtnDodeljuje_Click(object sender, RoutedEventArgs e)
        {
            entitet = "dodeljuje";
            MyGrid.ColumnDefinitions.Clear();
            MyGrid.RowDefinitions.Clear();
            MyGrid.Children.Clear();
            ReadTable();
        }

        public void RefreshDodeljuje()
        {
            List<Dodeljuje> st = CRUD.Read.ReadDodeljuje();

            ReadTableDodeljuje(5, st.Count, st);
        }

        public void ReadTableDodeljuje(int columns, int rows, List<Dodeljuje> st)
        {
            for (int x = 0; x < columns + 1; x++)
                MyGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int y = 0; y < rows + 1; y++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                MyGrid.RowDefinitions.Add(r);
            }

            Label l = new Label();
            l.Content = "Id";
            l.BorderThickness = new Thickness(0, 0, 0, 1);
            l.BorderBrush = Brushes.Black;
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);

            Label l1 = new Label();
            l1.Content = "Strip";
            l1.BorderThickness = new Thickness(0, 0, 0, 1);
            l1.BorderBrush = Brushes.Black;
            Grid.SetColumn(l1, 1);
            Grid.SetRow(l1, 0);

            Label l2 = new Label();
            l2.Content = "Festival";
            l2.BorderThickness = new Thickness(0, 0, 0, 1);
            l2.BorderBrush = Brushes.Black;
            Grid.SetColumn(l2, 2);
            Grid.SetRow(l2, 0);

            Label l5 = new Label();
            l5.Content = "Nagrada";
            l5.BorderThickness = new Thickness(0, 0, 0, 1);
            l5.BorderBrush = Brushes.Black;
            Grid.SetColumn(l5, 3);
            Grid.SetRow(l5, 0);

            Label l3 = new Label();
            l3.Content = "";
            l3.BorderThickness = new Thickness(0, 0, 0, 1);
            l3.BorderBrush = Brushes.Black;
            Grid.SetColumn(l3, 4);
            Grid.SetRow(l3, 0);

            Label l4 = new Label();
            l4.Content = "";
            l4.BorderThickness = new Thickness(0, 0, 0, 1);
            l4.BorderBrush = Brushes.Black;
            Grid.SetColumn(l4, 5);
            Grid.SetRow(l4, 0);

            MyGrid.Children.Add(l);
            MyGrid.Children.Add(l1);
            MyGrid.Children.Add(l2);
            MyGrid.Children.Add(l3);
            MyGrid.Children.Add(l4);
            MyGrid.Children.Add(l5);

            for (int x = 1; x <= rows; x++)
            {
                Label label1 = new Label();
                label1.Content = st[x - 1].Festival_idf.ToString() + "+" + st[x - 1].Nagrada_idn.ToString();
                Grid.SetColumn(label1, 0);
                Grid.SetRow(label1, x);

                Label label2 = new Label();
                label2.Content = CRUD.GetRow.GetRowStrip(st[x - 1].UcestvujeStrip_idstr).imestr;
                Grid.SetColumn(label2, 1);
                Grid.SetRow(label2, x);

                Festival festival = CRUD.GetRow.GetRowFestival(st[x - 1].Festival_idf);
                Label label3 = new Label();
                label3.Content = festival.imef + " " + festival.gododr;
                Grid.SetColumn(label3, 2);
                Grid.SetRow(label3, x);
                
                Label label4 = new Label();
                label4.Content = CRUD.GetRow.GetRowNagrada(st[x - 1].Nagrada_idn).imen;
                Grid.SetColumn(label4, 3);
                Grid.SetRow(label4, x);

                int idf = st[x - 1].Festival_idf;
                int idn = st[x - 1].Nagrada_idn;
                int idstr = st[x - 1].UcestvujeStrip_idstr;
                Button button = new Button();
                button.Content = "Delete";
                button.Click += (s, e) => { DeleteDodeljuje(s, e, idn, idf); };
                button.Height = 20;
                button.Width = 75;
                Grid.SetColumn(button, 4);
                Grid.SetRow(button, x);

                Button button1 = new Button();
                button1.Content = "Update";
                button1.Click += (s, e) => { Update(s, e, idn, idf,idstr); };
                button1.Height = 20;
                button1.Width = 75;
                Grid.SetColumn(button1, 5);
                Grid.SetRow(button1, x);

                MyGrid.Children.Add(label1);
                MyGrid.Children.Add(label2);
                MyGrid.Children.Add(label3);
                MyGrid.Children.Add(label4);
                MyGrid.Children.Add(button);
                MyGrid.Children.Add(button1);
            }
        }

        public void DeleteDodeljuje(object sender, RoutedEventArgs e, int idn, int idf)
        {
            if (Obrisi())
            {
                CRUD.Delete.DeleteDodeljuje(idn, idf);
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region procedure
        private void BtnProceduraF_Click(object sender, RoutedEventArgs e)
        {
            InsertFestival insertFestival = new InsertFestival();
            if (insertFestival.ShowDialog() == false) {
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }

        private void BtnProceduraSE_Click(object sender, RoutedEventArgs e)
        {
            SelectIme selectIme = new SelectIme();
            if(selectIme.ShowDialog() == false)
            {
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion

        #region funkcije
        private void BtnFunkcijaSK_Click(object sender, RoutedEventArgs e)
        {
            StripKategorija stripKategorija = new StripKategorija();
            if (stripKategorija.ShowDialog() == false)
            {
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }

        private void BtnFunkcijaBS_Click(object sender, RoutedEventArgs e)
        {
            labelBrojS.Content = CRUD.Funkcije.F_GET_BrojStripova();
        }

        private void BtnTriTabele_Click(object sender, RoutedEventArgs e)
        {
            TriTabele triTabele = new TriTabele();
            if (triTabele.ShowDialog() == false)
            {
                MyGrid.ColumnDefinitions.Clear();
                MyGrid.RowDefinitions.Clear();
                MyGrid.Children.Clear();
                ReadTable();
            }
        }
        #endregion
    }
}
