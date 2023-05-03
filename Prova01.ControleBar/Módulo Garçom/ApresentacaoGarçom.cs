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
               pronome = "o";
               nomeEntidade = "Garçom";
               this.repositorioGarçom = repositorioGarçom;
               repositorioBase = repositorioGarçom;
          }

          protected override void MostrarTabela(ArrayList registros)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -20} |", "Id", "NOME", "CPF", "TELEFONE");
               Console.ResetColor();
               foreach (NegocioGarçom garçom in registros)
               {
                    Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -20} |", garçom.id, garçom.Nome.ToUpper(), garçom.Cpf, garçom.Telefone);
               }
          }

          protected override EntidadeBase ObterRegistro()
          {
               string nome = VerificarString("Entre com o NOME: ","nome");

               string cpf = VerificarString("\nEntre com o CPF: ", "cpf");

               string telefone = VerificarString("\nEntre com o TELEFONE: ", "telefone");

               NegocioGarçom garçom = new NegocioGarçom(nome, cpf, telefone);

               return garçom;
          }

          public override string VerificarString(string mensagem, string campo)
          {
               string value = null;
               bool temNumeros = false;

               do
               {
                    temNumeros = false;
                    ImprimirMensagem(mensagem, ConsoleColor.White, 'n');
                    value = Console.ReadLine();

                    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    {
                         ImprimirMensagem($"Campo '{campo}' obrigatório!", ConsoleColor.Red, 'n');
                         Console.ReadLine();
                    }

                    if (campo == "nome")
                         if (int.TryParse(value, out int vaee))
                         {
                              ImprimirMensagem($"\nCampo '{campo}' não deve conter números!", ConsoleColor.Red, 'n');
                              Console.ReadLine();
                              temNumeros = true;
                         }

               } while (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || temNumeros);

               return value;
          }
     }
}

