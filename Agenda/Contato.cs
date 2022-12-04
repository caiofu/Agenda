﻿using Newtonsoft.Json;
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
			
			bool verificaDataDigitada = DateTime.TryParse(dataDigitada, out data);

			while (!verificaDataDigitada)
			{
				Console.WriteLine("Formato invalido, digite uma data no formato dd/mm/yyyy:");
				dataDigitada = Console.ReadLine();
				verificaDataDigitada = DateTime.TryParse(dataDigitada, out data);
			}

			this.dataNascimento = dataDigitada;
		}

		public void InsereTelefone()
		{

			Int64 telefoneDigitado;
			bool verificaTelefone = Int64.TryParse(Console.ReadLine(), out telefoneDigitado);
			
			while (!verificaTelefone || telefoneDigitado.ToString().Length < 9)
			{
				Console.WriteLine(telefoneDigitado);
				Console.WriteLine("Você tem que digitar o telefone valido!");
				verificaTelefone = Int64.TryParse(Console.ReadLine(), out telefoneDigitado);
			}
			this.telefone.Add(telefoneDigitado.ToString());

		}

	}
}
