using ProductCatalog.DAO;
using ProductCatalog.Model;
using ProductCatalog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductCatolog.WebAPI.Controllers
{
    public class ProdutosController : ApiController
    {
        public IEnumerable<Produto> Get()
        {
            using (DataContext context = new DataContext())
            {
                ProdutoService produtoService = new ProdutoService(context);

                var produtos = produtoService.Listar()
                    .Select(p => new Produto()
                    {
                        Codigo = p.Codigo,
                        CategoriaCodigo = p.CategoriaCodigo,
                        Ativo = p.Ativo,
                        Descricao = p.Descricao,
                        Estoque = p.Estoque,
                        Imagem = p.Imagem,
                        Preco = p.Preco,
                        Titulo = p.Titulo
                    });

                return produtos;
            }
        }
    }
}
