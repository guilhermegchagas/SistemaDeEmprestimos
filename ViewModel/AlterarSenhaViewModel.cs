using SistemaDeEmprestimos.Model;
using System;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace SistemaDeEmprestimos.ViewModel
{
    public class AlterarSenhaViewModel : BaseViewModel
    {
        private string _nomeUsuario = string.Empty;
        private SecureString _senhaUsuario = null;
        private SecureString _novaSenhaUsuario = null;

        public ICommand ComandoAlterarSenha { get { return new RelayCommand<object>(AlterarSenha_Click); } }

        public string NomeUsuario
        {
            get { return _nomeUsuario; }
            set
            {
                _nomeUsuario = value;
                OnPropertyChanged(nameof(NomeUsuario));
            }
        }

        public SecureString SenhaUsuario
        {
            get { return _senhaUsuario; }
            set
            {
                _senhaUsuario = value;
                OnPropertyChanged(nameof(SenhaUsuario));
            }
        }

        public string SenhaUsuarioString
        {
            get
            {
                return new System.Net.NetworkCredential(string.Empty, SenhaUsuario).Password;
            }
        }

        public SecureString NovaSenhaUsuario
        {
            get { return _novaSenhaUsuario; }
            set
            {
                _novaSenhaUsuario = value;
                OnPropertyChanged(nameof(NovaSenhaUsuario));
            }
        }

        public string NovaSenhaUsuarioString
        {
            get
            {
                return new System.Net.NetworkCredential(string.Empty, NovaSenhaUsuario).Password;
            }
        }

        private void AlterarSenha_Click(object sender)
        {
            if(ValidarCampos())
            {
                bool senhaAlterada = Model.SistemaDeEmprestimos.Instancia.AlterarSenhaUsuario(NomeUsuario, 
                    SenhaUsuarioString, NovaSenhaUsuarioString);
                if (senhaAlterada)
                {
                    MessageBox.Show("Senha alterada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Senha atual incorreta.");
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
            if (string.IsNullOrWhiteSpace(SenhaUsuarioString))
            {
                MessageBox.Show("Digite a senha do usuário.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(NovaSenhaUsuarioString))
            {
                MessageBox.Show("Digite a nova senha do usuário.");
                return false;
            }
            if (!Model.SistemaDeEmprestimos.Instancia.VerificarUsuarioExistente(NomeUsuario))
            {
                MessageBox.Show("Usuário não existe.");
                return false;
            }
            return true;
        }
    }
}
