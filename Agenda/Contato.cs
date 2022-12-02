using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//CLASSE RESPONSAVEL PELO ARQUIVO JSON
namespace Agenda
{
   public class Contato
    {
        
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string dataNascimento { get; set; }



		//METODOS CONSTRUTORES
        public Contato()
        {
			

		}
	
    }
}
