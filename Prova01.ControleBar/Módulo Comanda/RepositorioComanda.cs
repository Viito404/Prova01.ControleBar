using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Comanda
{
     internal class RepositorioComanda : RepositorioBase
     {
          public RepositorioComanda(ArrayList listaComandas)
          {
               dados = listaComandas;
          }

          public override NegocioComanda ProcurarId(int id)
          {
               return (NegocioComanda)base.ProcurarId(id);
          }

          public override bool VerificarId(int id)
          {
               throw new NotImplementedException();
          }
     }
}
