using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;
using System.Linq;
//ATENÇAO VERIFICAR MUDANÇA PARA INSERIR NO FINAL
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

			//CARREGANDO DADOS PARA LISTA DO ARQUIVO JSON
			dynamic objJsonCarrega = JsonConvert.DeserializeObject(File.ReadAllText(Arquivo.caminhoArquivo));
			
			if (File.Exists(Arquivo.caminhoArquivo) && objJsonCarrega.Count > 0 )
			{
				
				
				foreach (var item in objJsonCarrega)
				{

					Contato configuraContato = new Contato();
					configuraContato.id= idJson;
					configuraContato.nome = item.nome;
					configuraContato.telefone = item.telefone;
					configuraContato.dataNascimento = item.dataNascimento;

					ListaContatos.Add(configuraContato);
					idJson++;
				}
				Arquivo.CriaArquivo(ListaContatos);

			}
		

			while (menu)
			{
				//Console.Clear();
				Console.WriteLine("1- Adicionar novo contato  \n2- Listar contatos\n3- Encerrar");
				escolha = Int32.Parse(Console.ReadLine());

				switch (escolha)
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

						contatoAtual.id = idJson;
						idJson++;

						//PASSA PARA LISTA O OBJETO
						ListaContatos.Add(contatoAtual);



						Arquivo.CriaArquivo(ListaContatos);
						break;

					//LISTAR CONTATOS
					case 2:
						int opcaoListaContatos;
						//VERIFICA SE O ARQUIVO EXISTE
						if (objJsonCarrega.Count == 0 || File.Exists(Arquivo.caminhoArquivo) == false)
						{
							Console.WriteLine("Voce ainda nao tem nenhum contato");
							Console.ReadLine();
						}
						else
						{
							Console.Clear();
							//ORDENANDO A LISTA PELO NOME
							IEnumerable<Contato> listaOrdenada = ListaContatos.OrderBy(c => c.nome);

							//CARREGA OS CONTATOS A PARTIR DA LISTA
							int contador = 1;

							//Sugestão criar um campo no json "quantidadeTelefone" para salvar quantos numeros tem
							//para poder usar o foreach para percorrer.
							foreach (var item in listaOrdenada)
							{
								
								Console.WriteLine("---------------------------------------------------------------");
								Console.WriteLine(" \nNome: " + item.nome + "\nID: " + contador);
								Console.WriteLine("---------------------------------------------------------------\n");
								contador++;
							}

							//
							Console.WriteLine("1 - Visualizar contato \n2 - Exluir contato\n3 - Voltar ao menu principal\n");
							Console.Write(":");
							opcaoListaContatos = Int32.Parse(Console.ReadLine());
							switch (opcaoListaContatos)
							{
								//VISUALIZAR CONTATO
								case 1:
									//MOSTRA DADOS
									Console.Write("ID do contato para visualizar: ");
									int idContato = Int32.Parse(Console.ReadLine());
									if(idContato >0 && idContato <= ListaContatos.Count)
									{
										Console.WriteLine("Nome: "+ListaContatos[idContato-1].nome);
										Console.WriteLine("Data de nascimento: " + ListaContatos[idContato-1].dataNascimento);
									}
									//OPÇÕES
									int opcaoVisualizaContato;
									Console.WriteLine("---------------------------------------------------------------");
									Console.WriteLine("1 - Editar nome\n2 - Editar data de nascimento");
									Console.WriteLine("3 - Editar um numero de telefone\n4 - Exluir um numero de telefone");
									Console.WriteLine("5 - Adicionar um numero de telegone\n");
									Console.WriteLine("---------------------------------------------------------------");
									opcaoListaContatos = Int32.Parse( Console.ReadLine());

									//SWITCH PARA OPÇÕES DE EDIÇÃO
									switch(opcaoListaContatos)
									{
										case 1:

										break;
										case 2:

										break;
										case 3:

										break;
									}

									break;
								//REMOVER CONTATO
								case 2:
									Console.WriteLine("Digite o id para remover\n");
									//VERIFICA SE ID EXISTE E REMOVE
									int idEscolhido = Int32.Parse(Console.ReadLine());
									if (idEscolhido >= 0 && idEscolhido <= contador)
									{
										//Remove do arquivo
										Arquivo.RemoveContato(idEscolhido);
										//Remove da lista
										//ListaContatos.Remove(Contato[])
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


				}
			}

		}
	}
}