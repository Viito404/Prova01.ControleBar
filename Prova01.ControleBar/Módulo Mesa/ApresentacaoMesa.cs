using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Mesa
{
     internal class ApresentacaoMesa : TelaBase
     {
          RepositorioMesa repositorioMesa;
          public ApresentacaoMesa(RepositorioMesa repositorioMesa)
          {
               nomeEntidade = "Mesa";
               sufixo = "s";
               this.repositorioMesa = repositorioMesa;
               repositorioBase = repositorioMesa;
          }

          protected override void MostrarTabela(ArrayList mesas)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} |", "Id", "Número Mesa", "Localização");
               Console.ResetColor();
               foreach (NegocioMesa mesa in mesas)
               {
                    Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} |", mesa.id, mesa.NumeroMesa, mesa.LocalizacaoMesa);
               }
          }

          protected override EntidadeBase ObterRegistro()
          {
               Console.Write("Entre com o NÚMERO da mesa: ");
               int numero = Convert.ToInt32(Console.ReadLine());

               Console.Write("\nEntre com a LOCALIZAÇÃO da mesa: ");
               string localizacao = Console.ReadLine();

               NegocioMesa mesa = new NegocioMesa(numero, localizacao);

               return mesa;
          }
     }
}
