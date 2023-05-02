using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Produto
{
     internal class RepositorioProduto : RepositorioBase
     {
          public RepositorioProduto(ArrayList listaProdutos)
          {
               dados = listaProdutos;
          }

          public override NegocioProduto ProcurarId(int id)
          {
               return (NegocioProduto)base.ProcurarId(id);
          }

          public override bool VerificarId(int id)
          {
               throw new NotImplementedException();
          }
     }
}
