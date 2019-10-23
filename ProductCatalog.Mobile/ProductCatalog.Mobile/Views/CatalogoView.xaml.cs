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
            for (int i = 0; i < 10; i++){
                catalogo.Add(new ProdutoModel()
                {
                    Id = i,
                    Titulo = $"Produto {i}",
                    Descricao = "Descrição ",
                    Preco = Convert.ToDecimal(3.00),
                    Imagem = "http://picsum.photos/128/128",
                    // CategoriaCodigo = 0,
                    Estoque = Convert.ToDecimal(10),
                });
            }
            //Adiciona o Catalogo de produtos na lista (listView)
            vCatalogo.ItemsSource = catalogo;




		}

        private void VCatalogo_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //pega o item selecionado (objeto) da lista 
            var produto = e.SelectedItem as ProdutoModel;
            //Navega para a pagina do produto 
            //envia o produto selecionado
            Navigation.PushAsync(new ProdutoView(produto));
        }
    }
}