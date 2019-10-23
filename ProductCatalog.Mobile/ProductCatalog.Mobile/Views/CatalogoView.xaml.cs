using ProductCatalog.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductCatalog.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CatalogoView : ContentPage
	{
		public CatalogoView ()
		{

            InitializeComponent();

            List<ProdutoModel> catalogo = new List<ProdutoModel>();
            catalogo.Add(new ProdutoModel()
            {
                Titulo = "Produto 1",
                Descricao = "Descrição 1",
                Preco = Convert.ToDecimal(3.00),
                Imagem = "http://picsum.photos/128/128",
               // CategoriaCodigo = 0,
                Estoque = Convert.ToDecimal(10),
            });
            catalogo.Add(new ProdutoModel()
            {
                Titulo = "Produto 2",
                Descricao = "Descrição 2",
                Preco = Convert.ToDecimal(32.00),
                Imagem = "http://picsum.photos/128/128",
               // CategoriaCodigo = 2,
                Estoque = Convert.ToDecimal(120),
            });
            catalogo.Add(new ProdutoModel()
            {
                Titulo = "Produto 3",
                Descricao = "Descrição 3",
                Preco = Convert.ToDecimal(113.00),
                Imagem = "http://picsum.photos/128/128",
               // CategoriaCodigo = 5,
                Estoque = Convert.ToDecimal(5),
            });
            catalogo.Add(new ProdutoModel()
            {
                Titulo = "Produto 4",
                Descricao = "Descrição 5",
                Preco = Convert.ToDecimal(56.00),
                Imagem = "http://picsum.photos/128/128",
                //CategoriaCodigo = 3,
                Estoque = Convert.ToDecimal(25),
            });
            catalogo.Add(new ProdutoModel()
            {
                Titulo = "Produto 5",
                Descricao = "Descrição 5",
                Preco = Convert.ToDecimal(98.00),
                Imagem = "http://picsum.photos/128/128",
               // CategoriaCodigo = 3,
                Estoque = Convert.ToDecimal(9),
            });

            //Adiciona o Catalogo de produtos na lista (listView)
            vCatalogo.ItemsSource = catalogo;




		}
	}
}