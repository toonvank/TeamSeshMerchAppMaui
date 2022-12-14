using Microsoft.Maui.Controls;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;
using static Android.Graphics.ImageDecoder;
using AndroidApp = Android.App.Application;
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
        try
        {
            using (StreamReader sw = new StreamReader(sex))
            {
                while (!sw.EndOfStream)
                {
                    DataPass.favorItems.Add(int.Parse(sw.ReadLine()));
                }
            }
        }
        catch (Exception)
        {

        }
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
        try
        {
            await m.GetCurrency("GBP");
            await m.GetCurrency("EUR");
            grCurrency.SelectedIndex = Preferences.Default.Get("currency", 2);
        }
        catch (Exception)
        {
            await DisplayAlert("Alert", "Please check your internet connection and restart the application.", "OK");
        }
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (int.Parse(maxPrice.Text) > int.Parse(minPrice.Text))
        {
            carousel.ItemsSource =
            from item in DataPass.rssChannel
            where int.Parse(item.priceField.Substring(0, item.priceField.IndexOf("."))) > int.Parse(minPrice.Text)
            && int.Parse(item.priceField.Substring(0, item.priceField.IndexOf("."))) < int.Parse(maxPrice.Text)
            select item;
            albumCollection.ItemsSource = carousel.ItemsSource;
            absLayout.IsVisible = false;
        }
        else
        {
            await DisplayAlert("Please try again", "Can't filter. Min price is larget than max price", "OK");
            minPrice.Text = String.Empty;
            maxPrice.Text = String.Empty;
            minPrice.Focus();
        }
        
    }

    private async void btnReset_Clicked(object sender, EventArgs e)
    {
        Button b = new Button();

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

        await absLayout.TranslateTo(0, 40, 500);
        absLayout.IsVisible = false;

        minPrice.Text = String.Empty;
        maxPrice.Text = String.Empty;
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
        HorizontalStackLayout h = s.Parent as HorizontalStackLayout;
        if (s.IsChecked == true)
        {
            int who = itemContent.Children.IndexOf(h);
            DataPass.whichOneRemove.Add(itemContent.Children.IndexOf(h));
        }
        else
        {
            DataPass.whichOneRemove.Remove(itemContent.Children.IndexOf(h));
        }
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        albumCollection.ItemsSource = "";
        carousel.ItemsSource = "";

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
    string sex = Path.Combine(AndroidApp.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath, "favItems.txt");
    private async void iLoveThis_Clicked(object sender, EventArgs e)
    {
        ImageButton s = (ImageButton)sender;
        FileImageSource f = (FileImageSource)s.Source;

        ImageButton i = (ImageButton)sender;
        rssChannelItem r = (rssChannelItem)i.BindingContext;

        if (f.File == "heart")
        {
            if (!DataPass.favorItems.Contains(r.idField))
            {
                s.Source = "filledheart";
                await s.ScaleTo(1.3, 600);
                await s.ScaleTo(1, 70);
                using (StreamWriter sw = new StreamWriter(sex, true))
                {
                    sw.WriteLine(r.idField);
                    DataPass.favorItems.Add(r.idField);
                }
            }
            else
            {
                await DisplayAlert("Reminder", "You have already favorited this item.", "OK");
            }
        }
        else if (f.File == "filledheart")
        {
            s.Source = "heart";

            using (StreamWriter sw = new StreamWriter(sex))
            {
                DataPass.favorItems.Remove(r.idField);
                foreach (var item in DataPass.favorItems)
                {
                    sw.WriteLine(item);
                }
            }
        }
    }

    private async void btnHearts_Clicked(object sender, EventArgs e)
    {
        activity.IsRunning = true;
        await Shell.Current.GoToAsync(nameof(myFavorites));
        activity.IsRunning = false;
    }
}

