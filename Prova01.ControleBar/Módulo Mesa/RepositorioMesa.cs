using Prova01.ControleBar.Compartilhado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Mesa
{
     internal class RepositorioMesa : RepositorioBase
     {
          public RepositorioMesa(ArrayList listaMesas)
          {
               dados = listaMesas;
          }

          public override NegocioMesa ProcurarId(int id)
          {
               return (NegocioMesa)base.ProcurarId(id);
          }

          public bool VerificarNumero(int numero)
          {
               bool temNumero = false;

               foreach (NegocioMesa registro in dados)
               {
                    if (registro.NumeroMesa == numero)
                    {
                         temNumero = true;
                         break;
                    }
               }
               return temNumero;
          }

     }
}
