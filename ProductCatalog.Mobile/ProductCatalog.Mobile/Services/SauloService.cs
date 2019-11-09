using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Mobile.Services
{
    public class SauloService<T> : HttpService
    {
        public SauloService()
        {
            BaseURL = "http://localhost:2545";
        }

        public async Task<SauloWrapper<IEnumerable<T>>> GetLista()
        {
            try
            {
                var client = GetCliente();
                var retorno = await client.GetAsync(ApiName);


                if (retorno.IsSuccessStatusCode)
                {
                    var json = await retorno.Content.ReadAsStringAsync();
                    var lista = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
                    return new SauloWrapper<IEnumerable<T>>
                    {
                        Success = true,
                        Value = lista
                    };
                }

                else
                    return new SauloWrapper<IEnumerable<T>> { Success = false };
            }
            catch (Exception e)
            {

                return new SauloWrapper<IEnumerable<T>>
                {
                    Success = false,
                    msg = e.Message
                };
            }
            
        }

        public class SauloWrapper<T>
        {
            public bool Success;
            public T Value;
            public string msg;
        }

    }
}
