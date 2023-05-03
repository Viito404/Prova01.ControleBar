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
                    string opcao = principal.ExibirMenu("Controle do Bar");

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
               NegocioProduto produto = new NegocioProduto("Refrigerante", 15.00,"2L");
               NegocioProduto produto1 = new NegocioProduto("Refrigerante", 3.50,"450ml");
               NegocioProduto produto2 = new NegocioProduto("Gin tônica", 27.00,"750ml");
               NegocioProduto produto3 = new NegocioProduto("Cerveja", 4.50, "450ml");
               NegocioProduto produto4 = new NegocioProduto("Pão de queijo", 1.50, "120g");

               repositorioProduto.Inserir(produto);
               repositorioProduto.Inserir(produto1);
               repositorioProduto.Inserir(produto2);
               repositorioProduto.Inserir(produto3);
               repositorioProduto.Inserir(produto4);

               NegocioGarçom garçom = new NegocioGarçom("Pedro Matias", "012.230.123-02", "4999921022");
               NegocioGarçom garçom1 = new NegocioGarçom("Rogerio Santos", "022.431.133-03", "4721288191");
               NegocioGarçom garçom2 = new NegocioGarçom("Micael Rodrigues", "012.332.121-01", "4902392032");

               repositorioGarçom.Inserir(garçom);
               repositorioGarçom.Inserir(garçom1);
               repositorioGarçom.Inserir(garçom2);

               NegocioMesa mesa = new NegocioMesa(1, "Fora", true);
               NegocioMesa mesa1 = new NegocioMesa(2, "Fora", true);
               NegocioMesa mesa2 = new NegocioMesa(3, "Fora", true);
               NegocioMesa mesa3 = new NegocioMesa(4, "Janela", true);
               NegocioMesa mesa4 = new NegocioMesa(5, "Janela", true);

               repositorioMesa.Inserir(mesa);
               repositorioMesa.Inserir(mesa1);
               repositorioMesa.Inserir(mesa2);
               repositorioMesa.Inserir(mesa3);
               repositorioMesa.Inserir(mesa4);
          }
     }
}