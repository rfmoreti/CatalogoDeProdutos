using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductCatalog.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraView : ContentPage
    {
        public CameraView()
        {
            InitializeComponent();
        }

        private async void BtnTirar_Clicked(object sender, EventArgs e)
        {
            MediaFile media = await Helpers.CameraHelper.TirarFotoAsync();

            if (media == null)
            {
                await DisplayAlert("Atenção", "Nenhuma foto capturada", "Fechar");
            }
            else
            {
                vFoto.Source = ImageSource.FromStream(() =>
                {
                    Stream fotoMemoria = media.GetStream(); //Carrega na memoria
                    media.Dispose(); //Descarrega da memoria
                    return fotoMemoria;
                });
            }
        }

        private async void BtnPegar_Clicked(object sender, EventArgs e)
        {
            MediaFile media = await Helpers.CameraHelper.PegarFotoAsync();
        }
    }
}