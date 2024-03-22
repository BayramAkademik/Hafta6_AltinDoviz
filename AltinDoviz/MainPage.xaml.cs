using AltinDoviz.Model;

using System.Text.Json;

namespace AltinDoviz
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
             await Load();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Load();
        }


        List<KurItem> Kurlar ;
        private async Task Load()
        {
            string jsonData = await KarlariYukle();

            var json = JsonSerializer.Deserialize<Root>(jsonData);

            Kurlar = new List<KurItem>();

            Kurlar.Add(new KurItem()
            {
                Doviz = "Dolar",
                Alis = json.USD.alis,
                Satis = json.USD.satis,
                Fark = json.USD.degisim,
                Yon = json.USD.d_yon,
            });

            Kurlar.Add(new KurItem()
            {
                Doviz = "Euro",
                Alis = json.EUR.alis,
                Satis = json.EUR.satis,
                Fark = json.EUR.degisim,
                Yon = json.EUR.d_yon,
            });

            Kurlar.Add(new KurItem()
            {
                Doviz = "Sterlin",
                Alis = json.GBP.alis,
                Satis = json.GBP.satis,
                Fark = json.GBP.degisim,
                Yon = json.GBP.d_yon,
            });

            Kurlar.Add(new KurItem()
            {
                Doviz = "Gram Altın",
                Alis = json.GA.alis,
                Satis = json.GA.satis,
                Fark = json.GA.degisim,
                Yon = json.GA.d_yon,
            });

            Kurlar.Add(new KurItem()
            {
                Doviz = "Çeyrek",
                Alis = json.C.alis,
                Satis = json.C.satis,
                Fark = json.C.degisim,
                Yon = json.C.d_yon,
            });

            Kurlar.Add(new KurItem()
            {
                Doviz = "Gümüş",
                Alis = json.GAG.alis,
                Satis = json.GAG.satis,
                Fark = json.GAG.degisim,
                Yon = json.GAG.d_yon,
            });

            Kurlar.Add(new KurItem()
            {
                Doviz = "Bitcoin",
                Alis = json.BTC.alis,
                Satis = json.BTC.satis,
                Fark = json.BTC.degisim,
                Yon = json.BTC.d_yon,
            });

            Kurlar.Add(new KurItem()
            {
                Doviz = "Etherum",
                Alis = json.ETH.alis,
                Satis = json.ETH.satis,
                Fark = json.ETH.degisim,
                Yon = json.ETH.d_yon,
            });


            listDoviz.ItemsSource = Kurlar;
        }

        private async Task<string> KarlariYukle()
        {
            string jsonData = "";
            HttpClient client = new HttpClient();
            string url = "https://api.genelpara.com/embed/altin.json";
            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            jsonData = await response.Content.ReadAsStringAsync();

            return jsonData;
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            
                string answer = await DisplayPromptAsync("Merhaba", "What's your name?",placeholder: "Type your name");
                if (answer != null)
                {
                    await DisplayAlert("Welcome", $"Hello, {answer}", "Cancel");
                }
            
        }
    }

}
