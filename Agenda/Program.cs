using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
using System.Linq;
//ATENÇAO VERIFICAR MUDANÇA PARA INSERIR  TELEFONE
//https://www.newtonsoft.com/json/help/html/ModifyJson.htm
namespace Agenda
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Menu
			Boolean menu = true;
			int escolha, idJson=0;

			List<Contato> ListaContatos = new List<Contato>();

			//CRIA O ARQUIVO CASO NAO EXISTA
			if(File.Exists(Arquivo.caminhoArquivo) == false)
			{
				Arquivo.CriaArquivo(ListaContatos);
			}

			//CARREGANDO DADOS DO ARQUIVO JSON PARA LISTA CASO TENHA DADOS
			dynamic objJsonCarrega = JsonConvert.DeserializeObject(File.ReadAllText(Arquivo.caminhoArquivo));
			
			if (File.Exists(Arquivo.caminhoArquivo) && objJsonCarrega.Count > 0 )
			{
				
				foreach (var item in objJsonCarrega)
				{

					Contato configuraContato = new Contato();
					configuraContato.id= idJson;
					configuraContato.nome = item.nome;
					configuraContato.dataNascimento = item.dataNascimento;

					//Loop para adicionar os telefone
					foreach (var tel in item.telefone)
					{
						configuraContato.telefone.Add(tel.ToString());
					}

					ListaContatos.Add(configuraContato);
					idJson++;
				}

				Arquivo.CriaArquivo(ListaContatos);
			}
			
	
			


			while (menu)
			{
				Console.Clear();
				Console.WriteLine("1- Adicionar novo contato  \n2- Listar contatos\n3- Encerrar");
				escolha = Int32.Parse(Console.ReadLine());

				switch (escolha)
				{
					//ADICIONAR NOVO CONTATO
					case 1:
						Contato contatoAtual = new Contato();

						Console.WriteLine("Nome do contato:");
						contatoAtual.nome = Console.ReadLine();


						//TELEFONE <----
						Console.WriteLine("Telefone: ");
						contatoAtual.InsereTelefone();
				

						//DATA DE NASCIMENTO <-----
						Console.WriteLine("Deseja salvar a data de nacimento? 1 -Sim ");
						int dtNascEscolha = int.Parse(Console.ReadLine());

						if(dtNascEscolha == 1)
						{
							Console.WriteLine("Data de nascimento (Opcional) - DD/MM/YYYY : ");
							string dataDigitada = Console.ReadLine();
							contatoAtual.InsereDataNascimento(dataDigitada);
						}
						else
						{
							Console.WriteLine("Você optou por nao inserir a data de nascimento!");
							Console.WriteLine("Pressione ENTER para continuar!");
							Console.ReadLine();
						}
						
					
						contatoAtual.id = idJson;
						idJson++;

						//PASSA PARA LISTA O OBJETO
						ListaContatos.Add(contatoAtual);

						Arquivo.CriaArquivo(ListaContatos);
						Console.Clear();
						break;

					//LISTAR CONTATOS
					case 2:
						int opcaoListaContatos;
						//VERIFICA SE O ARQUIVO EXISTE
						if (ListaContatos.Count == 0 )
						{
							Console.WriteLine("Voce ainda nao tem nenhum contato \nPressione ENTER para continuar ");
							Console.ReadLine();
						}
						else
						{
							Console.Clear();
							Contato.MostraContatos(ListaContatos);

							//
							Console.WriteLine("###########################");
							Console.WriteLine("1 - Visualizar contato \n2 - Exluir contato\n3 - Voltar ao menu principal\n");
							Console.WriteLine("###########################");
							Console.Write(":");

							opcaoListaContatos = Int32.Parse(Console.ReadLine());
							switch (opcaoListaContatos)
							{
								//VISUALIZAR CONTATO
								case 1:
									//MOSTRA DADOS
									Console.Write("ID do contato para visualizar: ");
									int idContato = Int32.Parse(Console.ReadLine());
									if(idContato >=0 && idContato <= ListaContatos.Count)
									{
										Console.Clear() ;
										Console.WriteLine("###########################");
										Console.WriteLine("Nome: "+ListaContatos[idContato].nome);

										if (ListaContatos[idContato].dataNascimento != null)
										{
											Console.WriteLine("Data de nascimento: " + ListaContatos[idContato].dataNascimento);
										}
										else
										{
											Console.WriteLine("Data de nascimento: Não informada!");
										}
										
										//Mostra todos telefones
										foreach (var telefones in ListaContatos[idContato].telefone)
										{
											Console.WriteLine("Telefone:"+telefones);
										}
										Console.WriteLine("###########################");

									}
									//OPÇÕES
									int opcaoVisualizaContato;
									Console.WriteLine("---------------------------------------------------------------");
									Console.WriteLine("1 - Editar nome\n2 - Editar data de nascimento");
									Console.WriteLine("3 - Editar um numero de telefone\n4 - Exluir um numero de telefone");
									Console.WriteLine("5 - Adicionar um numero de telefone\n");
									Console.WriteLine("---------------------------------------------------------------");
									opcaoListaContatos = Int32.Parse( Console.ReadLine());

									//SWITCH PARA OPÇÕES DE EDIÇÃO
									switch(opcaoListaContatos)
									{
										//EDITAR NOME
										case 1:
											Console.WriteLine("Nome atual: "+ ListaContatos[idContato].nome);
											Console.WriteLine("Qual novo nome: ");
											string novoNome = Console.ReadLine();
											//if(novoNome )
											break;
										//EDITAR DATA DE NASCIMENTO
										case 2:

											break;
										//EDITAR UM NUMERO		
										case 3:

											break;
										//EXCLUIR UM NUMERO DE TELEFONE	
										case 4:

											break;
										//ADICIONAR UM NUMERO DE TELEFONE		
										case 5:

											break;
										//VOLTAR AO MENU PRINCIPAL	
										case 6:

											break;
										default:
											Console.WriteLine("DIGITE UMA OPCAO VALIDA!");
											break;

									}

									break;
								//REMOVER CONTATO
								case 2:
									Console.WriteLine("Digite o id para remover\n");
									//VERIFICA SE ID EXISTE E REMOVE
									int idEscolhido = Int32.Parse(Console.ReadLine());
									if (idEscolhido >= 0 && idEscolhido <= ListaContatos.Count-1)
									{
										//Remove do arquivo
										Arquivo.RemoveContato(idEscolhido);
										//Remove da lista
										ListaContatos.Remove(ListaContatos[0]);
										
									}
									else
									{
										Console.WriteLine("ID ESCOLHIDO NAO EXISTE!");
										Console.Read(); //USANDO SÓ PARA NAO LIMPAR A TELA ENQUANTO USUARIO NAO DIGITAR ALGO
									}


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

						default: 
						Console.Clear();
						Console.WriteLine("###########################");
						Console.WriteLine("Digite uma opção valida!");
						Console.WriteLine("###########################\n");
						break;


				}
			}

		}
	}
}