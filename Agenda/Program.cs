using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Text.RegularExpressions;
/*
 * GRUPO
 * CAIO EDUARDO FUREGATI DE MATOS
 * VICTOR AIELLO
 * VICTOR BUQUERA
*/
namespace Agenda
{
	public class Program
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
			
	
			

			//MENU PRINCIPAL
			while (menu)
			{
				
				Console.WriteLine("1- Adicionar novo contato  \n2- Listar contatos\n3- Encerrar");
				

				while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 3)
				{
					Console.Clear();
					Console.WriteLine("###########################");
					Console.WriteLine("Digite uma opção valida!");
					Console.WriteLine("###########################\n");
					Console.WriteLine("1- Adicionar novo contato  \n2- Listar contatos\n3- Encerrar");
					
				}

				switch (escolha)
				{
					//ADICIONAR NOVO CONTATO
					case 1:
						Console.Clear();
						Contato contatoAtual = new Contato();

						Console.WriteLine("Nome do contato:");
						contatoAtual.nome = Console.ReadLine();


						//TELEFONE <----
						Console.WriteLine("Telefone: ");
						contatoAtual.InsereTelefone();
				

						//DATA DE NASCIMENTO <-----
						Console.WriteLine("Deseja salvar a data de nacimento? 1 - Sim 2 - Não");
						int dtNascEscolha;

						while(!int.TryParse(Console.ReadLine(), out dtNascEscolha) || dtNascEscolha < 1 || dtNascEscolha > 2 )
						{
							Console.WriteLine("Escolha uma opção valida numero 1 ou 2");
						}

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

							//VALIDANDO SE É UMA OPÇÃO VALIDA
							while(!int.TryParse(Console.ReadLine(),out opcaoListaContatos) || opcaoListaContatos < 1 || opcaoListaContatos > 3)
							{
								Console.WriteLine("Escolha uma opcao valida: 1, 2 ou 3");
							}
							
							switch (opcaoListaContatos)
							{
								//VISUALIZAR CONTATO
								case 1:
									//MOSTRA DADOS
									Console.Write("ID do contato para visualizar: ");


									int idContato;
								
									while(!int.TryParse(Console.ReadLine(), out idContato) || idContato < 0 || idContato > ListaContatos.Count-1)
									{
										Console.WriteLine("Digite um id valido de 0 a {0}", ListaContatos.Count - 1);
									}

									
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

									//OPÇÕES
									//int opcaoVisualizaContato;
									Console.WriteLine("---------------------------------------------------------------");
									Console.WriteLine("1 - Editar nome\n2 - Editar data de nascimento");
									Console.WriteLine("3 - Editar um numero de telefone\n4 - Exluir um numero de telefone");
									Console.WriteLine("5 - Adicionar um numero de telefone\n6 - Voltar ao menu principal");
									Console.WriteLine("---------------------------------------------------------------");
									

									while (!int.TryParse(Console.ReadLine(), out opcaoListaContatos) || opcaoListaContatos <=0 || opcaoListaContatos > 6)
									{
										Console.WriteLine(opcaoListaContatos);
										Console.WriteLine("Digite uma opção valida!");
									}

									//SWITCH PARA OPÇÕES DE EDIÇÃO
									switch (opcaoListaContatos)
									{
										//EDITAR NOME
										case 1:
											Console.WriteLine("Nome atual: "+ ListaContatos[idContato].nome);
											Console.WriteLine("Qual novo nome: ");
											string novoNome = Console.ReadLine();
											ListaContatos[idContato].nome = novoNome;
											Console.WriteLine("Nome alterado para {0}", novoNome);
											Console.WriteLine("###########################");
											Console.WriteLine("Pressione ENTER para continuar");
											Console.ReadLine();
											Arquivo.CriaArquivo(ListaContatos);
											
											break;
										//EDITAR DATA DE NASCIMENTO
										case 2:
											Console.WriteLine("Digite a nova data de nascimento:");

											//VERIFICANDO SE DATA ESTA NO FORMATO CERTO
											DateTime data = new DateTime();
											string dataDigitada = Console.ReadLine();
											bool verificaDataDigitada = DateTime.TryParse(dataDigitada, out data);

											while (!verificaDataDigitada)
											{
												Console.WriteLine("Formato invalido, digite uma data no formato dd/mm/yyyy:");
												dataDigitada = Console.ReadLine();
												verificaDataDigitada = DateTime.TryParse(dataDigitada, out data);
											}

											//ALTERANDO
											ListaContatos[idContato].dataNascimento = dataDigitada;
											Arquivo.CriaArquivo(ListaContatos);

											Console.WriteLine("Data de nascimento alterado para {0} com sucesso!", dataDigitada);
											Console.WriteLine("###########################");
											Console.WriteLine("Pressione ENTER para continuar");
											Console.ReadLine();

											break;
										//EDITAR UM NUMERO		
										case 3:
											
											Console.WriteLine("###########################");
											int idTelEscolhido;

											Contato.MostraTelefonesContato(ListaContatos, idContato);
											
											Console.WriteLine("###########################");
											Console.Write("Qual numero deseja editar: ");
											
											
										
											//VERIFICA SE É UM NUMERO E SE É VALIDO
											while (!int.TryParse(Console.ReadLine(), out idTelEscolhido) || idTelEscolhido <= 0 || idTelEscolhido > ListaContatos[idContato].telefone.Count())
											{
												Console.WriteLine("Digita uma opção valida!");
											}

											
											Console.WriteLine("Numero atual: "+ ListaContatos[idContato].telefone[idTelEscolhido-1].ToString());
											Console.Write("Novo numero: ");
									
											Int64 telefoneDigitado;
										

											while (!Int64.TryParse(Console.ReadLine(), out telefoneDigitado) || telefoneDigitado.ToString().Length < 9)
											{
												Console.WriteLine(telefoneDigitado.ToString().Length);
												Console.WriteLine("Você tem que digitar o telefone valido!");
												
											}
											ListaContatos[idContato].telefone[idTelEscolhido-1] = telefoneDigitado.ToString();
											Arquivo.CriaArquivo(ListaContatos);

											Console.WriteLine("Telefone alterado para {0} com sucesso!", telefoneDigitado.ToString());
											Console.WriteLine("###########################");
											Console.WriteLine("Pressione ENTER para continuar");
											Console.ReadLine();


											break;
										//EXCLUIR UM NUMERO DE TELEFONE	
										case 4:

											//VERIFICA SE PODE EXLUIR (SE TEM MAIS DE UM NUMERO DE TELEFONE
											if (ListaContatos[idContato].telefone.Count() > 1) 
											{
												Contato.MostraTelefonesContato(ListaContatos, idContato);

											Console.WriteLine("###########################");
											Console.Write("Qual numero deseja excluir: ");

												int idTelEx;
												//VERIFICA SE É UM NUMERO E SE É VALIDO
												while (!int.TryParse(Console.ReadLine(), out idTelEx) || idTelEx <= 0 || idTelEx > ListaContatos[idContato].telefone.Count())
												{
													Console.WriteLine("Digita uma opção valida!");
												}

												ListaContatos[idContato].telefone.Remove(ListaContatos[idContato].telefone[idTelEx - 1]);
												Arquivo.CriaArquivo(ListaContatos);
											}
											else
											{
												Console.Clear();
												Console.WriteLine("VOCÊ NÃO PODE EXCLUIR ESSE TELEFONE , PRICISA TER PELO MENOS UM NUMERO !");
												Console.WriteLine("###########################");
												Console.WriteLine("Pressione ENTER para continuar");
												Console.ReadLine();
											}
											
											break;
										//ADICIONAR UM NUMERO DE TELEFONE		
										case 5:
											Console.WriteLine("Digite o numero que deseja adicionar:");

											Int64 novoTelefone;
											while (!Int64.TryParse(Console.ReadLine(), out novoTelefone) || novoTelefone.ToString().Length < 9)
											{

												Console.WriteLine("Você tem que digitar o telefone valido!");

											}
											ListaContatos[idContato].telefone.Add(novoTelefone.ToString());
											Arquivo.CriaArquivo(ListaContatos);
											break;
										//VOLTAR AO MENU PRINCIPAL	
										case 6:

											break;
										default:
											
											break;

									}
									Console.Clear();
									break;
								//REMOVER CONTATO
								case 2:
									Console.WriteLine("Digite o id para remover\n");
									//VERIFICA SE ID EXISTE E REMOVE
									int idEscolhido;

									while(!int.TryParse(Console.ReadLine(), out idEscolhido) || idEscolhido < 0 || idEscolhido > ListaContatos.Count -1)
									{
										Console.WriteLine("Digite um  id valido entre 0 e {0}", ListaContatos.Count -1);
									}

										//Remove do arquivo
										Arquivo.RemoveContato(idEscolhido);
										//Remove da lista
										ListaContatos.Remove(ListaContatos[idEscolhido]);
							

									break;
									case 3:
										Console.Clear();
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
						
						break;


				}
			}

		}
	}
}