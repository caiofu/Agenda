using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
	public static class Arquivo
	{
		public static string caminhoArquivo = "agenda.json";

		//METODOS
		public static void CriaArquivo(List<Contato> ListaContatos)
		{
			string json = JsonConvert.SerializeObject(ListaContatos, Formatting.Indented); //Formatting.Indented para ficar organizado
			File.WriteAllText(caminhoArquivo, json);
		}

		public static void RemoveContato(int idContato)
		{
			dynamic objJson = JsonConvert.DeserializeObject(File.ReadAllText(caminhoArquivo));
			//Remove o contato
			objJson.RemoveAt(idContato);

			//PRECISA AINDA REMOVER DA LISTA TAMBEM

			//Remonta o arquivo json
			File.WriteAllText(caminhoArquivo, JsonConvert.SerializeObject(objJson, Formatting.Indented));
		}

		
	}
}
