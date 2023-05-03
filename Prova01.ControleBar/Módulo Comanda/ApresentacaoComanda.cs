using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Garçom;
using Prova01.ControleBar.Módulo_Mesa;
using Prova01.ControleBar.Módulo_Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Comanda
{
     internal class ApresentacaoComanda : TelaBase
     {
          RepositorioComanda repositorioComanda;
          RepositorioProduto repositorioProduto;
          ApresentacaoProduto apresentacaoProduto;
          RepositorioGarçom repositorioGarçom;
          ApresentacaoGarçom apresentacaoGarçom;
          RepositorioMesa repositorioMesa;
          ApresentacaoMesa apresentacaoMesa;

          public ApresentacaoComanda(RepositorioComanda repositorioComanda, RepositorioProduto repositorioProduto, ApresentacaoProduto apresentacaoProduto, RepositorioGarçom repositorioGarçom, ApresentacaoGarçom apresentacaoGarçom, RepositorioMesa repositorioMesa, ApresentacaoMesa apresentacaoMesa)
          {
               nomeEntidade = "Conta";
               sufixo = "s";
               this.repositorioComanda = repositorioComanda;
               this.repositorioProduto = repositorioProduto;
               this.apresentacaoProduto = apresentacaoProduto;
               this.repositorioGarçom = repositorioGarçom;
               this.apresentacaoGarçom = apresentacaoGarçom;
               this.repositorioMesa = repositorioMesa;
               this.apresentacaoMesa = apresentacaoMesa;
               repositorioBase = repositorioComanda;
          }

          protected void MostrarContas(ArrayList registros)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} |", "Id", "Descrição comanda", "Garçom", "Nº Mesa", "Total a pagar");
               Console.ResetColor();
               foreach (NegocioComanda comanda in registros)
               {
                    Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -20} | {4, -20} |", comanda.id, comanda.DescricaoComanda, comanda.Garçom.Nome, comanda.Mesa.NumeroMesa, comanda.Pagamento.ToString("F2"));
               }
          }

          protected override EntidadeBase ObterRegistro()
          {
               Console.Write("Entre com a DESCRIÇÃO da comanda: ");
               string descricaoComanda = Console.ReadLine();

               NegocioMesa mesa = PegarMesa(repositorioMesa);

               NegocioGarçom garçom = PegarGarçom(repositorioGarçom);

               NegocioComanda comanda = new NegocioComanda(descricaoComanda, mesa, garçom);

               return comanda;
          }

          public override string ExibirMenuOpcoes()
          {
               Console.Clear();
               Console.WriteLine($"| {nomeEntidade}{sufixo} |");
               ImprimirMensagem("\n[1] ABRIR CONTA;\n[2] REGISTRAR PEDIDOS;\n[3] FECHAR CONTA;\n[4] VISUALIZAR CONTAS ABERTAS;\n[5] VISUALIZAR TOTAL FATURADO;\n[0] SAIR.", ConsoleColor.Blue, 'n');
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }

          public override void Menu()
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
                                   AbrirConta();
                                   break;

                              case "2":
                                   RegistrarPedidos();
                                   break;

                              case "3":
                                   new NotImplementedException();
                                   break;

                              case "4":
                                   VisualizarContasAbertas(true);
                                   break;

                              case "5":
                                   new NotImplementedException();
                                   break;

                              default:
                                   ImprimirMensagem("\nInsira uma opção inválida!", ConsoleColor.Red, 's');
                                   break;
                         }
                    } while (saida > 0);
               }
          }

          private void RegistrarPedidos()
          {
               Console.Clear();
               ImprimirMensagem($"Cadastrando pedidos...\n", ConsoleColor.DarkGray, 'n');

               ArrayList registros = repositorioBase.PegarLista();

               if (registros.Count == 0)
               {
                    ImprimirMensagem("\nNenhuma conta aberta!", ConsoleColor.DarkYellow, 's');
                    return;
               }

               MostrarContas(registros);
               Console.WriteLine();
               int id = EncontrarId();
               NegocioComanda comanda = repositorioComanda.ProcurarId(id);
               FazerPedidos(comanda);
               ImprimirMensagem("\nPedido realizado com sucesso!", ConsoleColor.Green, 's');
          }

          public void FazerPedidos(NegocioComanda comanda)
          {
               NegocioProduto produto = PegarProduto(repositorioProduto);
               int quantidade = VerificarInt("\nEntre com uma quantidade:\n> ", "quantidade");

               comanda.Produto = produto;
               comanda.AcrescentarMontante(quantidade, produto);
               return;
          }

          public void AbrirConta()
          {
               Console.Clear();
               ImprimirMensagem($"Abrindo {nomeEntidade}...\n", ConsoleColor.DarkGray, 'n');

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

               ImprimirMensagem($"\n{nomeEntidade} aberta com sucesso!", ConsoleColor.Green, 's');
          }

          public bool VisualizarContasAbertas(bool mostrarCabecalho)
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
                    ImprimirMensagem("\nNenhuma conta aberta!", ConsoleColor.DarkYellow, 's');
                    return false;
               }

               MostrarContas(registros);

               if (visualizando)
                    Console.ReadLine();

               return true;
          }
          private NegocioMesa PegarMesa(RepositorioMesa repositorioMesa)
          {
               int id;
               bool disponivel = true;
               do
               {
                    apresentacaoMesa.VisualizarRegistros(true);
                    id = apresentacaoMesa.EncontrarId();
                    disponivel = apresentacaoMesa.VerificarDisponibilidade(id);

                    if (!disponivel)
                         ImprimirMensagem("\nEntre com uma mesa disponível!", ConsoleColor.Red, 's');

               } while (!disponivel);

               NegocioMesa mesa = repositorioMesa.ProcurarId(id);
               mesa.disponivel = false;
               return mesa;
          }
          private NegocioProduto PegarProduto(RepositorioProduto repositorioProduto)
          {
               apresentacaoProduto.VisualizarRegistros(true);
               int id = apresentacaoProduto.EncontrarId();
               NegocioProduto produto = repositorioProduto.ProcurarId(id);
               return produto;
          }
          private NegocioGarçom PegarGarçom(RepositorioGarçom repositorioGarçom)
          {
               apresentacaoGarçom.VisualizarRegistros(true);
               int id = apresentacaoGarçom.EncontrarId();
               NegocioGarçom garçom = repositorioGarçom.ProcurarId(id);
               return garçom;
          }

          protected override void MostrarTabela(ArrayList registros)
          {
               throw new NotImplementedException();
          }
     }
}
