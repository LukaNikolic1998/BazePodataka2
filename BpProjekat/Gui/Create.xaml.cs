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
using System.Windows.Shapes;

namespace Gui
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : Window
    {
        public Create()
        {
            InitializeComponent();
        }

        bool update = false;
        int Id;
        string entitet = "";
        int stari_idi, stari_idstr, stari_idn;
        public Create(string str)
        {
            entitet = str;
            InitializeComponent();
            switch (str)
            {
                case "stamparija": CreateStamparija(); break;
                case "izdavac": CreateIzdavac(); break;
                case "striparnica": CreateStriparnica(); break;
                case "kategorija": CreateKategorija(); break;
                case "nagrada": CreateNagrada(); break;
                case "festival": CreateFestival(); break;
                case "scenarista": CreateAutor(); break;
                case "crtac": CreateAutor(); break;
                case "strip": CreateStrip(); break;
                case "izdaje": CreateIzdaje(); break;
                case "prodaje": CreateProdaje(); break;
                case "crta": CreateCrta(); break;
                case "pise": CreatePise(); break;
                case "ucestvuje": CreateUcestvuje(); break;
                case "dodeljuje": CreateDodeljuje(); break;
                default: break;
            }
        }

        public Create(string str,int id,int id1,int id2)
        {
            stari_idi = id;
            stari_idstr = id1;
            stari_idn = id;
            update = true;
            Id = id;
            entitet = str;
            InitializeComponent();
            switch (str)
            {
                case "stamparija": CreateStamparija(); UpdateStamparija(id); break;
                case "izdavac": CreateIzdavac(); UpdateIzdavac(id); break;
                case "striparnica": CreateStriparnica(); UpdateStriparnica(id); break;
                case "kategorija": CreateKategorija(); UpdateKategorija(id); break;
                case "nagrada": CreateNagrada(); UpdateNagrada(id); break;
                case "festival": CreateFestival(); UpdateFestival(id); break;
                case "scenarista": CreateAutor(); UpdateAutor(id); break;
                case "crtac": CreateAutor(); UpdateAutor(id); break;
                case "strip": CreateStrip(); UpdateStrip(id); break;
                case "izdaje": CreateIzdaje(); UpdateIzdaje(id,id1); break;
                case "prodaje": CreateProdaje(); UpdateProdaje(id,id1); break;
                case "crta": CreateCrta(); UpdateCrta(id,id1); break;
                case "pise": CreatePise(); UpdatePise(id,id1); break;
                case "ucestvuje": CreateUcestvuje(); UpdateUcestvuje(id,id1); break;
                case "dodeljuje": CreateDodeljuje(); UpdateDodeljuje(id,id1); break;
                default: break;
            }
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (update)
            {
                switch (entitet)
                {
                    case "stamparija": ClickUpdateStamparija(); break;
                    case "izdavac": ClickUpdateIzdavac(); break;
                    case "striparnica": ClickUpdateStriparnica(); break;
                    case "kategorija": ClickUpdateKategorija(); break;
                    case "nagrada": ClickUpdateNagrada(); break;
                    case "festival": ClickUpdateFestival(); break;
                    case "scenarista": ClickUpdateAutor(); break;
                    case "crtac": ClickUpdateAutor(); break;
                    case "strip": ClickUpdateStrip(); break;
                    case "izdaje": ClickUpdateIzdaje(); break;
                    case "prodaje": ClickUpdateProdaje(); break;
                    case "crta": ClickUpdateCrta(); break;
                    case "pise": ClickUpdatePise(); break;
                    case "ucestvuje": ClickUpdateUcestvuje(); break;
                    case "dodeljuje": ClickUpdateDodeljuje(); break;
                    default: break;
                }
            }
            else
            {
                switch (entitet)
                {
                    case "stamparija": ClickCreateStamparija(); break;
                    case "izdavac": ClickCreateIzdavac(); break;
                    case "striparnica": ClickCreateStriparnica(); break;
                    case "kategorija": ClickCreateKategorija(); break;
                    case "nagrada": ClickCreateNagrada(); break;
                    case "festival": ClickCreateFestival(); break;
                    case "scenarista": ClickCreateAutor(); break;
                    case "crtac": ClickCreateAutor(); break;
                    case "strip": ClickCreateStrip(); break;
                    case "izdaje": ClickCreateIzdaje(); break;
                    case "prodaje": ClickCreateProdaje(); break;
                    case "crta": ClickCreateCrta(); break;
                    case "pise": ClickCreatePise(); break;
                    case "ucestvuje": ClickCreateUcestvuje(); break;
                    case "dodeljuje": ClickCreateDodeljuje(); break;
                    default: break;
                }
            }
        }

        public bool Validate(TextBox textBox)
        {
            if (textBox.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        public bool ValidateCB(ComboBox comboBox)
        {
            if (comboBox.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

        public void Message()
        {
            MessageBox.Show("Polja nisu popunjena!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        #region stamparija
        public void CreateStamparija()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            RowDefinition r = new RowDefinition();
            r.Height = GridLength.Auto;
            grid.RowDefinitions.Add(r);

            Label label = new Label();
            label.Content = "Ime stamparije:";

            TextBox textBox = new TextBox();

            Grid.SetColumn(label, 0);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(textBox, 0);

            grid.Children.Add(label);
            grid.Children.Add(textBox);
        }

        public void UpdateStamparija(int id)
        {
            Stamparija stamparija = CRUD.GetRow.GetRowStamparija(id);
            ((TextBox)grid.Children[1]).Text = stamparija.imesta;
        }

        public void ClickCreateStamparija()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Create.CreateStamparija(ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateStamparija()
        {
            if (Validate((TextBox)grid.Children[1])) {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Update.UpdateStamparija(Id, ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region izdavac
        public void CreateIzdavac()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            RowDefinition r = new RowDefinition();
            r.Height = GridLength.Auto;
            grid.RowDefinitions.Add(r);

            Label label = new Label();
            label.Content = "Ime izdavaca:";

            TextBox textBox = new TextBox();

            Grid.SetColumn(label, 0);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(textBox, 0);

            grid.Children.Add(label);
            grid.Children.Add(textBox);
        }

        public void UpdateIzdavac(int id)
        {
            Izdavac izdavac = CRUD.GetRow.GetRowIzdavac(id);
            ((TextBox)grid.Children[1]).Text = izdavac.imei;
        }

        public void ClickCreateIzdavac()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Create.CreateIzdavac(ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateIzdavac()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Update.UpdateIzdavac(Id, ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region striparnica
        public void CreateStriparnica()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            RowDefinition r = new RowDefinition();
            r.Height = GridLength.Auto;
            grid.RowDefinitions.Add(r);

            Label label = new Label();
            label.Content = "Ime striparnice:";

            TextBox textBox = new TextBox();

            Grid.SetColumn(label, 0);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(textBox, 0);

            grid.Children.Add(label);
            grid.Children.Add(textBox);
        }

        public void UpdateStriparnica(int id)
        {
            Striparnica striparnica = CRUD.GetRow.GetRowStriparnica(id);
            ((TextBox)grid.Children[1]).Text = striparnica.imes;
        }

        public void ClickCreateStriparnica()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Create.CreateStriparnica(ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateStriparnica()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Update.UpdateStriparnica(Id, ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region kategorija
        public void CreateKategorija()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            RowDefinition r = new RowDefinition();
            r.Height = GridLength.Auto;
            grid.RowDefinitions.Add(r);

            Label label = new Label();
            label.Content = "Ime kategorije:";

            TextBox textBox = new TextBox();

            Grid.SetColumn(label, 0);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(textBox, 0);

            grid.Children.Add(label);
            grid.Children.Add(textBox);
        }

        public void UpdateKategorija(int id)
        {
            Kategorija kategorija = CRUD.GetRow.GetRowKategorija(id);
            ((TextBox)grid.Children[1]).Text = kategorija.imek;
        }

        public void ClickCreateKategorija()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Create.CreateKategorija(ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateKategorija()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Update.UpdateKategorija(Id, ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region nagrada
        public void CreateNagrada()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            RowDefinition r = new RowDefinition();
            r.Height = GridLength.Auto;
            grid.RowDefinitions.Add(r);

            Label label = new Label();
            label.Content = "Nagrada:";

            TextBox textBox = new TextBox();

            Grid.SetColumn(label, 0);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(textBox, 0);

            grid.Children.Add(label);
            grid.Children.Add(textBox);
        }

        public void UpdateNagrada(int id)
        {
            Nagrada nagrada = CRUD.GetRow.GetRowNagrada(id);
            ((TextBox)grid.Children[1]).Text = nagrada.imen;
        }

        public void ClickCreateNagrada()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Create.CreateNagrada(ime);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateNagrada()
        {
            if (Validate((TextBox)grid.Children[1]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                CRUD.Update.UpdateNagrada(Id, ime);
                this.Close();
            }
            else
            {
                Message();
            }
               
        }
        #endregion

        #region festival
        public void CreateFestival()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label1 = new Label();
            label1.Content = "Festival:";

            Label label2 = new Label();
            label2.Content = "Godina odrzavanja:";

            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();

            Grid.SetColumn(label1, 0);
            Grid.SetColumn(label2, 0);
            Grid.SetColumn(textBox1, 1);
            Grid.SetColumn(textBox2, 1);
            Grid.SetRow(label1, 0);
            Grid.SetRow(textBox1, 0);
            Grid.SetRow(label2,1);
            Grid.SetRow(textBox2, 1);

            grid.Children.Add(label1);
            grid.Children.Add(label2);
            grid.Children.Add(textBox1);
            grid.Children.Add(textBox2);
        }

        public void UpdateFestival(int id)
        {
            Festival festival = CRUD.GetRow.GetRowFestival(id);
            ((TextBox)grid.Children[2]).Text = festival.imef;
            ((TextBox)grid.Children[3]).Text = festival.gododr.ToString();
        }

        public void ClickCreateFestival()
        {
            if (Validate((TextBox)grid.Children[2]) && Validate((TextBox)grid.Children[3]))
            {
                string ime = ((TextBox)grid.Children[2]).Text.ToString();
                try
                {
                    int god = Int32.Parse(((TextBox)grid.Children[3]).Text.ToString());
                    CRUD.Create.CreateFestival(ime, god);
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Godina mora biti broj!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateFestival()
        {
            if (Validate((TextBox)grid.Children[2]) && Validate((TextBox)grid.Children[3]))
            {
                string ime = ((TextBox)grid.Children[2]).Text.ToString();
                int god = Int32.Parse(((TextBox)grid.Children[3]).Text.ToString());
                CRUD.Update.UpdateFestival(Id, ime, god);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region autor
        public void CreateAutor()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label1 = new Label();
            label1.Content = "Ime:";

            Label label2 = new Label();
            label2.Content = "Prezime:";

            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();

            Grid.SetColumn(label1, 0);
            Grid.SetColumn(label2, 0);
            Grid.SetColumn(textBox1, 1);
            Grid.SetColumn(textBox2, 1);
            Grid.SetRow(label1, 0);
            Grid.SetRow(textBox1, 0);
            Grid.SetRow(label2, 1);
            Grid.SetRow(textBox2, 1);

            grid.Children.Add(label1);
            grid.Children.Add(label2);
            grid.Children.Add(textBox1);
            grid.Children.Add(textBox2);
        }

        public void UpdateAutor(int id)
        {
            Autor autor = CRUD.GetRow.GetRowAutor(id);
            ((TextBox)grid.Children[2]).Text = autor.imea;
            ((TextBox)grid.Children[3]).Text = autor.prza;
        }

        public void ClickCreateAutor()
        {
            if (Validate((TextBox)grid.Children[2]) && Validate((TextBox)grid.Children[3]))
            {
                string ime = ((TextBox)grid.Children[2]).Text.ToString();
                string prz = ((TextBox)grid.Children[3]).Text.ToString();
                CRUD.Create.CreateAutor(entitet, ime, prz);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateAutor()
        {
            if (Validate((TextBox)grid.Children[2]) && Validate((TextBox)grid.Children[3]))
            {
                string ime = ((TextBox)grid.Children[2]).Text.ToString();
                string prz = ((TextBox)grid.Children[3]).Text.ToString();
                CRUD.Update.UpdateAutor(Id, ime, prz);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region strip
        public void CreateStrip()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 3; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label = new Label();
            label.Content = "Strip:";

            TextBox textBox = new TextBox();

            Grid.SetColumn(label, 0);
            Grid.SetColumn(textBox, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(textBox, 0);

            grid.Children.Add(label);
            grid.Children.Add(textBox);

            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox2 = new ComboBox();
            List<Kategorija> st1 = CRUD.Read.ReadKategorija();
            List<Stamparija> st2 = CRUD.Read.ReadStamparija();
            foreach(Kategorija k in st1)
            {
                comboBox1.Items.Add(k.idk + " - " + k.imek);
            }
            foreach(Stamparija s in st2)
            {
                comboBox2.Items.Add(s.idsta + " - " + s.imesta);
            }
            Grid.SetColumn(comboBox1, 1);
            Grid.SetColumn(comboBox2, 1);
            Grid.SetRow(comboBox1, 1);
            Grid.SetRow(comboBox2, 2);
            grid.Children.Add(comboBox1);
            grid.Children.Add(comboBox2);

            Label label1 = new Label();
            label1.Content = "Kategorija:";

            Label label2 = new Label();
            label2.Content = "Stamparija:";

            Grid.SetColumn(label1, 0);
            Grid.SetRow(label1, 1);
            Grid.SetColumn(label2, 0);
            Grid.SetRow(label2, 2);

            grid.Children.Add(label1);
            grid.Children.Add(label2);
        }

        public void UpdateStrip(int id)
        {
            Strip strip = CRUD.GetRow.GetRowStrip(id);
            Kategorija kategorija = CRUD.GetRow.GetRowKategorija(strip.Kategorija_idk);
            string str1 = kategorija.idk + " - " + kategorija.imek;
            Stamparija stamparija = CRUD.GetRow.GetRowStamparija(strip.Stamparija_idsta);
            string str2 = stamparija.idsta + " - " + stamparija.imesta;
            ((TextBox)grid.Children[1]).Text = strip.imestr;
            ((ComboBox)grid.Children[2]).SelectedIndex= ((ComboBox)grid.Children[2]).Items.IndexOf(str1);
            ((ComboBox)grid.Children[3]).SelectedIndex = ((ComboBox)grid.Children[3]).Items.IndexOf(str2);
        }

        public void ClickCreateStrip()
        {
            if (Validate((TextBox)grid.Children[1]) && ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                int idk = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                int idsta = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Create.CreateStrip(ime, idk, idsta);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateStrip()
        {
            if (Validate((TextBox)grid.Children[1]) && ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3]))
            {
                string ime = ((TextBox)grid.Children[1]).Text.ToString();
                int idk = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                int ids = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Update.UpdateStrip(Id, ime, idk, ids);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region izdaje
        public void CreateIzdaje()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label = new Label();
            label.Content = "Strip:";

            Label label1 = new Label();
            label1.Content = "Izdavac:";

            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox2 = new ComboBox();
            List<Strip> st1 = CRUD.Read.ReadStrip();
            List<Izdavac> st2 = CRUD.Read.ReadIzdavac();
            foreach (Strip k in st1)
            {
                comboBox1.Items.Add(k.idstr + " - " + k.imestr);
            }
            foreach (Izdavac s in st2)
            {
                comboBox2.Items.Add(s.idi + " - " + s.imei);
            }

            Grid.SetColumn(label, 0);
            Grid.SetColumn(label1, 0);
            Grid.SetColumn(comboBox1, 1);
            Grid.SetColumn(comboBox2, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(label1, 1);
            Grid.SetRow(comboBox1, 0);
            Grid.SetRow(comboBox2, 1);

            grid.Children.Add(label);
            grid.Children.Add(label1);
            grid.Children.Add(comboBox1);
            grid.Children.Add(comboBox2);
        }

        public void UpdateIzdaje(int idi,int idstr)
        {
            Izdaje izdaje = CRUD.GetRow.GetRowIzdaje(idi, idstr);

            Strip strip = CRUD.GetRow.GetRowStrip(idstr);
            Izdavac izdavac = CRUD.GetRow.GetRowIzdavac(idi);
            string str1 = strip.idstr + " - " + strip.imestr;
            string str2 = izdavac.idi + " - " + izdavac.imei;

            ((ComboBox)grid.Children[2]).SelectedIndex = ((ComboBox)grid.Children[2]).Items.IndexOf(str1);
            ((ComboBox)grid.Children[3]).SelectedIndex = ((ComboBox)grid.Children[3]).Items.IndexOf(str2);
        }

        public void ClickCreateIzdaje()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                int idi = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Create.CreateIzdaje(idi, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateIzdaje()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idi = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Update.UpdateIzdaje(stari_idi, stari_idstr, idi, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region prodaje
        public void CreateProdaje()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label = new Label();
            label.Content = "Strip:";

            Label label1 = new Label();
            label1.Content = "Striparnica:";

            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox2 = new ComboBox();
            List<Strip> st1 = CRUD.Read.ReadStrip();
            List<Striparnica> st2 = CRUD.Read.ReadStriparnica();
            foreach (Strip k in st1)
            {
                comboBox1.Items.Add(k.idstr + " - " + k.imestr);
            }
            foreach (Striparnica s in st2)
            {
                comboBox2.Items.Add(s.ids + " - " + s.imes);
            }

            Grid.SetColumn(label, 0);
            Grid.SetColumn(label1, 0);
            Grid.SetColumn(comboBox1, 1);
            Grid.SetColumn(comboBox2, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(label1, 1);
            Grid.SetRow(comboBox1, 0);
            Grid.SetRow(comboBox2, 1);

            grid.Children.Add(label);
            grid.Children.Add(label1);
            grid.Children.Add(comboBox1);
            grid.Children.Add(comboBox2);
        }

        public void UpdateProdaje(int ids, int idstr)
        {
            Prodaje prodaje = CRUD.GetRow.GetRowProdaje(ids, idstr);

            Strip strip = CRUD.GetRow.GetRowStrip(idstr);
            Striparnica striparnica = CRUD.GetRow.GetRowStriparnica(ids);
            string str1 = strip.idstr + " - " + strip.imestr;
            string str2 = striparnica.ids + " - " + striparnica.imes;

            ((ComboBox)grid.Children[2]).SelectedIndex = ((ComboBox)grid.Children[2]).Items.IndexOf(str1);
            ((ComboBox)grid.Children[3]).SelectedIndex = ((ComboBox)grid.Children[3]).Items.IndexOf(str2);
        }

        public void ClickCreateProdaje()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                int ids = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Create.CreateProdaje(ids, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateProdaje()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int ids = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Update.UpdateProdaje(stari_idi, stari_idstr, ids, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region crta
        public void CreateCrta()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label = new Label();
            label.Content = "Strip:";

            Label label1 = new Label();
            label1.Content = "Crtac:";

            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox2 = new ComboBox();
            List<Strip> st1 = CRUD.Read.ReadStrip();
            List<Autor> st2 = CRUD.Read.ReadAutor("crtac");
            foreach (Strip k in st1)
            {
                comboBox1.Items.Add(k.idstr + " - " + k.imestr);
            }
            foreach (Crtac s in st2)
            {
                comboBox2.Items.Add(s.ida + " - " + s.imea + " "+s.prza);
            }

            Grid.SetColumn(label, 0);
            Grid.SetColumn(label1, 0);
            Grid.SetColumn(comboBox1, 1);
            Grid.SetColumn(comboBox2, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(label1, 1);
            Grid.SetRow(comboBox1, 0);
            Grid.SetRow(comboBox2, 1);

            grid.Children.Add(label);
            grid.Children.Add(label1);
            grid.Children.Add(comboBox1);
            grid.Children.Add(comboBox2);
        }

        public void UpdateCrta(int idi, int idstr)
        {
            Crta crta = CRUD.GetRow.GetRowCrta(idi, idstr);

            Strip strip = CRUD.GetRow.GetRowStrip(idstr);
            Autor crtac = CRUD.GetRow.GetRowAutor(idi);
            string str1 = strip.idstr + " - " + strip.imestr;
            string str2 = crtac.ida + " - " + crtac.imea + " " + crtac.prza;

            ((ComboBox)grid.Children[2]).SelectedIndex = ((ComboBox)grid.Children[2]).Items.IndexOf(str1);
            ((ComboBox)grid.Children[3]).SelectedIndex = ((ComboBox)grid.Children[3]).Items.IndexOf(str2);
        }

        public void ClickCreateCrta()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                int ida = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Create.CreateCrta(ida, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateCrta()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int ida = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Update.UpdateCrta(stari_idi, stari_idstr, ida, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region pise
        public void CreatePise()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label = new Label();
            label.Content = "Strip:";

            Label label1 = new Label();
            label1.Content = "Scenarista:";

            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox2 = new ComboBox();
            List<Strip> st1 = CRUD.Read.ReadStrip();
            List<Autor> st2 = CRUD.Read.ReadAutor("scenarista");
            foreach (Strip k in st1)
            {
                comboBox1.Items.Add(k.idstr + " - " + k.imestr);
            }
            foreach (Scenarista s in st2)
            {
                comboBox2.Items.Add(s.ida + " - " + s.imea + " " + s.prza);
            }

            Grid.SetColumn(label, 0);
            Grid.SetColumn(label1, 0);
            Grid.SetColumn(comboBox1, 1);
            Grid.SetColumn(comboBox2, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(label1, 1);
            Grid.SetRow(comboBox1, 0);
            Grid.SetRow(comboBox2, 1);

            grid.Children.Add(label);
            grid.Children.Add(label1);
            grid.Children.Add(comboBox1);
            grid.Children.Add(comboBox2);
        }

        public void UpdatePise(int idi, int idstr)
        {
            Pise pise = CRUD.GetRow.GetRowPise(idi, idstr);

            Strip strip = CRUD.GetRow.GetRowStrip(idstr);
            Autor scenarista = CRUD.GetRow.GetRowAutor(idi);
            string str1 = strip.idstr + " - " + strip.imestr;
            string str2 = scenarista.ida + " - " + scenarista.imea + " " + scenarista.prza;

            ((ComboBox)grid.Children[2]).SelectedIndex = ((ComboBox)grid.Children[2]).Items.IndexOf(str1);
            ((ComboBox)grid.Children[3]).SelectedIndex = ((ComboBox)grid.Children[3]).Items.IndexOf(str2);
        }

        public void ClickCreatePise()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                int ida = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Create.CreatePise(ida, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdatePise()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int ida = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Update.UpdatePise(stari_idi, stari_idstr, ida, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion

        #region ucestvuje
        public void CreateUcestvuje()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label = new Label();
            label.Content = "Strip:";

            Label label1 = new Label();
            label1.Content = "Festival:";

            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox2 = new ComboBox();
            List<Strip> st1 = CRUD.Read.ReadStrip();
            List<Festival> st2 = CRUD.Read.ReadFestival();
            foreach (Strip k in st1)
            {
                comboBox1.Items.Add(k.idstr + " - " + k.imestr);
            }
            foreach (Festival s in st2)
            {
                comboBox2.Items.Add(s.idf + " - " + s.imef + " " + s.gododr);
            }

            Grid.SetColumn(label, 0);
            Grid.SetColumn(label1, 0);
            Grid.SetColumn(comboBox1, 1);
            Grid.SetColumn(comboBox2, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(label1, 1);
            Grid.SetRow(comboBox1, 0);
            Grid.SetRow(comboBox2, 1);

            grid.Children.Add(label);
            grid.Children.Add(label1);
            grid.Children.Add(comboBox1);
            grid.Children.Add(comboBox2);
        }

        public void UpdateUcestvuje(int idf, int idstr)
        {
            Ucestvuje ucestvuje = CRUD.GetRow.GetRowUcestvuje(idf, idstr);

            Strip strip = CRUD.GetRow.GetRowStrip(idstr);
            Festival festival = CRUD.GetRow.GetRowFestival(idf);
            string str1 = strip.idstr + " - " + strip.imestr;
            string str2 = festival.idf + " - " + festival.imef + " " + festival.gododr;

            ((ComboBox)grid.Children[2]).SelectedIndex = ((ComboBox)grid.Children[2]).Items.IndexOf(str1);
            ((ComboBox)grid.Children[3]).SelectedIndex = ((ComboBox)grid.Children[3]).Items.IndexOf(str2);
        }

        public void ClickCreateUcestvuje()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
                int idf = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Create.CreateUcestvuje(idf, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateUcestvuje()
        {
            int idf = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
            int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0]);
            CRUD.Update.UpdateUcestvuje(stari_idi, stari_idstr, idf, idstr);
            this.Close();
        }
        #endregion

        #region dodeljuje
        public void CreateDodeljuje()
        {
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < 2; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Auto;
                grid.RowDefinitions.Add(r);
            }

            Label label = new Label();
            label.Content = "Strip:";

            Label label2 = new Label();
            label2.Content = "Nagrada:";

            ComboBox comboBox1 = new ComboBox();
            ComboBox comboBox3 = new ComboBox();
            List<Ucestvuje> st1 = CRUD.Read.ReadUcestvuje();
           
            List<Nagrada> st3 = CRUD.Read.ReadNagrada();
            foreach (Ucestvuje k in st1)
            {
                Festival f = CRUD.GetRow.GetRowFestival(k.Festival_idf);
                comboBox1.Items.Add(k.Strip_idstr5+"+"+k.Festival_idf+" "+CRUD.GetRow.GetRowStrip(k.Strip_idstr5).imestr+" "+f.imef+" "+f.gododr);
            }
            foreach(Nagrada n in st3)
            {
                comboBox3.Items.Add(n.idn + " - " + n.imen);
            }

            Grid.SetColumn(label, 0);
            Grid.SetColumn(label2, 0);
            Grid.SetColumn(comboBox1, 1);
            Grid.SetColumn(comboBox3, 1);
            Grid.SetRow(label, 0);
            Grid.SetRow(label2, 1);
            Grid.SetRow(comboBox1, 0);
            Grid.SetRow(comboBox3, 1);

            grid.Children.Add(label);
            grid.Children.Add(label2);
            grid.Children.Add(comboBox1);
            grid.Children.Add(comboBox3);
        }

        public void UpdateDodeljuje(int idn, int idf)
        {
            Dodeljuje dodeljuje = CRUD.GetRow.GetRowDodeljuje(idn,idf);

            Ucestvuje ucestvuje = CRUD.GetRow.GetRowUcestvuje(idf, dodeljuje.UcestvujeStrip_idstr);

            Strip strip = CRUD.GetRow.GetRowStrip(ucestvuje.Strip_idstr5);
            Festival festival = CRUD.GetRow.GetRowFestival(ucestvuje.Festival_idf);
            Nagrada nagrada = CRUD.GetRow.GetRowNagrada(idn);
            string str1 = ucestvuje.Strip_idstr5 + "+" + ucestvuje.Festival_idf+" " + strip.imestr+" "  + festival.imef + " " + festival.gododr;
            string str3 = nagrada.idn + " - " + nagrada.imen;

            ((ComboBox)grid.Children[2]).SelectedIndex = ((ComboBox)grid.Children[2]).Items.IndexOf(str1);
            ((ComboBox)grid.Children[3]).SelectedIndex = ((ComboBox)grid.Children[3]).Items.IndexOf(str3);
        }

        public void ClickCreateDodeljuje()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0].Split('+')[0]);
                int idf = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0].Split('+')[1]);
                int idn = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Create.CreateDodeljuje(idn, idf, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }

        public void ClickUpdateDodeljuje()
        {
            if ((ValidateCB((ComboBox)grid.Children[2]) && ValidateCB((ComboBox)grid.Children[3])))
            {
                int idf = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0].Split('+')[1]);
                int idstr = Int32.Parse(((ComboBox)grid.Children[2]).SelectedItem.ToString().Split(' ')[0].Split('+')[0]);
                int idn = Int32.Parse(((ComboBox)grid.Children[3]).SelectedItem.ToString().Split(' ')[0]);
                CRUD.Update.UpdateDodeljuje(stari_idi, stari_idn, stari_idstr, idn, idf, idstr);
                this.Close();
            }
            else
            {
                Message();
            }
        }
        #endregion
    }
}
