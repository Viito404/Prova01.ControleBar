using Prova01.ControleBar.Módulo_Comanda;
using Prova01.ControleBar.Módulo_Garçom;
using Prova01.ControleBar.Módulo_Mesa;
using Prova01.ControleBar.Módulo_Produto;
using System.Collections;

namespace Prova01.ControleBar
{
     internal class Program
     {
          static void Main(string[] args)
          {
               MenuPrincipal principal = new MenuPrincipal();

               RepositorioProduto repositorioProduto = new RepositorioProduto(new ArrayList());
               ApresentacaoProduto apresentacaoProduto = new ApresentacaoProduto(repositorioProduto);


               RepositorioGarçom repositorioGarçom = new RepositorioGarçom(new ArrayList());
               ApresentacaoGarçom apresentacaoGarçom = new ApresentacaoGarçom(repositorioGarçom);


               RepositorioMesa repositorioMesa = new RepositorioMesa(new ArrayList());
               ApresentacaoMesa apresentacaoMesa = new ApresentacaoMesa(repositorioMesa);

               RepositorioComanda repositorioComanda = new RepositorioComanda(new ArrayList());
               ApresentacaoComanda apresentacaoComanda = new ApresentacaoComanda(
                    repositorioComanda,
                    repositorioProduto,
                    apresentacaoProduto,
                    repositorioGarçom,
                    apresentacaoGarçom,
                    repositorioMesa,
                    apresentacaoMesa);

               CadastrarAuto(repositorioProduto, repositorioGarçom, repositorioMesa);

               while (true)
               {
                    string opcao = principal.ExibirMenu("Clube Da Leitura");

                    if (opcao == "0")
                    {
                         principal.ImprimirMensagem("\nSaindo do Programa...", ConsoleColor.Red, 's');
                         break;
                    }

                    else if (opcao == "1")
                    {
                         apresentacaoGarçom.Menu();
                    }

                    else if (opcao == "2")
                    {
                         apresentacaoProduto.Menu();
                    }

                    else if (opcao == "3")
                    {
                         apresentacaoMesa.Menu();
                    }

                    else if (opcao == "4")
                    {
                         apresentacaoComanda.Menu();
                    }

                    else
                    {
                         principal.ImprimirMensagem("\nEscolha uma opção válida!", ConsoleColor.Red, 's');
                         continue;
                    }
               }
          }

          private static void CadastrarAuto(RepositorioProduto repositorioProduto, RepositorioGarçom repositorioGarçom, RepositorioMesa repositorioMesa)
          {
               NegocioProduto produto = new NegocioProduto("Coca", 15.00);
               NegocioProduto produto1 = new NegocioProduto("Picanha", 27.00);
               NegocioProduto produto2 = new NegocioProduto("Batata-frita", 7.00);

               repositorioProduto.Inserir(produto);
               repositorioProduto.Inserir(produto1);
               repositorioProduto.Inserir(produto2);

               NegocioGarçom garçom = new NegocioGarçom("Pedro", "012.230-1231", "3782323");
               NegocioGarçom garçom1 = new NegocioGarçom("Rogerio", "012.23123", "12938731");
               NegocioGarçom garçom2 = new NegocioGarçom("Mica", "012332121", "490239203");

               repositorioGarçom.Inserir(garçom);
               repositorioGarçom.Inserir(garçom1);
               repositorioGarçom.Inserir(garçom2);

               NegocioMesa mesa = new NegocioMesa(23, "canto direito");
               NegocioMesa mesa1 = new NegocioMesa(25, "cima");
               NegocioMesa mesa2 = new NegocioMesa(21, "fora");

               repositorioMesa.Inserir(mesa);
               repositorioMesa.Inserir(mesa1);
               repositorioMesa.Inserir(mesa2);
          }
     }
}