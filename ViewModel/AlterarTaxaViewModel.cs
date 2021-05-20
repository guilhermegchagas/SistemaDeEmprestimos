using SistemaDeEmprestimos.Model;
using System;
using System.Security;
using System.Windows;
using System.Windows.Input;

namespace SistemaDeEmprestimos.ViewModel
{
    public delegate void TaxaChanged(double novaTaxaDiaria, double novaTaxaMensal);

    public class AlterarTaxaViewModel : BaseViewModel
    {
        public static event TaxaChanged OnTaxaChanged;

        private double _novaTaxaDiaria = 0;
        private double _novaTaxaMensal = 0;
        private SecureString _senhaAdministrador = null;

        public ICommand ComandoAlterarTaxa { get { return new RelayCommand<object>(AlterarTaxa_Click); } }

        public double NovaTaxaDiaria
        {
            get { return _novaTaxaDiaria; }
            set
            {
                _novaTaxaDiaria = value;
                OnPropertyChanged(nameof(NovaTaxaDiaria));
            }
        }

        public double NovaTaxaMensal
        {
            get { return _novaTaxaMensal; }
            set
            {
                _novaTaxaMensal = value;
                OnPropertyChanged(nameof(NovaTaxaMensal));
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

        private void AlterarTaxa_Click(object sender)
        {
            if(ValidarCampos())
            {
                bool taxaAlterada = Model.SistemaDeEmprestimos.Instancia.AlterarTaxas(
                    NovaTaxaDiaria/100,
                    NovaTaxaMensal/100,
                    SenhaAdministradorString);
                if (taxaAlterada)
                {
                    OnTaxaChanged?.Invoke(NovaTaxaDiaria, NovaTaxaMensal);
                    MessageBox.Show("Taxa alterada com sucesso!");
                }
                else
                {
                    MessageBox.Show("Senha do administrador incorreta.");
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(SenhaAdministradorString))
            {
                MessageBox.Show("Digite a senha do administrador.");
                return false;
            }
            return true;
        }
    }
}
