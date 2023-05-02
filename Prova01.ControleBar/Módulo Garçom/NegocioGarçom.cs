using Prova01.ControleBar.Compartilhado;
using Prova01.ControleBar.Módulo_Mesa;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova01.ControleBar.Módulo_Garçom
{
     internal class NegocioGarçom : EntidadeBase
     {
          private string nome, cpf, telefone;

          public NegocioGarçom(string nome, string cpf, string telefone)
          {
               this.nome = nome;
               this.cpf = cpf;
               this.telefone = telefone;
          }

          public string Nome { get { return nome; } set { nome = value; } }
          public string Cpf { get { return cpf; } set { cpf = value; } }
          public string Telefone { get { return telefone; } set { telefone = value; } }

          public override void AtualizarRegistros(EntidadeBase registroAtualizado)
          {
               NegocioGarçom garçom = (NegocioGarçom)registroAtualizado;
               this.nome = garçom.nome;
               this.cpf = garçom.cpf;
               this.telefone = garçom.telefone;
          }

          public override ArrayList ValidarErros()
          {
               ArrayList listaErros = new ArrayList();

               if (string.IsNullOrEmpty(this.nome) || string.IsNullOrWhiteSpace(this.nome))
                    listaErros.Add("Campo nome obrigatório!");

               if (string.IsNullOrEmpty(this.cpf) || string.IsNullOrWhiteSpace(this.cpf))
                    listaErros.Add("Campo cpf obrigatório!");

               if (string.IsNullOrEmpty(this.telefone) || string.IsNullOrWhiteSpace(this.telefone))
                    listaErros.Add("Campo telefone obrigatório!");

               return listaErros;
          }
     }
}
