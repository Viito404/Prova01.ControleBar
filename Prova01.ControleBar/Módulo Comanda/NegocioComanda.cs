using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Garçom;
using Prova01.ControleBar.Módulo_Mesa;
using Prova01.ControleBar.Módulo_Produto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Comanda
{
     internal class NegocioComanda : EntidadeBase
     {
          private string descricaoComanda;

          private NegocioMesa mesa;
          private NegocioProduto produto;
          private NegocioGarçom garçom;

          public NegocioComanda(string descricaoComanda, NegocioMesa mesa,NegocioGarçom garçom)
          {
               this.descricaoComanda = descricaoComanda;
               this.mesa = mesa;
               this.garçom = garçom;
          }

          public string DescricaoComanda { get { return descricaoComanda; } set { descricaoComanda = value; } }
          public NegocioMesa Mesa { get { return mesa; } set { mesa = value; } }
          public NegocioProduto Produto { get { return produto; } set { produto = value; } }

          public NegocioGarçom Garçom { get { return garçom; } set { garçom = value; } }

          public override void AtualizarRegistros(EntidadeBase registroAtualizado)
          {
              NegocioComanda comanda = (NegocioComanda) registroAtualizado;

               descricaoComanda = comanda.descricaoComanda;
               mesa = comanda.mesa;
               produto = comanda.produto;
               garçom = comanda.garçom;
          }

          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();
               return listaErros;
          }
     }
}
