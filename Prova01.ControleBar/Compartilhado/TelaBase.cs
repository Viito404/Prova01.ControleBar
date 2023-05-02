using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Compartilhado
{
     internal abstract class TelaBase
     {
          //Formatação para título e sufixo relacionado(s).
          public string nomeEntidade, sufixo;

          //Passagem do repositorioBase para pegar seus métodos e atributos. 
          protected RepositorioBase repositorioBase = null;

          public void ImprimirMensagem(string mensagem, ConsoleColor cor, char pausa)
          {
               Console.ForegroundColor = cor;
               Console.WriteLine(mensagem);
               Console.ResetColor();

               if (pausa == 's')
                    Console.ReadLine();
          }

          public virtual string ExibirMenuOpcoes()
          {
               Console.Clear();
               Console.WriteLine($"| {nomeEntidade}{sufixo} |");
               ImprimirMensagem("\n[1] CRIAR;\n[2] VISUALIZAR;\n[3] ATUALIZAR;\n[4] REMOVER;\n[0] SAIR.", ConsoleColor.Blue, 'n');
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }

          public virtual void InserirNovoRegistro()
          {
               Console.Clear();
               ImprimirMensagem($"Inserindo {nomeEntidade}...\n", ConsoleColor.DarkGray, 'n');

               EntidadeBase registro = ObterRegistro();
               ArrayList listaErros = registro.ValidarErros();

               if (listaErros.Count > 0)
               {
                    foreach (String entidade in listaErros)
                         ImprimirMensagem(entidade, ConsoleColor.Red, 's');

                    InserirNovoRegistro();
                    return;
               }

               repositorioBase.Inserir(registro);

               ImprimirMensagem($"\n{nomeEntidade} inserida com sucesso!", ConsoleColor.Green, 's');
          }

          public virtual bool VisualizarRegistros(bool mostrarCabecalho)
          {
               bool visualizando = false;

               if (mostrarCabecalho)
               {
                    Console.Clear();
                    ImprimirMensagem($"Visualizando {nomeEntidade}{sufixo}...\n", ConsoleColor.DarkGray, 'n');
                    visualizando = true;
               }

               ArrayList registros = repositorioBase.PegarLista();

               if (registros.Count == 0)
               {
                    ImprimirMensagem("\nNenhum registro cadastrado!", ConsoleColor.DarkYellow, 's');
                    return false;
               }

               MostrarTabela(registros);

               if (visualizando)
                    Console.ReadLine();

               return true;
          }

          public virtual void EditarRegistro()
          {
               Console.Clear();
               ImprimirMensagem($"Editando {nomeEntidade}{sufixo}...\n", ConsoleColor.DarkGray, 'n');

               bool temRegistros = VisualizarRegistros(false);

               if (!temRegistros)
                    return;

               Console.WriteLine();

               int id = EncontrarId();

               Console.WriteLine();
               EntidadeBase registroAtualizado = ObterRegistro();
               ArrayList listaErros = registroAtualizado.ValidarErros();

               if (listaErros.Count > 0)
               {
                    foreach (String entidade in listaErros)
                         ImprimirMensagem(entidade, ConsoleColor.Red, 's');

                    EditarRegistro();
                    return;
               }

               repositorioBase.Editar(registroAtualizado, id);

               ImprimirMensagem("\nRegistro editado com sucesso!", ConsoleColor.Green, 's');
          }

          public virtual void ExcluirRegistro()
          {
               Console.Clear();
               ImprimirMensagem($"Excluindo {nomeEntidade}{sufixo}...\n", ConsoleColor.DarkGray, 'n');

               bool temRegistros = VisualizarRegistros(false);

               if (!temRegistros)
                    return;

               Console.WriteLine();
               int id = EncontrarId();

               repositorioBase.Deletar(id);

               ImprimirMensagem("\nRegistro excluído com sucesso!", ConsoleColor.Green, 's');
          }

          public int EncontrarId()
          {
               int idSelecionado = 0;
               bool idInvalido;

               do
               {
                    Console.Write("Entre com o id do registro:\n> ");
                    try
                    {
                         idSelecionado = Convert.ToInt32(Console.ReadLine());

                         idInvalido = repositorioBase.ProcurarId(idSelecionado) == null;
                    }
                    catch (FormatException)
                    {
                         ImprimirMensagem("\nO Id deve ser um inteiro!", ConsoleColor.Red, 'n');
                         idInvalido = true;
                    }

                    if (idInvalido)
                         ImprimirMensagem("\nId inválido, tente novamente", ConsoleColor.Red, 's');


               } while (idInvalido);

               return idSelecionado;
          }

          //Deve ser sobreescrito nas telas para obter a entrada específica do elemento.
          protected abstract EntidadeBase ObterRegistro();

          //Deve ser sobreescrito nas telas para obter a tabela específica dos registros de um elemento.
          protected abstract void MostrarTabela(ArrayList registros);

          //Pode ser sobreescrito para modificar a estrutura das opções.
          public virtual void Menu()
          {
               {
                    int saida = 1;
                    do
                    {
                         string opcao = ExibirMenuOpcoes();

                         switch (opcao)
                         {
                              case "0":
                                   ImprimirMensagem($"\nSaindo de {nomeEntidade}{sufixo}...", ConsoleColor.Red, 's');
                                   saida--;
                                   break;

                              case "1":
                                   InserirNovoRegistro();
                                   break;

                              case "2":
                                   VisualizarRegistros(true);
                                   break;

                              case "3":
                                   EditarRegistro();
                                   break;

                              case "4":
                                   ExcluirRegistro();
                                   break;

                              default:
                                   ImprimirMensagem("\nInsira uma opção inválida!", ConsoleColor.Red, 's');
                                   break;
                         }
                    } while (saida > 0);
               }
          }
     }
}

