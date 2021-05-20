using SistemaDeEmprestimos.Model;
using System;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace SistemaDeEmprestimos.ViewModel
{
    public class CadastrarEmprestimosViewModel : BaseViewModel
    {
        private string _nomeCredor = string.Empty;
        private string _nomeDevedor = string.Empty;
        public double _valor = 0;
        public DateTime _dataDoEmprestimo = DateTime.Today;
        private SecureString _senhaDevedor = null;

        public ICommand ComandoCadastrarEmprestimo { get { return new RelayCommand<object>(CadastrarEmprestimo_Click); } }

        public string NomeCredor
        {
            get { return _nomeCredor; }
            set
            {
                _nomeCredor = value;
                OnPropertyChanged(nameof(NomeCredor));
            }
        }

        public string NomeDevedor
        {
            get { return _nomeDevedor; }
            set
            {
                _nomeDevedor = value;
                OnPropertyChanged(nameof(NomeDevedor));
            }
        }

        public double Valor
        {
            get { return _valor; }
            set
            {
                _valor = value;
                OnPropertyChanged(nameof(Valor));
            }
        }

        public DateTime DataDoEmprestimo
        {
            get { return _dataDoEmprestimo; }
            set
            {
                _dataDoEmprestimo = value;
                OnPropertyChanged(nameof(DataDoEmprestimo));
            }
        }

        public SecureString SenhaDevedor
        {
            get { return _senhaDevedor; }
            set
            {
                _senhaDevedor = value;
                OnPropertyChanged(nameof(SenhaDevedor));
            }
        }

        public string SenhaDevedorString
        {
            get
            {
                return new System.Net.NetworkCredential(string.Empty, SenhaDevedor).Password;
            }
        }

        private void CadastrarEmprestimo_Click(object sender)
        {
            if(ValidarCampos())
            {
                Usuario Credor = Model.SistemaDeEmprestimos.Instancia.GetUsuarioPorNome(NomeCredor);
                Usuario Devedor = Model.SistemaDeEmprestimos.Instancia.GetUsuarioPorNome(NomeDevedor);
                bool emprestimoCadastrado = Model.SistemaDeEmprestimos.Instancia.CadastraEmprestimo(Credor, 
                    Devedor, DataDoEmprestimo, Valor, SenhaDevedorString);
                if (emprestimoCadastrado)
                {
                    MessageBox.Show("Empréstimo cadastrado com sucesso!.");
                }
                else
                {
                    MessageBox.Show("Senha do devedor incorreta.");
                }
            }
        }

        private bool ValidarCampos()
        {
            if (!Model.SistemaDeEmprestimos.Instancia.VerificarUsuarioExistente(NomeDevedor))
            {
                MessageBox.Show("Não existe um usuário com o nome do devedor.");
                return false;
            }
            else if (!Model.SistemaDeEmprestimos.Instancia.VerificarUsuarioExistente(NomeCredor))
            {
                MessageBox.Show("Não existe um usuário com o nome do credor.");
                return false;
            }
            else if (Valor == 0)
            {
                MessageBox.Show("Digite um valor maior que zero.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(SenhaDevedorString))
            {
                MessageBox.Show("Digite a senha do devedor.");
                return false;
            }
            return true;
        }
    }
}
