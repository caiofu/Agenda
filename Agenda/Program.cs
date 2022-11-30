using System;
using System.Text.Json;
namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu ->
            Boolean menu = true;
            int escolha;
			List<Contato> ListaContatos = new List<Contato>();
		
			while (menu)
            {
                Console.WriteLine("1- Adicionar novo contato  \n2- Listar contatos\n3- Encerrar");
                escolha = Int32.Parse(Console.ReadLine());

                switch(escolha)
                {
                    //ADICIONAR NOVO CONTATO
                    case 1:
						Contato contatoAtual = new Contato();

						Console.WriteLine("Nome do contato:");
                        contatoAtual.Nome = Console.ReadLine();

                        
                        Console.WriteLine("Telefone: ");
                        contatoAtual.Telefone = Console.ReadLine();


                        Console.WriteLine("Data de nascimento (Opcional): ");
                        contatoAtual.dataNascimento = Console.ReadLine();
                 
                        ListaContatos.Add(contatoAtual);

                        break;
                    
                    //LISTAR CONTATOS
                    case 2:
                        //Verifica se ja tem algum contato salvo

                        // dynamic tes = Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText("teste.json"));
                        string stringJson = File.ReadAllText("teste.json");
                        Contato testecon = JsonSerializer.Deserialize<Contato>(stringJson);
						/*,
                         System.Text.Json.JsonException: 'The JSON value could not be converted to Agenda.Contato. Path: $ 
                        | LineNumber: 0 | BytePositionInLine: 1.'
*/


						Console.WriteLine(stringJson);
                        
						if (ListaContatos.Count == 0)
                        {
                            Console.WriteLine("Voce ainda nao tem nenhum contato");
                        }else
                        {
                            //Carrega a lista salva no disco

                            //
                            foreach (var contato in ListaContatos)
                            {
                                Console.WriteLine("Nome: {0} Telefone: {1} Data de nascimento: {2}", contato.Nome, contato.Telefone, contato.dataNascimento);
                            }
                        }
                       
                    break;
                    
                    //ENCERRAR 
                    case 3:
						//Criando o arquivo json
						string json = Newtonsoft.Json.JsonConvert.SerializeObject(ListaContatos);
						File.WriteAllText("teste.json", json);

						menu = false;
                      break;
                }
            }
            /*
            List<Contato> ListaContatos = new List<Contato>();
            ListaContatos.Add(new Contato(Console.ReadLine(), Console.ReadLine()));

            foreach (var Contato in ListaContatos)
            {
                Console.WriteLine("Nome: {0} Telefone: {1}", Contato.Nome, Contato.Telefone);
                

            }
            */
        }
    }
}