using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu ->
            Boolean menu = true;
            int escolha;
           // String caminhoArquivo = "teste3.json";
			List<Contato> ListaContatos = new List<Contato>();

			//CARREGANDO DADOS PARA LISTA DO ARQUIVO JSON
			if (File.Exists(Contato.caminhoArquivo))
            {
				dynamic objJsonCarrega = JsonConvert.DeserializeObject(File.ReadAllText(Contato.caminhoArquivo));

				foreach (var item in objJsonCarrega)
				{
                   
					Contato configuraContato = new Contato();
					configuraContato.nome = item.nome;
					configuraContato.telefone = item.telefone;
					configuraContato.dataNascimento = item.dataNascimento;

					ListaContatos.Add(configuraContato);
					
				}
				Contato.CriaArquivo(ListaContatos);

			}
				

			while (menu)
            {
				Console.Clear();
				Console.WriteLine("1- Adicionar novo contato  \n2- Listar contatos\n3- Encerrar");
                escolha = Int32.Parse(Console.ReadLine());

                switch(escolha)
                {
                    //ADICIONAR NOVO CONTATO
                    case 1:
						Contato contatoAtual = new Contato();

						Console.WriteLine("Nome do contato:");
                        contatoAtual.nome = Console.ReadLine();

                        
                        Console.WriteLine("Telefone: ");
                        contatoAtual.telefone = Console.ReadLine();


                        Console.WriteLine("Data de nascimento (Opcional): ");
                        contatoAtual.dataNascimento = Console.ReadLine();
                 
                        //PASSA PARA LISTA O OBJETO
                        ListaContatos.Add(contatoAtual);

                        
                       
                        Contato.CriaArquivo(ListaContatos);
						break;
                    
                    //LISTAR CONTATOS
                    case 2:
                        int opcaoListaContatos;
                        //VERIFICA SE O ARQUIVO EXISTE
						if (ListaContatos.Count == 0 && File.Exists(Contato.caminhoArquivo) == false)
                        {
                            Console.WriteLine("Voce ainda nao tem nenhum contato");
                            Console.ReadLine();
                        }else
                        {
                            Console.Clear();
                            //ORDENANDO A LISTA PELO NOME
                            IEnumerable<Contato> listaOrdenada = ListaContatos.OrderBy(c => c.nome);

							//CARREGA OS CONTATOS A PARTIR DA LISTA
							int contador = 1;
							foreach (var item in listaOrdenada)
							{
								Console.WriteLine("---------------------------------------------------------------");
								Console.WriteLine(" \nNome: " + item.nome +"\nID: " + contador );
								Console.WriteLine("---------------------------------------------------------------\n");
								contador++;
							}

                            //
                            Console.WriteLine("1 - Visualizar contato \n2 - Exluir contato\n3 - Voltar ao menu principal\n");
                            Console.Write(":");
                            opcaoListaContatos = Int32.Parse(Console.ReadLine());
                            switch (opcaoListaContatos)
                            {
                                case 1:
                                    Console.WriteLine("visualizando");
                                    break;
                                case 2:

                                    break;
                                default:
                                    break;
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