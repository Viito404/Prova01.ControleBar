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
               pronome = "o";
               nomeEntidade = "Produto";
               sufixo = "s";
               this.repositorioProduto = repositorioProduto;
               repositorioBase = repositorioProduto;
          }
          protected override void MostrarTabela(ArrayList registros)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -10} | {1, -25} | {2, -20} | {3, -10} |", "Id", "Nome", "Unidade medida", "Preço");
               Console.ResetColor();
               foreach (NegocioProduto produto in registros)
               {
                    Console.WriteLine("| {0, -10} | {1, -25} | {2, -20} | {3, -10} |", produto.id, produto.NomeProduto, produto.UnidadesMedida, produto.PrecoProduto.ToString("F2"));
               }
          }

          protected override EntidadeBase ObterRegistro()
          {
               string nome = VerificarString("Entre com o NOME do produto: ", "Nome");


               double preco = VerificarDouble("\nEntre com o PREÇO do produto: ", "Preço");

               string unidadesMedida = VerificarString("\nEntre com uma UNIDADE DE MEDIDA do produto: ", "Unidade medida");

               NegocioProduto produto = new NegocioProduto(nome, preco, unidadesMedida);
               return produto;
          }
     }
}
