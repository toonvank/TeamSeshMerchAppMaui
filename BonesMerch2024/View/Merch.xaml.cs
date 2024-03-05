using BonesAlbumInfoApp.Class;
using BonesAlbumInfoApp.Model;
using BonesAlbumInfoApp.PassObjects;
using BonesAlbumInfoApp.ViewModel;
using FireSharp.Interfaces;
using System.Collections.ObjectModel;
using TeamSeshMerchAppMaui;

namespace BonesAlbumInfoApp;
//using AndroidApp = Android.App.Application;

public partial class Merch : ContentPage
{
    Methods m = new Methods();
    Button b = new Button();
    Sources s = new Sources();
    int newOrLessitems = 0;
    public Merch(MerchViewModel mv)
    {
        InitializeComponent();
        BindingContext = mv;
        //grStock.ItemsSource = m.availability();
        fillupSources();
    }
    private async void grCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        //activity.IsRunning = true;
        //Preferences.Default.Set("currency", grCurrency.SelectedIndex);
        //DataPass.currencyIndex = grCurrency.SelectedIndex;
        //await m.LoadMerch();
        //UpdateCustSourceCommand.Command.Execute("");
        //activity.IsRunning = false;
    }

    private async void tapFrame_Tapped(object sender, EventArgs e)
    {
        if (absLayout.IsVisible == false && absLayout2.IsVisible == false)
        {
            DataPass.passedAlbum.Clear();
            Frame bs = (Frame)sender;
            rssChannelItem a = (rssChannelItem)bs.BindingContext;
            rssChannelItem album = a;
            DataPass.passedAlbum.Add(album);
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
        //activity.IsRunning = true;
        //await m.LoadMerch();
        //if (grStock.SelectedIndex != 2)
        //{
        //    ObservableCollection<rssChannelItem> items = new ObservableCollection<rssChannelItem>();
        //    foreach (var item in DataPass.loadedMerch)
        //    {
        //        if (item.availabilityField == m.availability()[grStock.SelectedIndex])
        //        {
        //            items.Add(item);
        //        }
        //    }
        //    StockCommand.Command.Execute(items);
        //}
        //else
        //{
        //    UpdateCustSourceCommand.Command.Execute("");
        //}
        //grStock.TextColor = Colors.White;
        //activity.IsRunning = false;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //if (int.Parse(maxPrice.Text) > int.Parse(minPrice.Text))
        //{
        //    DataPass.maxPrice = int.Parse(maxPrice.Text);
        //    DataPass.minPrice = int.Parse(minPrice.Text);
        //    FilterPriceCommand.Command.Execute("");
        //    absLayout.IsVisible = false;
        //}
        //else
        //{
        //    await DisplayAlert("Please try again", "Can't filter. Min price is larger than max price", "OK");
        //    minPrice.Text = String.Empty;
        //    maxPrice.Text = String.Empty;
        //    minPrice.Focus();
        //}
    }

    private async void btnBag_Clicked(object sender, EventArgs e)
    {
        int products = DataPass.loadedMerch.Count;
        int notav = 0;
        int available = 0;
        foreach (var item in DataPass.loadedMerch)
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
            l.Text = sesh.Remove(0, 8);
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
        //if (DataPass.whichOneRemove.Count != 0)
        //{
        //    activity.IsRunning = true;
        //    albumCollection.ItemsSource = "";
        //    carousel.ItemsSource = "";
        //    await m.FillProductListCustSource();
        //    albumCollection.ItemsSource = DataPass.loadedMerch;
        //    carousel.ItemsSource = DataPass.loadedMerch;
        //    grStock.ItemsSource = m.availability();
        //    producNumber.Text = $"{DataPass.loadedMerch.Count}";
        //    await absLayout2.TranslateTo(0, 40, 500);
        //    absLayout2.IsVisible = false;
        //    UpdateCustSourceCommand.Command.Execute("");
        //    activity.IsRunning = false;
        //}
        //else
        //{
        //    await DisplayAlert("Error in save", "You haven't selected any sources.", "OK");
        //}
    }

    private void skipBack_Clicked(object sender, EventArgs e)
    {
        try
        {
            carousel.Position = carousel.Position - 1;
        }
        catch (Exception)
        {

            carousel.Position = DataPass.rssChannel.Count;
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
    //string sex = Path.Combine(AndroidApp.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath, "favItems.txt");
    //IFirebaseConfig fcon = new FireSharp.Config.FirebaseConfig()
    //{
    //    AuthSecret = "O1itSeLoiYkjfMjzk3iv9q4wK99k70VkJ0COQPMZ",
    //    BasePath = "https://bonesinfoapp-default-rtdb.europe-west1.firebasedatabase.app/"
    //};
    IFirebaseClient client;
    //private async void iLoveThis_Clicked(object sender, EventArgs e)
    //{
    //    string UID = Preferences.Default.Get("userid", "Unknown");
    //    client = new FireSharp.FirebaseClient(fcon);

    //    ImageButton s = (ImageButton)sender;
    //    FileImageSource f = (FileImageSource)s.Source;

    //    ImageButton i = (ImageButton)sender;
    //    rssChannelItem r = (rssChannelItem)i.BindingContext;

    //    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey: "AIzaSyAjUEQRl2QC5-Zt0Skxk9-53rKHtw7dxkM"));
    //    var setter = client.Get($"Users/{UID}/Likes/");
    //    List<int> userLikesList = new List<int>();
    //    if (setter.Body != "null")
    //    {
    //        string userLikes = setter.Body.Substring(1, setter.Body.Length - 2);
    //        string[] userLikesArray = userLikes.Split(',');
    //        foreach (string item in userLikesArray)
    //        {
    //            if (item != "null")
    //            {
    //                userLikesList.Add(int.Parse(item));
    //            }
    //        }
    //    }
    //    if (f.File == "heart")
    //    {
            
    //        if (!userLikesList.Contains(r.idField))
    //        {
                
    //            if (UID == "Unknown")
    //            {
    //                await DisplayAlert("Alert", "You are not logged in. Please log in.", "OK");

    //            }
    //            else
    //            {
    //                s.Source = "filledheart";
    //                await s.ScaleTo(1.3, 600);
    //                await s.ScaleTo(1, 70);
    //                //var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey: "AIzaSyAjUEQRl2QC5-Zt0Skxk9-53rKHtw7dxkM"));
    //                userLikesList.Add(r.idField);
    //                var setterr = client.Set($"Users/{UID}/" + "Likes", userLikesList);
    //            }
    //        }
    //        else
    //        {
    //            await DisplayAlert("Reminder", "This item is already in your favorites.", "OK");
    //        }
    //    }
    //    else if (f.File == "filledheart")
    //    {
    //        if (UID == "Unknown")
    //        {
    //            await DisplayAlert("Alert", "You are not logged in. Please log in.", "OK");

    //        }
    //        else
    //        {
    //            foreach (var item in userLikesList)
    //            {
    //                if (item == r.idField)
    //                {
    //                    int index = userLikesList.IndexOf(item);
    //                    var remove = client.Delete($"Users/{UID}/Likes/" + index);
    //                    s.Source = "heart";
    //                }
    //            }
    //        }
    //    }
    //}

    private async void btnHearts_Clicked(object sender, EventArgs e)
    {
        //activity.IsRunning = true;
        //await Shell.Current.GoToAsync(nameof(myFavorites));
        //activity.IsRunning = false;
    }
}