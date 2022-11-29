using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    internal class Contato
    {
        int id;
        public string Nome { get; set; }
        public string Telefone { get; set; }
        DateTime? dataNascimento { get; set; }


        //METODOS CONSTRUTORES
        public Contato(string nome, string telefone, DateTime dataNascimento)
        {

            this.Nome = nome;
            this.Telefone = telefone;
        }

        public Contato(string nome, string telefone)
        {
            this.Nome = nome;
            this.Telefone = telefone;
        }

        //METODOS
        private void CriarContato()
        {

        }
    }
}
