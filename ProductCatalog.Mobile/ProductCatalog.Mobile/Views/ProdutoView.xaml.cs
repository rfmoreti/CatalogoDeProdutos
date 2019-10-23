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
	public partial class ProdutoView : ContentPage
	{
		public ProdutoView (ProdutoModel produto)
		{
			InitializeComponent ();
            //Alerta em tela
            //DisplayAlert("Produto", $"Id = {produto.Id}\n Produto{produto.Titulo}", "Fechar");
            vTitulo.Text = produto.Titulo;
            vPreco.Text = Convert.ToString(produto.Preco);
            vDescricao.Text = produto.Descricao;
            vEstoque.Text = Convert.ToString(produto.Estoque);
            vFoto.Source = produto.Imagem;

		}
	}
}