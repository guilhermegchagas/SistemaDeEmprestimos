using SistemaDeEmprestimos.Model;
using System;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace SistemaDeEmprestimos.ViewModel
{
    public class CadastrarUsuarioViewModel : BaseViewModel
    {
        private string _nomeUsuario = string.Empty;
        private SecureString _senhaUsuario = null;
        private SecureString _senhaAdministrador = null;

        public ICommand ComandoCadastrarUsuario { get { return new RelayCommand<object>(CadastrarUsuario_Click); } }

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

        private void CadastrarUsuario_Click(object sender)
        {
            if(ValidarCampos())
            {
                bool usuarioCadastrado = Model.SistemaDeEmprestimos.Instancia.CadastraUsuario(
                    NomeUsuario,
                    SenhaUsuarioString,
                    SenhaAdministradorString);
                if (usuarioCadastrado)
                {
                    MessageBox.Show("Usuário cadastrado com sucesso!.");
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
                MessageBox.Show("Digite o nome de usuário.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(SenhaUsuarioString))
            {
                MessageBox.Show("Digite a senha do usuário.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(SenhaAdministradorString))
            {
                MessageBox.Show("Digite a senha do administrador.");
                return false;
            }
            return true;
        }
    }
}
