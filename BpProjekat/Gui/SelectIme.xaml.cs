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
    /// Interaction logic for SelectIme.xaml
    /// </summary>
    public partial class SelectIme : Window
    {
        public SelectIme()
        {
            InitializeComponent();
            List<Festival> festivals = CRUD.Read.ReadFestival();
            foreach (Festival f in festivals)
            {
                cbImeF.Items.Add(f.idf);
            }
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateCB(cbImeF))
            {
                string ime = CRUD.Procedure.P_SEL_Ime(Int32.Parse(cbImeF.SelectedItem.ToString()));
                labelIme.Content = ime;
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
