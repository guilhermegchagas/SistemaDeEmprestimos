using SistemaDeEmprestimos.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaDeEmprestimos.View
{
    public partial class ResetarSenhaUserControl : UserControl
    {
        protected ResetarSenhaViewModel ViewModel
        {
            get { return (ResetarSenhaViewModel)DataContext; }
        }

        public ResetarSenhaUserControl()
        {
            InitializeComponent();
        }

        private void SenhaUsuario_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SenhaUsuario = senhaUsuarioBox.SecurePassword;
        }

        private void SenhaAdministrador_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SenhaAdministrador = senhaAdministradorBox.SecurePassword;
        }
    }
}
