using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Compartilhado
{
     internal abstract class EntidadeBase
     {
          //id universal para todos os elementos a serem cadastrados.
          public int id;

          public bool disponivel;
          //método abstrato para atualizar os registros. OBS: deve-se fazer o cast na classe entidade do elemento desejado. 
          public abstract void AtualizarRegistros(EntidadeBase registroAtualizado);

          //método abstrato para coletar erros específicos e regras de negócio na classe entidade do elemento desejado.
          public abstract ArrayList ValidarErros();
     }
}
// Algo em comum com todas as entidades, então, todos os módulos vão implementar validação e atualizar dados. e o id será setado aqui.
// Aqui geralmente vai ser abstrato pq cada módulo tem suas particularidades e atributos.
