using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;
//using static Android.Content.ClipData;

namespace TeamSeshMerchAppMaui;

public partial class MainPage : ContentPage
{
    Methods m = new Methods();
    Button b = new Button();
    Sources s = new Sources();
    int newOrLessitems = 0;
    public MainPage()
    {
        InitializeComponent();
        btnInput_Clicked(b, System.EventArgs.Empty);
        carouselSwitch(b, System.EventArgs.Empty);
    }
    private async Task WaitAndExecute(int milisec,Action actionToExecute)
    {
        await Task.Delay(milisec);
        actionToExecute();
        carouselSwitch(b, System.EventArgs.Empty);
    }
    private async void carouselSwitch(object sender, EventArgs e)
    {
        try
        {
            await WaitAndExecute(4000, () => carousel.Position = carousel.Position+1);
        }
        catch (Exception)
        {
            carousel.Position = 0;
        }
    }

    private async void btnInput_Clicked(object sender, EventArgs e)
    {
        //activity.IsRunning = true;
        //await m.FillProductList();
        //albumCollection.ItemsSource = DataPass.rssChannel;
        //activity.IsRunning = false;
        //carousel.ItemsSource = DataPass.rssChannel;
        //grStock.ItemsSource = m.availability();
        //grStock.ItemsSource.Add("all");
        //int producCount = Preferences.Default.Get("productCount", 0);
        //newOrLessitems = DataPass.rssChannel.Count - producCount;
        //producNumber.Text = $"{DataPass.rssChannel.Count}";
        //Preferences.Default.Set("productCount", DataPass.rssChannel.Count);
        //fillupSources();

        using var client = new HttpClient();
        var content = await client.GetStringAsync($"https://api.exchangerate.host/convert?from=USD&to=EUR");
        var details = JObject.Parse(content);
        var please = details["result"];
        DataPass.eurExchange = double.Parse(please.ToString());

        using var clientt = new HttpClient();
        var contentt = await client.GetStringAsync($"https://api.exchangerate.host/convert?from=USD&to=GBP");
        var detailss = JObject.Parse(content);
        var pleasee = details["result"];
        DataPass.gbpExchange = double.Parse(please.ToString());

        grCurrency.SelectedIndex = Preferences.Default.Get("currency", 2);
    }

    private async void tapFrame_Tapped(object sender, EventArgs e)
    {
        if (absLayout.IsVisible == false && absLayout2.IsVisible == false)
        {
            DataPass.passedAlbum.Clear();
            Frame bs = (Frame)sender;
            rssChannelItem a = (rssChannelItem)bs.BindingContext;
            rssChannelItem album = new rssChannelItem();
            album = a;
            DataPass.passedAlbum.Add(album);
            //Grid g = (Grid)bs.Children[0];
            //Label v = (Label)g.Children[1];
            //v.Opacity = 0;
            await Shell.Current.GoToAsync(nameof(DetailPage));
        }
        else
        {
            await absLayout.TranslateTo(0, 40, 500);
            absLayout.IsVisible = false;
        }
    }

