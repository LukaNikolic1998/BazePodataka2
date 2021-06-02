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
    /// Interaction logic for InsertFestival.xaml
    /// </summary>
    public partial class InsertFestival : Window
    {
        public InsertFestival()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (Validate((TextBox)tbImeF) && Validate((TextBox)tbGod))
            {
                string ime = ((TextBox)tbImeF).Text.ToString();
                try
                {
                    int god = Int32.Parse(((TextBox)tbGod).Text.ToString());
                    CRUD.Procedure.P_INS_Festival(ime, god);
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

        public bool Validate(TextBox textBox)
        {
            if (textBox.Text.Equals(""))
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
