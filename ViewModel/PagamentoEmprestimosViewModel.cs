using SistemaDeEmprestimos.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SistemaDeEmprestimos.ViewModel
{
    public class PagamentoEmprestimosViewModel : BaseViewModel
    {
        private string _nomeCredor = string.Empty;
        private string _nomeDevedor = string.Empty;
        private SecureString _senhaCredor = null;
        private ObservableCollection<Emprestimo> _listaDeEmprestimos = new ObservableCollection<Emprestimo>();
        private Emprestimo _emprestimoSelecionado = null;

        public ICommand ComandoProcurar { get { return new RelayCommand<object>(BotaoProcurar_Click); } }
        public ICommand ComandoQuitarEmprestimo { get { return new RelayCommand<object>(BotaoQuitarEmprestimo_Click); } }

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

        public SecureString SenhaCredor
        {
            get { return _senhaCredor; }
            set
            {
                _senhaCredor = value;
                OnPropertyChanged(nameof(SenhaCredor));
            }
        }

        public ObservableCollection<Emprestimo> ListaDeEmprestimos
        {
            get { return _listaDeEmprestimos; }
            set
            {
                _listaDeEmprestimos = value;
                OnPropertyChanged(nameof(ListaDeEmprestimos));
            }
        }

        public Emprestimo EmprestimoSelecionado
        {
            get { return _emprestimoSelecionado; }
            set
            {
                _emprestimoSelecionado = value;
                OnPropertyChanged(nameof(EmprestimoSelecionado));
            }
        }

        public PagamentoEmprestimosViewModel()
        {
            AlterarTaxaViewModel.OnTaxaChanged += AlterarTaxaViewModel_OnTaxaChanged;
        }

        private void AlterarTaxaViewModel_OnTaxaChanged(double novaTaxaDiaria, double novaTaxaMensal)
        {
            if(EmprestimoSelecionado != null)
            {
                CarregarListaDeEmprestimos(EmprestimoSelecionado.Credor.Nome, EmprestimoSelecionado.Devedor.Nome);
            }
        }

        private void BotaoProcurar_Click(object sender)
        {
            if(!Model.SistemaDeEmprestimos.Instancia.VerificarUsuarioExistente(NomeCredor))
            {
                MessageBox.Show("Não existe um usuário com o nome do credor.");
            }
            else if (!Model.SistemaDeEmprestimos.Instancia.VerificarUsuarioExistente(NomeDevedor))
            {
                MessageBox.Show("Não existe um usuário com o nome do devedor.");
            }
            else
            {
                CarregarListaDeEmprestimos(NomeCredor, NomeDevedor);
            }
        }

        private void BotaoQuitarEmprestimo_Click(object sender)
        {
            if (EmprestimoSelecionado == null)
            {
                MessageBox.Show("Nenhum empréstimo selecionado.");
                return;
            }

            string senha = new System.Net.NetworkCredential(string.Empty, SenhaCredor).Password;
            if (string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show("Digite a senha do credor.");
                return;
            }

            bool emprestimoQuitado = Model.SistemaDeEmprestimos.Instancia.QuitarEmprestimo(EmprestimoSelecionado, senha);
            if(!emprestimoQuitado)
            {
                MessageBox.Show("Senha do credor incorreta.");
                return;
            }
            CarregarListaDeEmprestimos(EmprestimoSelecionado.Credor.Nome, EmprestimoSelecionado.Devedor.Nome);
        }

        private void CarregarListaDeEmprestimos(string nomeCredor, string nomeDevedor)
        {
            List<Emprestimo> emprestimos = Model.SistemaDeEmprestimos.Instancia.ObterEmprestimosEntre(nomeCredor, nomeDevedor);
            ListaDeEmprestimos = new ObservableCollection<Emprestimo>(emprestimos);
        }
    }
}
