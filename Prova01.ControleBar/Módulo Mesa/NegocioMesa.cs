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
     internal class NegocioMesa : EntidadeBase
     {
          private int numeroMesa;
          private string localizacaoMesa;

          public NegocioMesa(int numeroMesa, string localizacaoMesa)
          {
               this.numeroMesa = numeroMesa;
               this.localizacaoMesa = localizacaoMesa;
          }

          public int NumeroMesa { get { return numeroMesa; } set { numeroMesa = value; } }
          public string LocalizacaoMesa { get { return localizacaoMesa; } set { localizacaoMesa = value; } }

          public override void AtualizarRegistros(EntidadeBase registroAtualizado)
          {
               NegocioMesa mesa = (NegocioMesa)registroAtualizado;
               this.numeroMesa = mesa.numeroMesa;
               this.localizacaoMesa = mesa.localizacaoMesa;
          }

          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();
               return listaErros;
          }
     }
}
