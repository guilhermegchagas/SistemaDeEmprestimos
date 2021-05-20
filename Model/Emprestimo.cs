using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEmprestimos.Model
{
    public class Emprestimo
    {
        public Usuario Credor { get; } = null;
        public Usuario Devedor { get; } = null;
        public DateTime Data { get; } = DateTime.MinValue;
        public double Valor { get; } = 0;
        public double ValorCorrigidoAteDataCorrente
        {
            get
            {
                int diasCorridos = (DateTime.Now.Date - Data.Date).Days;
                double valorCorrigido = Valor;
                for(int i = 1; i <= diasCorridos; i++)
                {
                    valorCorrigido += valorCorrigido * SistemaDeEmprestimos.Instancia.TaxaDiaria;
                    if(i % 30 == 0)
                    {
                        valorCorrigido += valorCorrigido * SistemaDeEmprestimos.Instancia.TaxaMensal;
                    }
                }
                return valorCorrigido;
            }
        }

        public Emprestimo(Usuario credor, Usuario devedor, DateTime data, double valor)
        {
            Credor = credor;
            Devedor = devedor;
            Data = data;
            Valor = valor;
        }
    }
}
