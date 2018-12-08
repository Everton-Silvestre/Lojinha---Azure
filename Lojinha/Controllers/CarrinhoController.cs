using Lojinha.Core.Models;
using Lojinha.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Controllers
{
    [Authorize]
    public class CarrinhoController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly ICarrinhoService _carrinhoService;
        public CarrinhoController(IProdutoServices produtoServices, ICarrinhoService carrinhoService)
        {
            _produtoServices = produtoServices;
            _carrinhoService = carrinhoService;
        }
        public async Task<IActionResult> Add(string id)
        {
            var usuario = HttpContext.User.Identity.Name;

            Carrinho carrinho = _carrinhoService.Obter(usuario);

            carrinho.Add(await _produtoServices.ObterProduto(id));

            _carrinhoService.Salvar(usuario, carrinho);

            return PartialView("Index", carrinho);

        }
        public IActionResult Finalizar()
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoService.Obter(usuario);

            _carrinhoService.Limpar(usuario);

            return View(carrinho);
        }

    }
}
