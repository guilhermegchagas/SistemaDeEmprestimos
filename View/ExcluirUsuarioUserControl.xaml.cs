using SistemaDeEmprestimos.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SistemaDeEmprestimos.View
{
    public partial class ExcluirUsuarioUserControl : UserControl
    {
        protected ExcluirUsuarioViewModel ViewModel
        {
            get { return (ExcluirUsuarioViewModel)DataContext; }
        }

        public ExcluirUsuarioUserControl()
        {
            InitializeComponent();
        }

        private void SenhaAdministrador_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SenhaAdministrador = senhaAdministradorBox.SecurePassword;
        }
    }
}
