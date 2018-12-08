using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Core.Models
{
    public class Carrinho
    {
        public readonly List<CarrinhoItem> Items;

        public Carrinho()
        {
            Items = new List<CarrinhoItem>();
        }
        public void Add(Produto produto)
        {
            if (Items.Any(x=>x.Produto.Id == produto.Id))
            {
                var item = Items.FirstOrDefault(x => x.Produto.Id == produto.Id);
                item.Quantidade++;
            }
            else
            {
                Items.Add(new CarrinhoItem
                {
                    Produto = produto,
                    Quantidade = 1
                });

            }
        }
    }
}
