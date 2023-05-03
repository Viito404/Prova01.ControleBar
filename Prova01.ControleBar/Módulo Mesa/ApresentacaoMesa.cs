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
               pronome = "a";
               nomeEntidade = "Mesa";
               sufixo = "s";
               this.repositorioMesa = repositorioMesa;
               repositorioBase = repositorioMesa;
          }

          protected override void MostrarTabela(ArrayList mesas)
          {
               Console.BackgroundColor = ConsoleColor.Blue;
               Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -10} |", "Id", "Número Mesa", "Localização", "Disponível");
               Console.ResetColor();
               foreach (NegocioMesa mesa in mesas)
               {
                    Console.WriteLine("| {0, -10} | {1, -20} | {2, -20} | {3, -10} |", mesa.id, mesa.NumeroMesa, mesa.LocalizacaoMesa, mesa.disponivel);
               }
          }

          protected override EntidadeBase ObterRegistro()
          {
               int numero = 0;
               bool numeroInvalido = false;
               do
               {
                    numeroInvalido = false;

                    numero = VerificarInt("Entre com o NÚMERO da mesa: ", "número mesa");

                    if (repositorioMesa.VerificarNumero(numero))
                    {
                         ImprimirMensagem("\nInsira um número diferente!", ConsoleColor.Red, 's');
                         numeroInvalido = true;
                    }

               } while (numeroInvalido);

               string localizacao = VerificarString("\nEntre com a LOCALIZAÇÃO da mesa: ", "localização");

               NegocioMesa mesa = new NegocioMesa(numero, localizacao, true);

               return mesa;
          }

          public bool VerificarDisponibilidade(int numero)
          {
               bool disponivel = true;

               foreach (NegocioMesa registro in repositorioBase.Dados)
               {
                    if (registro.id == numero)
                         if(registro.disponivel == false)
                    {
                         disponivel = false;
                         break;
                    }
               }
               return disponivel;
          }

          public override void ExcluirRegistro()
          {
               Console.Clear();
               ImprimirMensagem($"Excluindo {nomeEntidade}{sufixo}...\n", ConsoleColor.DarkGray, 'n');

               bool temRegistros = VisualizarRegistros(false);

               if (!temRegistros)
                    return;

               Console.WriteLine();
               int id = EncontrarId();

               if (!VerificarDisponibilidade(id))
               {
                    ImprimirMensagem("\nMesa indisponível para exclusão!", ConsoleColor.Red, 's');
                    return;
               }

               repositorioBase.Deletar(id);

               ImprimirMensagem("\nRegistro exluído com sucesso!", ConsoleColor.Green, 's');
          }

          public override void EditarRegistro()
          {
               Console.Clear();
               ImprimirMensagem($"Editando {nomeEntidade}{sufixo}...\n", ConsoleColor.DarkGray, 'n');

               bool temRegistros = VisualizarRegistros(false);

               if (!temRegistros)
                    return;

               Console.WriteLine();

               int id = EncontrarId();

               if (!VerificarDisponibilidade(id))
               {
                    ImprimirMensagem("\nMesa indisponível para edição!", ConsoleColor.Red, 's');
                    return;
               }

               Console.WriteLine();
               EntidadeBase registroAtualizado = ObterRegistro();
               ArrayList listaErros = registroAtualizado.ValidarErros();

               if (listaErros.Count > 0)
               {
                    foreach (String entidade in listaErros)
                         ImprimirMensagem(entidade, ConsoleColor.Red, 'n');

                    Console.ReadLine();
                    EditarRegistro();
                    return;
               }

               repositorioBase.Editar(registroAtualizado, id);

               ImprimirMensagem("\nRegistro editado com sucesso!", ConsoleColor.Green, 's');
          }
     }
}
