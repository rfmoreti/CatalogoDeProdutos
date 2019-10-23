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
        List<ProdutoModel> catalogo;

        public CatalogoView ()
		{

            InitializeComponent();

            catalogo = new List<ProdutoModel>();
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

        private void VBusca_SearchButtonPressed(object sender, EventArgs e)
        {
            var termo = vBusca.Text;
            var consulta = catalogo.Where(p => p.Titulo.Contains(termo) || p.Descricao.Contains(termo)).ToList();
            vCatalogo.ItemsSource = consulta;
        }



        private void BtnAdicionar_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnSlecionar_Clicked(object sender, EventArgs e)
        {
            var id = (int)((MenuItem)sender).CommandParameter;
            DisplayAlert("Teste", $"Id={id}", "Fechar");
        }
    }
}