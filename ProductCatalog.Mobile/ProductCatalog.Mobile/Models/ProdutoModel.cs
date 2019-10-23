using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Mobile.Models
{
    public class ProdutoModel
    {
       
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string Imagem { get; set; }
        //public virtual CategoriaModel Categoria { get; set; } 
        //public int CategoriaCodigo { get; set; }
        public decimal Estoque { get; set; }
    }

}
