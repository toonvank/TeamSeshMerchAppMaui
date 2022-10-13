using Microsoft.Maui.Controls;

namespace TeamSeshMerchAppMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        Button b = new Button();
        btnInput_Clicked(b, System.EventArgs.Empty);
    }

    private async void btnInput_Clicked(object sender, EventArgs e)
    {
        activity.IsRunning = true;
        Methods m = new Methods();
        await m.FillProductList();
        albumCollection.ItemsSource = DataPass.rssChannel;
        activity.IsRunning = false;
        carousel.ItemsSource = DataPass.rssChannel;
    }

    private async void tapFrame_Tapped(object sender, EventArgs e)
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

    private async void btnFilter_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(FilterPage));
    }
}

