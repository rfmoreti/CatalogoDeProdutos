using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Mobile.Helpers
{
    public static class CameraHelper
    {
        //Comando para tirar uma foto
        //Habilitando o Task o comando vira tarefa
        public static async Task<MediaFile> TirarFotoAsync()
        {
            //Inicializar a camera do dispositivo
            CrossMedia.Current.Initialize();
            //Verifica se exist uma camera disponivel no dispositivo
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                //Não suporta e Retorna uma midia nula
                return null;
            }
            else
            {
                //Cria a foto
                StoreCameraMediaOptions foto = new StoreCameraMediaOptions()
                {
                    SaveToAlbum = true, //salva a foto em disco
                    CompressionQuality = 60, //define a qualidade da foto de 0 a 100
                    PhotoSize = PhotoSize.Medium,
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                //Cria o arquivo de midia com a foto
                MediaFile media = await CrossMedia.Current.TakePhotoAsync(foto);
                return media;
            }
        }

        public static async Task<MediaFile> PegarFotoAsync()
        {
            //Inicializa a camera do dispositivo
            await CrossMedia.Current.Initialize();
            
            //Verifica se podemos selecionar uma foto na pasta
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //Não suporta e Retorna uma midia nula
                return null;
            }
            else
            {
                //seleciona a foto na pasta
                MediaFile media = await CrossMedia.Current.PickPhotoAsync();
                return media;
            }
        }
    }
}
