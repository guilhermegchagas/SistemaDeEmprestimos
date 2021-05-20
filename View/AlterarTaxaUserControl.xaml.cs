using SistemaDeEmprestimos.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaDeEmprestimos.View
{
    public partial class AlterarTaxaUserControl : UserControl
    {
        protected AlterarTaxaViewModel ViewModel
        {
            get { return (AlterarTaxaViewModel)DataContext; }
        }

        public AlterarTaxaUserControl()
        {
            InitializeComponent();
        }

        private void SenhaAdministrador_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SenhaAdministrador = senhaAdministradorBox.SecurePassword;
        }

        private void TextBox_OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = e.Source as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
        }
    }
}
