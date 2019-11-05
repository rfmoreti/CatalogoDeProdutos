using System;
using System.Collections.Generic;
using System.Text;

using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;


namespace ProductCatalog.Mobile.DAO
{
    public class StringConnection
    {
        public string GetString()
        {
            //cria uma pasta base local para o dispositivo
            var pasta = new LocalRootFolder();
            //cria o arquivo
            var arquivo =
                pasta.CreateFile("MeuBanco.db", CreationCollisionOption.OpenIfExists);
            //abre o BD
            return arquivo.Path;
        }

    }
}
