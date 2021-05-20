using SistemaDeEmprestimos.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SistemaDeEmprestimos.ViewModel
{
    public class ConsultarEmprestimosViewModel : BaseViewModel
    {
        private string _nomeUsuario = string.Empty;
        private ObservableCollection<Emprestimo> _listaDeEmprestimos = new ObservableCollection<Emprestimo>();

        public ICommand ComandoProcurar { get { return new RelayCommand<object>(BotaoProcurar_Click); } }

        public string NomeUsuario
        {
            get { return _nomeUsuario; }
            set
            {
                _nomeUsuario = value;
                OnPropertyChanged(nameof(NomeUsuario));
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

        public ConsultarEmprestimosViewModel()
        {
            AlterarTaxaViewModel.OnTaxaChanged += AlterarTaxaViewModel_OnTaxaChanged;
        }

        private void AlterarTaxaViewModel_OnTaxaChanged(double novaTaxaDiaria, double novaTaxaMensal)
        {
            if(!string.IsNullOrWhiteSpace(NomeUsuario))
            {
                CarregarListaDeEmprestimos(NomeUsuario);
            }
        }

        private void BotaoProcurar_Click(object sender)
        {
            if(!Model.SistemaDeEmprestimos.Instancia.VerificarUsuarioExistente(NomeUsuario))
            {
                MessageBox.Show("Não existe um usuário com este nome.");
            }
            else
            {
                CarregarListaDeEmprestimos(NomeUsuario);
            }
        }

        private void CarregarListaDeEmprestimos(string nomeUsuario)
        {
            List<Emprestimo> emprestimos = Model.SistemaDeEmprestimos.Instancia.ObterEmprestimosUsuario(nomeUsuario);
            ListaDeEmprestimos = new ObservableCollection<Emprestimo>(emprestimos);
        }
    }
}
