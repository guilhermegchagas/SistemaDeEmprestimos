using SistemaDeEmprestimos.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaDeEmprestimos.View
{
    public partial class CadastrarEmprestimosUserControl : UserControl
    {
        protected CadastrarEmprestimosViewModel ViewModel
        {
            get { return (CadastrarEmprestimosViewModel)DataContext; }
        }

        public CadastrarEmprestimosUserControl()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SenhaDevedor = passwordBox.SecurePassword;
        }

        private void TextBox_OnlyNumbers(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
        }
    }
}
