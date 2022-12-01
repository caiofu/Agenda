using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
   public class Contato
    {
        
        public string nome { get; set; }
        public string telefone { get; set; }
        public string dataNascimento { get; set; }

        public static string caminhoArquivo = "agenda.json";


		//METODOS CONSTRUTORES
        public Contato()
        {
			

		}
	
		//METODOS

		public static void CriaArquivo(List<Contato> ListaContatos)
        {
			
			string json = JsonConvert.SerializeObject(ListaContatos, Formatting.Indented); //Formatting.Indented para ficar organizado
			File.WriteAllText(caminhoArquivo, json);
		}

        //METODO RESPONSAVEL POR CARREGAR DADOS DO ARQUIVO JSON SE ELE EXISTIR E POPULAR LISTA.
        public List<Contato> CarregaArquivo()
        {
			List<Contato> ListaJson = new List<Contato>();
			//Verifica se existe o arquivo
			if (File.Exists(caminhoArquivo))
			{
                
				//Carrega os contatos
				dynamic objJson = JsonConvert.DeserializeObject(File.ReadAllText(caminhoArquivo));

                ListaJson.Add(objJson);
                
			}

            return ListaJson;
		}

        public static void RemoveContato( int idContato)
		{
			dynamic objJson = JsonConvert.DeserializeObject(File.ReadAllText(Contato.caminhoArquivo));
			//Remove o contato
			objJson.RemoveAt(idContato);
	
			//Remonta o arquivo json
			File.WriteAllText(caminhoArquivo, JsonConvert.SerializeObject(objJson, Formatting.Indented));
		
		}
    }
}
