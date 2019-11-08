using System;
using System.Collections.Generic;
using System.Text;

using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using Windows.Storage;
using Xamarin.Forms;

namespace ProductCatalog.Mobile.DAO
{
    public class StringConnection
    {
        string dbName = "MeuBanco.db";
        public string GetString()
        {
            if (Device.RuntimePlatform == Device.UWP)
            {
                string path = ApplicationData.Current.LocalFolder.Path + "\\" + dbName;
                return path;
            }
            else
            {
                //cria uma pasta base local para o dispositivo
                var pasta = new LocalRootFolder();
                //cria o arquivo
                var arquivo =
                    pasta.CreateFile(dbName, PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);
                //abre o BD
                return arquivo.Path;
            }

          
        }

    }
}
