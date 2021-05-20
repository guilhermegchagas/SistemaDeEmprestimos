using SistemaDeEmprestimos.Model;
using System;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace SistemaDeEmprestimos.ViewModel
{
    public class ExcluirUsuarioViewModel : BaseViewModel
    {
        private string _nomeUsuario = string.Empty;
        private SecureString _senhaAdministrador = null;

        public ICommand ComandoExcluirUsuario { get { return new RelayCommand<object>(ExcluirUsuario_Click); } }

        public string NomeUsuario
        {
            get { return _nomeUsuario; }
            set
            {
                _nomeUsuario = value;
                OnPropertyChanged(nameof(NomeUsuario));
            }
        }

        public SecureString SenhaAdministrador
        {
            get { return _senhaAdministrador; }
            set
            {
                _senhaAdministrador = value;
                OnPropertyChanged(nameof(SenhaAdministrador));
            }
        }

        public string SenhaAdministradorString
        {
            get
            {
                return new System.Net.NetworkCredential(string.Empty, SenhaAdministrador).Password;
            }
        }

        private void ExcluirUsuario_Click(object sender)
        {
            if(ValidarCampos())
            {
                bool usuarioExcluido = Model.SistemaDeEmprestimos.Instancia.ExcluirUsuario(NomeUsuario,
                    SenhaAdministradorString);
                if (usuarioExcluido)
                {
                    MessageBox.Show("Usuário excluído com sucesso!");
                }
                else
                {
                    MessageBox.Show("Senha do administrador incorreta.");
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(NomeUsuario))
            {
                MessageBox.Show("Digite o nome do usuário.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(SenhaAdministradorString))
            {
                MessageBox.Show("Digite a senha do administrador.");
                return false;
            }
            if (!Model.SistemaDeEmprestimos.Instancia.VerificarUsuarioExistente(NomeUsuario))
            {
                MessageBox.Show("Usuário não existe.");
                return false;
            }
            if (Model.SistemaDeEmprestimos.Instancia.ObterEmprestimosUsuario(NomeUsuario).Count != 0)
            {
                MessageBox.Show("Não é possível excluir usuário, pois existem empréstimos associados.");
                return false;
            }
            return true;
        }
    }
}
