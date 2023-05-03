using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Compartilhado
{
     internal class RepositorioBase
     {
          //ArrayList responsável por armazenar toda a informação dos repositórios dos elementos.
          protected ArrayList dados;

          public ArrayList Dados { get { return dados; } set { dados = value; } }

          //Contador de id para todo novo elemento cadastrado.
          protected int contadorId = 0;

          /// <summary>
          ///  Aumenta o "contadorId" e insere um novo elemento em uma ArrayList genérica ("dados").
          /// </summary>
          /// <param name="registro"></param>
          public virtual void Inserir(EntidadeBase registro)
          {
               contadorId++;
               registro.id = contadorId;
               dados.Add(registro);
          }

          /// <summary>
          /// Verifica a existência de um elemento dentro da ArrayList genérica ("dados") por meio da "id".
          /// </summary>
          /// <param name="id"></param>
          /// <returns>Retorna o objeto encontrado.</returns>
          public virtual EntidadeBase ProcurarId(int id)
          {
               EntidadeBase registroSelecionado = null;

               foreach (EntidadeBase registro in dados)
               {
                    if (registro.id == id)
                    {
                         registroSelecionado = registro;
                         break;
                    }
               }
               return registroSelecionado;
          }

          /// <summary>
          /// Verifica a existência de uma "id" dentro da ArrayList genérica ("dados").
          /// </summary>
          /// <param name="id"></param>
          /// <returns>Retorna "true" se houver uma "id" existente, e "false" caso não haja.</returns>
          public virtual bool VerificarId(int id)
          {
               bool temId = false;

               foreach (EntidadeBase registro in dados)
               {
                    if (registro.id == id)
                    {
                         temId = true;
                         break;
                    }
               }
               return temId;
          }

          /// <summary>
          /// Deleta um elemento existente da ArrayList genérica ("dados") utilizando a "id".
          /// </summary>
          /// <param name="id"></param>
          public virtual void Deletar(int id)
          {
               EntidadeBase registroSelecionado = ProcurarId(id);
               dados.Remove(registroSelecionado);
          }

          /// <summary>
          /// Edita um elemento existente da ArrayList genérica ("dados"), utilizando o registro novo e a "id".
          /// </summary>
          /// <param name="registro"></param>
          /// <param name="id"></param>
          public virtual void Editar(EntidadeBase registro, int id)
          {
               EntidadeBase registroSelecionado = ProcurarId(id);
               registroSelecionado.AtualizarRegistros(registro);
          }

          /// <summary>
          /// Retorna a ArrayList genérica ("dados").
          /// </summary>
          /// <returns>Retorna a lista "dados".</returns>
          public virtual ArrayList PegarLista()
          {
               return dados;
          }
     }
}
// passa os dados pronto para adicionar/remover/editar
// EntidadeBase para ser bem genérico --> Object

