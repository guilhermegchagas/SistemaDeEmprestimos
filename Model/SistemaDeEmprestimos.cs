using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEmprestimos.Model
{
    public class SistemaDeEmprestimos
    {
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Emprestimo> _emprestimos = new List<Emprestimo>();
        private string _senhaAdministrador = "admin";
        private static readonly SistemaDeEmprestimos _instancia = new SistemaDeEmprestimos();

        public double TaxaDiaria { get; set; } = 0.001;
        public double TaxaMensal { get; set; } = 0.1;

        public static SistemaDeEmprestimos Instancia
        {
            get
            {
                return _instancia;
            }
        }

        public bool CadastraUsuario(string nomeUsuario, string senhaUsuario, string senhaAdministrador)
        {
            if (senhaAdministrador == this._senhaAdministrador)
            {
                Usuario novoUsuario = new Usuario(nomeUsuario, senhaUsuario);
                _usuarios.Add(novoUsuario);
                return true;
            }
            return false;
        }

        public bool CadastraEmprestimo(Usuario credor, Usuario devedor, DateTime data, double valor, 
            string senhaDevedor)
        {
            if(devedor.Senha == senhaDevedor)
            {
                Emprestimo novoEmprestimo = new Emprestimo(credor, devedor, data, valor);
                _emprestimos.Add(novoEmprestimo);
                return true;
            }
            return false;
        }

        public bool QuitarEmprestimo(Emprestimo emprestimoSelecionado, string senhaCredor)
        {
            if (emprestimoSelecionado.Credor.Senha == senhaCredor)
            {
                _emprestimos.Remove(emprestimoSelecionado);
                return true;
            }
            return false;
        }

        public List<Emprestimo> ObterEmprestimosEntre(string nomeCredor, string nomeDevedor)
        {
            return _emprestimos.Where(emprestimo => emprestimo.Credor.Nome == nomeCredor &&
                                                    emprestimo.Devedor.Nome == nomeDevedor).ToList();
        }

        public List<Emprestimo> ObterEmprestimosUsuario(string nomeUsuario)
        {
            return _emprestimos.Where(emprestimo => emprestimo.Credor.Nome == nomeUsuario ||
                                                    emprestimo.Devedor.Nome == nomeUsuario)
                               .OrderBy(emprestimo => emprestimo.Data)
                               .ToList();
        }

        public bool AlterarTaxas(double novaTaxaDiaria, double novaTaxaMensal, string senhaAdministrador)
        {
            if (senhaAdministrador == this._senhaAdministrador)
            {
                TaxaDiaria = novaTaxaDiaria;
                TaxaMensal = novaTaxaMensal;
                return true;
            }
            return false;
        }

        public bool ExcluirUsuario(string nomeUsuario, string senhaAdministrador)
        {
            if (senhaAdministrador == this._senhaAdministrador)
            {
                Usuario usuario = GetUsuarioPorNome(nomeUsuario);
                _usuarios.Remove(usuario);
                return true;
            }
            return false;
        }

        public bool ResetarSenhaUsuario(string nomeUsuario, string novaSenhaUsuario, string senhaAdministrador)
        {
            if (senhaAdministrador == this._senhaAdministrador)
            {
                Usuario usuario = GetUsuarioPorNome(nomeUsuario);
                usuario.Senha = novaSenhaUsuario;
                return true;
            }
            return false;
        }

        public bool AlterarSenhaUsuario(string nomeUsuario, string senhaUsuario, string novaSenhaUsuario)
        {
            Usuario usuario = GetUsuarioPorNome(nomeUsuario);
            if (senhaUsuario == usuario.Senha)
            {
                usuario.Senha = novaSenhaUsuario;
                return true;
            }
            return false;
        }

        public bool VerificarUsuarioExistente(string nome)
        {
            return _usuarios.Exists(usuario => usuario.Nome == nome);
        }

        public Usuario GetUsuarioPorNome(string nome)
        {
            return _usuarios.FirstOrDefault(usuario => usuario.Nome == nome);
        }
    }
}
