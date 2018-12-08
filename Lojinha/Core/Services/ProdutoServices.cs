﻿using Lojinha.Core.Models;
using Lojinha.Infrastructure.Redis;
using Lojinha.Infrastructure.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Core.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IRedisCache _cache;
        private readonly IAzureStorage _storage;

        public ProdutoServices(IRedisCache cache, IAzureStorage storage)
        {
            _cache = cache;
            _storage = storage;

        }
        public async Task<List<Produto>> ObterProdutos()
        {
            var key = "produtos";
            var value = _cache.Get(key);

            if (string.IsNullOrEmpty(value))
            {
                var produtos = await _storage.ObterProdutos();
                _cache.Set(key, JsonConvert.SerializeObject(produtos));

                return produtos;
            }

            return JsonConvert.DeserializeObject<List<Produto>>(value);
        }
    }
}
