using AutoMapper;
using Lojinha.Core.Models;
using Lojinha.Core.Services;
using Lojinha.Core.ViewModels;
using Lojinha.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Controllers
{
    [Authorize]
    public class ProdutosController:Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoServices produtoServices, IMapper mapper )
        {
            _produtoServices = produtoServices;
            _mapper = mapper;
        }
        public IActionResult Create()
        {            
            var produto = new Produto
            {
                Id = 331511,
                Nome = "Asus ZenFone 5",
                Categoria = new Categoria
                {
                    Id = 1,
                    Nome = "SmartPhones"
                },
                Descricao = "Asus ZenFone 5 max",
                Fabricante = new Fabricante
                {
                    Id = 1,
                    Nome = "Asus"
                },
                Preco = 3500m,
                Tags = new[]
                {
                    "Asus","Celular","SmartPhone"
                },
                ImagemPrincipalUrl = "https://icdn3.digitaltrends.com/image/asus-zenfone-5-review-8-1200x630-c-ar1.91.jpg"
                
            };
           // _azureStorage.AddProduto(produto);
            return Content("OK");
        }

        public async Task<IActionResult> List()
        {

            var produtos = await _produtoServices.ObterProdutos();
            var vm = _mapper.Map<ProdutoViewModel>(produtos);

            return View(vm);

            //return Json(await _produtoServices.ObterProdutos());
        }
    }
}
