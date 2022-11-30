using System;

namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu ->
            Boolean menu = true;
            int escolha;
            String caminhoArquivo = "teste3.json";
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
                 
                        //PASSA PARA LISTA TODOS OS CAMPOS
                        ListaContatos.Add(contatoAtual);

                        //Criando o arquivo json
                        //string json = Newtonsoft.Json.JsonConvert.SerializeObject(ListaContatos);
                        //File.WriteAllText(caminhoArquivo, json);
                        contatoAtual.CriaArquivo(ListaContatos);
						break;
                    
                    //LISTAR CONTATOS
                    case 2:
                        //VERIFICA SE O ARQUIVO EXISTE
						if (ListaContatos.Count == 0 && File.Exists(caminhoArquivo) == false)
                        {
                            Console.WriteLine("Voce ainda nao tem nenhum contato");
                        }else
                        {
                            //CARREGA OS CONTATOS
							dynamic objJson = Newtonsoft.Json.JsonConvert.DeserializeObject(File.ReadAllText(caminhoArquivo));



							int contador = 1;
							foreach (var item in objJson)
							{
								Console.WriteLine("---------------------------------------------------------------");
								Console.WriteLine("ID: " + contador + " \nNome: " + item.Nome + "\nTelefone: " + item.Telefone + "\nData de Nascimento: " + item.dataNascimento);
								Console.WriteLine("---------------------------------------------------------------\n");
								contador++;

							}
						}
                       
                    break;
                    
                    //ENCERRAR 
                    case 3:
						

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