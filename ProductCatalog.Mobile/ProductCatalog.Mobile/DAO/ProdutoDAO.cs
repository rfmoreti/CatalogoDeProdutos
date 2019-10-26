using ProductCatalog.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductCatalog.Mobile.DAO
{
    //HACK: SIMULAÇÃO DE TABELA PRODUTO
    //será removido quando o banco for implementado
    public class ProdutoDAO
    {
        private static List<ProdutoModel> tabelaProdutos = new List<ProdutoModel>();

        public void Inserir(ProdutoModel produto)
        {
            produto.Id = tabelaProdutos.Count() + 1;
            tabelaProdutos.Add(produto);
        }

        public IEnumerable<ProdutoModel> Read(Func<ProdutoModel, bool> query)
        {
            return tabelaProdutos.Where(query);
        }

        public void Update(ProdutoModel toUpdate)
        {
            ProdutoModel dbProduto = tabelaProdutos.Where(p => p.Id == toUpdate.Id).FirstOrDefault();

            dbProduto.Titulo = toUpdate.Titulo;
            dbProduto.Estoque = toUpdate.Estoque;
            dbProduto.Preco = toUpdate.Preco;            
            dbProduto.Descricao = toUpdate.Descricao;
          
        }
    }
}
