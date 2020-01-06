using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public int Id { set; get; }
        public string Nome { set; get; }
        public string Descricao { set; get; }
        public decimal Preco { set; get; }

        public override void Validade()
        {
            throw new NotImplementedException();
        }
    }
}
