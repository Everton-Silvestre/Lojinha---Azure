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
                Id = 11111,
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
                ImagemPrincipalUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4Y-x8uZgGEU1taFVmBRfMtvaNTO4f2YDbR8AEet_DxRat8OU"

            };
           // _azureStorage.AddProduto(produto);
            return Content("OK");
        }

        public async Task<IActionResult> List()
        {

            var produtos = await _produtoServices.ObterProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(vm);

            //return Json(await _produtoServices.ObterProdutos());
        }

        public async Task<IActionResult> Details(string id)
        {
            var produto = await _produtoServices.ObterProduto(id);
            return Json(produto);
        }
    }
}
