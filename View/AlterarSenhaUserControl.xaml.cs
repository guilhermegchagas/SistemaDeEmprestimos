using SistemaDeEmprestimos.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaDeEmprestimos.View
{
    public partial class AlterarSenhaUserControl : UserControl
    {
        protected AlterarSenhaViewModel ViewModel
        {
            get { return (AlterarSenhaViewModel)DataContext; }
        }

        public AlterarSenhaUserControl()
        {
            InitializeComponent();
        }

        private void SenhaUsuario_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SenhaUsuario = senhaUsuarioBox.SecurePassword;
        }

        private void NovaSenhaUsuario_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.NovaSenhaUsuario = novaSenhaUsuarioBox.SecurePassword;
        }
    }
}
