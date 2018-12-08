using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Core.ViewModels
{
    public class ProdutoViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string ImageUrl { get; set; }
        public decimal Preco { get; set; }
    }
}
