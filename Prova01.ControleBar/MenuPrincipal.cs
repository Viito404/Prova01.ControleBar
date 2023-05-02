using Prova01.ControleBar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar
{
     internal class MenuPrincipal : TelaBase
     {
          public string ExibirMenu(string titulo)
          {
               Console.Clear();
               Console.WriteLine($"| {titulo} |");
               ImprimirMensagem("\n[1] GARÇONS;\n[2] PRODUTOS;\n[3] MESAS\n[4] CONTAS;\n[0] SAIR.", ConsoleColor.Cyan, 'n');
               Console.ResetColor();
               Console.Write("\nEntre com a opção desejada:\n> ");
               string opcao = Console.ReadLine();
               return opcao;
          }

          public override void Menu()
          {
               throw new NotImplementedException();
          }

          protected override void MostrarTabela(ArrayList registros)
          {
               throw new NotImplementedException();
          }

          protected override EntidadeBase ObterRegistro()
          {
               throw new NotImplementedException();
          }
     }
}
