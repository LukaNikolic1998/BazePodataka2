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
    /// Interaction logic for StripKategorija.xaml
    /// </summary>
    public partial class StripKategorija : Window
    {
        public StripKategorija()
        {
            InitializeComponent();
            List<Kategorija> kategorijas = CRUD.Read.ReadKategorija();
            foreach(Kategorija kategorija in kategorijas)
            {
                cbKat.Items.Add(kategorija.idk + " - " + kategorija.imek);
            }
            cbOp.Items.Add("Funkcija");
            cbOp.Items.Add("Kursor");
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            labelStripovi.Content = "";
            if (ValidateCB(cbKat) && ValidateCB(cbOp))
            {
                if (cbOp.SelectedItem.ToString().Equals("Funkcija"))
                {
                    foreach (string str in CRUD.Funkcije.F_GET_StripPoKategoriji(Int32.Parse(cbKat.SelectedItem.ToString().Split(' ')[0])))
                    {
                        labelStripovi.Content += str + "\n";
                    }
                }else if (cbOp.SelectedItem.ToString().Equals("Kursor"))
                {
                    string[] stripovi = CRUD.Procedure.P_StripoviPoKategoriji(Int32.Parse(cbKat.SelectedItem.ToString().Split(' ')[0])).Split('*');
                    foreach(string s in stripovi)
                    {
                        if (!s.Equals(""))
                        {
                            labelStripovi.Content += s + "\n";
                        }
                    }
                }
            }
            else
            {
                Message();
            }
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
    }
}
