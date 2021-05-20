using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeEmprestimos.Model
{
    public class Usuario
    {
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;

        public Usuario(string nome, string senha)
        {
            Nome = nome;
            Senha = senha;
        }

        private Teste()
        {
            //Conteúdo novo
        }
    }
}
