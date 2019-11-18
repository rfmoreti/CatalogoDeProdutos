using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        public async Task<SauloWrapper<T>> PostObj(T obj)
        {
            try
            {
                var cliente = GetCliente();
                StringContent objSerealizado = SerealizarObj(obj);
                var retorno = await cliente.PostAsync(this.ApiName, objSerealizado);

                if (retorno.IsSuccessStatusCode)
                {
                    var retornoJson = await retorno.Content.ReadAsStringAsync();
                    T objConvertido = JsonConvert.DeserializeObject<T>(retornoJson);

                    return new SauloWrapper<T>
                    {
                        Success = true,
                        Value = objConvertido,
                        msg = ""
                    };
                }
                else
                    return new SauloWrapper<T> {Success = false, msg = retorno.ReasonPhrase };
               
            }
            catch (Exception e)
            {

                return new SauloWrapper<T>
                {
                    Success = false,
                    msg = e.Message
                };
            }
        }

        private StringContent SerealizarObj(T obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            return new StringContent(str, Encoding.UTF8, "application/json");
        }
    }

    public class SauloWrapper<T>
    {
        public bool Success;
        public T Value;
        public string msg;
    }

}
