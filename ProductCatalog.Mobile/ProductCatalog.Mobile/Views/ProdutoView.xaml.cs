using ProductCatalog.Mobile.DAO;
using ProductCatalog.Mobile.Models;
using ProductCatalog.Mobile.Services;
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
        private ProdutoDAO dao = new ProdutoDAO();
        private ProdutoServiceApi produtoServiceApi = new ProdutoServiceApi();
        ProdutoModel produtoAntigo;

		public ProdutoView (ProdutoModel produto)
		{
			InitializeComponent ();
            produtoAntigo = produto;
            //Alerta em tela
            //DisplayAlert("Produto", $"Id = {produto.Id}\n Produto{produto.Titulo}", "Fechar");
            this.vTitulo.Text = produto.Titulo;
            this.vPreco.Text = produto.Preco.ToString("C2");
            this.vDescricao.Text = produto.Descricao;
            this.vEstoque.Text = produto.Estoque.ToString("N2");
            this.vFoto.Source = produto.Imagem;

		}

        private async void BtnSalvar_ClickedAsync(object sender, EventArgs e)
        {
            var produto = new ProdutoModel();
            produto.Id = produtoAntigo.Id;
            produto.Titulo = this.vTitulo.Text;
            produto.Preco = decimal.Parse(this.vPreco.Text.Remove(0,2));
            produto.Descricao = this.vDescricao.Text;
            produto.Estoque = decimal.Parse(this.vEstoque.Text);
            produto.CategoriaCodigo = 23;
            produto.Ativo = true;
            produto.Imagem = @"https://picsum.photos/200/300";

            SauloWrapper<ProdutoModel> ret = null;

            if (produto.Id == 0)
               ret = await produtoServiceApi.PostObj(produto);//dao.Inserir(produto);
            else
                dao.Update(produto);

            if (ret.Success)
                await Navigation.PopAsync();
            else
                await DisplayAlert("Alerta", ret.msg, "Ok");
        }
    }
}