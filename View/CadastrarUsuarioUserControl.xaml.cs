using SistemaDeEmprestimos.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaDeEmprestimos.View
{
    public partial class CadastrarUsuarioUserControl : UserControl
    {
        protected CadastrarUsuarioViewModel ViewModel
        {
            get { return (CadastrarUsuarioViewModel)DataContext; }
        }

        public CadastrarUsuarioUserControl()
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
