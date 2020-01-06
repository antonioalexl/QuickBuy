using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido: Entidade
    {

        public int Id { get; set; }
        public DateTime DataPedido  {get;set;}

        public int UsuarioId { get; set; }

        public DateTime DataPrevisa { get; set; }

        public string CEP { set; get; }

        public string Estado { set; get; }

        public string Cidade { set; get; }

        public string EnderecoCompleto { set; get; }

        public int NumeroEndereco { set; get; }

        public ICollection<ItemPedido> ItensPedido { set; get; }

        public int FormaPagamentoId { set; get; }

        public FormaPagamento FormaPagamento { set; get; }

        public override void Validade()
        {
            if (!ItensPedido.Any())
            {
                AdicionarCritica("Critica - Pedido nao pode ficar sem item de pedido");
            }
            if (string.IsNullOrEmpty(CEP))
            {
                AdicionarCritica("Critica - O Cep precisa ser informado");
            }
        }
    }
}
