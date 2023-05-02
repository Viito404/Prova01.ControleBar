using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Garçom
{
     internal class ApresentacaoGarçom : TelaBase
     {
          RepositorioGarçom repositorioGarçom;
          public ApresentacaoGarçom(RepositorioGarçom repositorioGarçom)
          {
               nomeEntidade = "Garçom";
               this.repositorioGarçom = repositorioGarçom;
               repositorioBase = repositorioGarçom;
          }

          protected override void MostrarTabela(ArrayList registros)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -20} |", "Id", "Nome", "Cpf", "Telefone");
               Console.ResetColor();
               foreach (NegocioGarçom garçom in registros)
               {
                    Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -20} |", garçom.id, garçom.Nome, garçom.Cpf, garçom.Telefone);
               }
          }

          protected override EntidadeBase ObterRegistro()
          {
               Console.Write("Entre com o NOME: ");
               string nome = Console.ReadLine();

               Console.Write("\nEntre com o CPF: ");
               string cpf = Console.ReadLine();

               Console.Write("\nEntre com o TELEFONE: ");
               string telefone = Console.ReadLine();

               NegocioGarçom garçom = new NegocioGarçom(nome, cpf, telefone);

               return garçom;
          }
     }
}

