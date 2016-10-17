using HttpExemple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpExemple.Controller
{
    public class BaseApi
    {
        private string Url = "https://viacep.com.br/ws/";
        //Passando uma string de parâmetro para poder fazer o GET e retornar os dados da localização!
        public async Task<HttpResponseMessage> GET(string CEP)
        {
            var client = new HttpClient();
            var uri = new Uri(string.Concat(Url, CEP,"/json/"));
            return await client.GetAsync(uri);
        }

        //Criado um método do tipo assíncrono e pasado uma model como parâmetro para ser preenchida!
        //Exemplo :
        //  var objectModel = new UsersModel 
        // {
        //   Login = "MeuLogin",
        //   Senha = "MinhaSenha"    
        // };
        public async Task<HttpResponseMessage> POST(UsersModel objectModel)
        {
            var client = new HttpClient();
            var uri = new Uri(string.Concat(Url, "LocalDePost"));
            return await client.PutAsJsonAsync(uri, objectModel);
        }
    }
}