    private async void btnFilter_Clicked(object sender, EventArgs e)
    {
        if (absLayout.IsVisible == true)
        {
            await absLayout.TranslateTo(0, 40, 500);
            absLayout.IsVisible = false;
            
        }
        else
        {
            absLayout.IsVisible = true;
            await absLayout.TranslateTo(0, -40, 500);
        }
        
    }
    private async void grStock_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (grStock.SelectedIndex != 2)
        {
            carousel.ItemsSource =
                from item in DataPass.rssChannel
                where item.availabilityField == m.availability()[grStock.SelectedIndex]
                select item;
            albumCollection.ItemsSource = carousel.ItemsSource;
            await absLayout.TranslateTo(0, 40, 500);
            absLayout.IsVisible = false;
        }
        else
        {
            albumCollection.ItemsSource = DataPass.rssChannel;
            carousel.ItemsSource = DataPass.rssChannel;
        }
        grStock.TextColor = Colors.White;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        carousel.ItemsSource =
            from item in DataPass.rssChannel
            where int.Parse(item.priceField.Substring(0, item.priceField.IndexOf("."))) > int.Parse(minPrice.Text)
            && int.Parse(item.priceField.Substring(0, item.priceField.IndexOf("."))) < int.Parse(maxPrice.Text)
            select item;
        albumCollection.ItemsSource = carousel.ItemsSource;
        absLayout.IsVisible = false;
    }

    private async void btnReset_Clicked(object sender, EventArgs e)
    {
        Button b = new Button();
        btnInput_Clicked(b, System.EventArgs.Empty);
        await absLayout.TranslateTo(0, 40, 500);
        absLayout.IsVisible = false;
    }

    private async void btnBag_Clicked(object sender, EventArgs e)
    {
        int products = DataPass.rssChannel.Count;
        int notav = 0;
        int available = 0;
        foreach (var item in DataPass.rssChannel)
        {
            if (item.availabilityField == "out of stock")
            {
                notav++;
            }
            else
            {
                available++;
            }
        }
        string text = string.Empty;
        if (newOrLessitems >= 0)
        {
            text = $"{newOrLessitems} new items since you opened the app last time.";
        }
        else
        {
            text = $"{newOrLessitems} items have been removed since you opened the app last time.";
        }
        string show = $"There are currently {products} products online.\n{notav} out of stock and {available} available.\n{text}";
        await DisplayAlert("ProductInfo", show, "OK");
    }

    private async void btnSource_Clicked(object sender, EventArgs e)
    {
        
        if (absLayout2.IsVisible == true)
        {
            await absLayout2.TranslateTo(0, 40, 500);
            absLayout2.IsVisible = false;

        }
        else
        {
            absLayout2.IsVisible = true;
            await absLayout2.TranslateTo(0, -40, 500);
        }
    }
    private void fillupSources()
    {
        foreach (var item in s.AddLinks())
        {
            CheckBox b = new CheckBox();
            Label l = new Label();
            HorizontalStackLayout h = new HorizontalStackLayout();
            string sesh = item.Substring(0, item.IndexOf("/products.xml"));
            l.Text = sesh.Remove(0,8);
            b.CheckedChanged += OnColorsRadioButtonCheckedChanged;
            l.TextColor = Colors.White;
            h.Add(b);
            h.Add(l);
            itemContent.Add(h);
        }
    }
    void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        CheckBox s = sender as CheckBox;
        HorizontalStackLayout r = s.Parent as HorizontalStackLayout;
        if (s.IsChecked == true)
        {
            DataPass.whichOneRemove.Add(r.Children.IndexOf(s));
        }
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        activity.IsRunning = true;
        await m.FillProductListCustSource();
        albumCollection.ItemsSource = DataPass.rssChannel;
        activity.IsRunning = false;
        carousel.ItemsSource = DataPass.rssChannel;
        grStock.ItemsSource = m.availability();
        grStock.ItemsSource.Add("all");
        producNumber.Text = $"{DataPass.rssChannel.Count}";
        await absLayout2.TranslateTo(0, 40, 500);
        absLayout2.IsVisible = false;
    }

    private void skipBack_Clicked(object sender, EventArgs e)
    {
        try
        {
            carousel.Position = carousel.Position - 1;
        }
        catch (Exception)
        {

            carousel.Position = DataPass.rssChannel.Count ;
        }
    }

    private void skipFrwd_Clicked(object sender, EventArgs e)
    {
        try
        {
            carousel.Position = carousel.Position + 1;
        }
        catch (Exception)
        {
            carousel.Position = 0;
        }
    }

    private async void grCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataPass.currencyIndex = grCurrency.SelectedIndex;

        albumCollection.ItemsSource = "";
        carousel.ItemsSource = "";

        activity.IsRunning = true;
        await m.FillProductList();
        albumCollection.ItemsSource = DataPass.rssChannel;
        activity.IsRunning = false;
        carousel.ItemsSource = DataPass.rssChannel;
        grStock.ItemsSource = m.availability();
        grStock.ItemsSource.Add("all");
        int producCount = Preferences.Default.Get("productCount", 0);
        newOrLessitems = DataPass.rssChannel.Count - producCount;
        producNumber.Text = $"{DataPass.rssChannel.Count}";
        Preferences.Default.Set("productCount", DataPass.rssChannel.Count);
        fillupSources();

        albumCollection.ItemsSource = DataPass.rssChannel;
        carousel.ItemsSource = DataPass.rssChannel;

        grCurrency.TextColor = Colors.White;

        Preferences.Default.Set("currency", grCurrency.SelectedIndex);
    }

    private async void fetch_Clicked(object sender, EventArgs e)
    {
        albumCollection.ItemsSource = "";
        carousel.ItemsSource = "";
        activity.IsRunning = true;
        await m.FillProductList();
        albumCollection.ItemsSource = DataPass.rssChannel;
        activity.IsRunning = false;
        carousel.ItemsSource = DataPass.rssChannel;
        grStock.ItemsSource = m.availability();
        grStock.ItemsSource.Add("all");
        int producCount = Preferences.Default.Get("productCount", 0);
        newOrLessitems = DataPass.rssChannel.Count - producCount;
        producNumber.Text = $"{DataPass.rssChannel.Count}";
        Preferences.Default.Set("productCount", DataPass.rssChannel.Count);
        fillupSources();
    }
}

