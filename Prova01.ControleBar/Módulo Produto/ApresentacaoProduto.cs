using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Produto
{
     internal class ApresentacaoProduto : TelaBase
     {
          RepositorioProduto repositorioProduto;

          public ApresentacaoProduto(RepositorioProduto repositorioProduto)
          {
               nomeEntidade = "Produto";
               sufixo = "s";
               this.repositorioProduto = repositorioProduto;
               repositorioBase = repositorioProduto;
          }
          protected override void MostrarTabela(ArrayList registros)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} |", "Id", "Nome", "Preço");
               Console.ResetColor();
               foreach (NegocioProduto produto in registros)
               {
                    Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} |", produto.id, produto.NomeProduto, produto.PrecoProduto);
               }
          }

          protected override EntidadeBase ObterRegistro()
          {
               Console.Write("Entre com o NOME do produto: ");
               string nome = Console.ReadLine();

               Console.Write("\nEntre com o PREÇO do produto: ");
               double preco = Convert.ToDouble(Console.ReadLine());

               NegocioProduto produto = new NegocioProduto(nome, preco);
               return produto;
          }
     }
}
