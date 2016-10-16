using HttpExemple.Controller;
using HttpExemple.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HttpExemple
{

    public sealed partial class MainPage : Page
    {
        private BaseApi baseApi = new BaseApi();
        //private string _Cep = "50010928";
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(cepField.Text))
            {
                var contet = new MessageDialog("Preencha o campo de CEP");
                await contet.ShowAsync();
            }
            else
            {
                //passando o campo de text para o método!
                var response = await baseApi.GET(cepField.Text);
                if(response.IsSuccessStatusCode)
                {
                    //Disserializando os dados vindos do servidor de JSON para MODEL!
                    var ListResul = JsonConvert.DeserializeObject<List<CepModel>>(await response.Content.ReadAsStringAsync());


                }
            }
        }
    }
}
