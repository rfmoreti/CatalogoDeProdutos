using ProductCatalog.Mobile.DAO;
using ProductCatalog.Mobile.Models;
using ProductCatalog.Mobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProductCatalog.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            IniciaBanco();

            MainPage = new NavigationPage(new CatalogoView());
        }

        private void IniciaBanco()
        {
            var produtoDao = new ProdutoDAO();
            
            for (int i = 1; i <= 10; i++)
            {
                produtoDao.Inserir(new ProdutoModel()
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
          
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
