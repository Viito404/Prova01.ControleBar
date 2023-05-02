using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Comanda;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Garçom
{
     internal class RepositorioGarçom : RepositorioBase
     {
          public RepositorioGarçom(ArrayList arrayList)
          {
               dados = arrayList;
          }

          public override NegocioGarçom ProcurarId(int id)
          {
               return (NegocioGarçom)base.ProcurarId(id);
          }
     }
}
