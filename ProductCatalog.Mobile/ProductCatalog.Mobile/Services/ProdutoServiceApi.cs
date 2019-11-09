using ProductCatalog.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog.Mobile.Services
{
    public class ProdutoServiceApi : SauloService<ProdutoModel>
    {
        public ProdutoServiceApi()
        {
            this.ApiName = "/api/produtos";
        }
    }
}
