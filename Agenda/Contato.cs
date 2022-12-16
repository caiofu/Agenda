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
       // public string telefone { get; set; }
        public string dataNascimento { get; set; }

        public List<String> telefone = new List<String>();
     

		//METODOS CONSTRUTORES
		public Contato()
        {
			

		}

        //METODOS

		//METODO QUE VERIFICA E INSERE DATA NO FORMATO CORRETO
        public void InsereDataNascimento(string dataDigitada)
        {
			
			//VERIFICA SE DATA ESTA NO FORMATO CORRETO
			DateTime data = new DateTime();
			
			//bool verificaDataDigitada = DateTime.TryParse(dataDigitada, out data);

			while (!DateTime.TryParse(dataDigitada, out data))
			{
				Console.WriteLine("Formato invalido, digite uma data no formato dd/mm/yyyy:");
				dataDigitada = Console.ReadLine();
				//verificaDataDigitada = DateTime.TryParse(dataDigitada, out data);
			}

			this.dataNascimento = dataDigitada;
			
		}

		

		public void InsereTelefone()
		{

			Int64 telefoneDigitado;
		
			
			while (!Int64.TryParse(Console.ReadLine(), out telefoneDigitado) || telefoneDigitado.ToString().Length < 9)
			{
				
				Console.WriteLine("Você tem que digitar o telefone valido!");
				
			}
			this.telefone.Add(telefoneDigitado.ToString());

		}

		public static void MostraContatos(List<Contato> ListaContatos)
		{
			//ORDENANDO A LISTA PELO NOME
			IEnumerable<Contato> listaOrdenada = ListaContatos.OrderBy(c => c.nome);

			
			foreach (var item in listaOrdenada)
			{

				Console.WriteLine("---------------------------------------------------------------");
				Console.WriteLine("Contato N°: " + item.id + "\nNome: " + item.nome);
				Console.WriteLine("---------------------------------------------------------------\n");

			}
		}

		//EXIBI TELEFONE DE CONTATO ESPECIFICO
		public static void MostraTelefonesContato(List<Contato> ListaContatos, int idContato)
		{
			int idTel = 1;
			foreach (var telefones in ListaContatos[idContato].telefone)
			{
				Console.WriteLine(idTel + " -> " + telefones);
				idTel++;
			}
		}

	}
}
