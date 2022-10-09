namespace TeamSeshMerchAppMaui;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void btnInput_Clicked(object sender, EventArgs e)
    {
        activity.IsRunning = true;
        Methods m = new Methods();
        await m.FillProductList();
        albumCollection.ItemsSource = DataPass.rssChannel;
        activity.IsRunning = false;
    }

    private async void tapFrame_Tapped(object sender, EventArgs e)
    {
        DataPass.passedAlbum.Clear();
        Frame bs = (Frame)sender;
        rssChannelItem a = (rssChannelItem)bs.BindingContext;
        rssChannelItem album = new rssChannelItem();
        album = a;
        DataPass.passedAlbum.Add(album);
        await Shell.Current.GoToAsync(nameof(DetailPage));
    }
}

