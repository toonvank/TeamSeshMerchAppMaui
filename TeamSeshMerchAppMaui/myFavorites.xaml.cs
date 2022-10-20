namespace TeamSeshMerchAppMaui;
using AndroidApp = Android.App.Application;

public partial class myFavorites : ContentPage
{
	public myFavorites()
	{
		InitializeComponent();
		
		List<rssChannelItem> items = new List<rssChannelItem>();
		foreach (var item in DataPass.favorItems)
		{
			for (int i = 0; i < DataPass.rssChannel.Count; i++)
			{
				if (DataPass.rssChannel[i].idField == item)
				{
					items.Add(DataPass.rssChannel[i]);
                }
			}

        }
        albumCollection.ItemsSource = items;

    }

	private async void tapFrame_Tapped(object sender, EventArgs e)
	{
        Frame bs = (Frame)sender;
        rssChannelItem a = (rssChannelItem)bs.BindingContext;
        try
        {
            Uri uri = new Uri(a.linkField);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Something went wrong opening link", ex.Message, "OK");
        }
    }
    string sex = Path.Combine(AndroidApp.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDownloads).AbsolutePath, "favItems.txt");
    private void Button_Clicked(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Grid g = (Grid)btn.Parent;
        Frame f = (Frame)g.Children[0];
        rssChannelItem a = (rssChannelItem)f.BindingContext;

        using (StreamWriter sw = new StreamWriter(sex))
        {
            DataPass.favorItems.Remove(a.idField);
            foreach (var item in DataPass.favorItems)
            {
                sw.WriteLine(item);
            }
        }

        List<rssChannelItem> items = new List<rssChannelItem>();
        foreach (var item in DataPass.favorItems)
        {
            for (int i = 0; i < DataPass.rssChannel.Count; i++)
            {
                if (DataPass.rssChannel[i].idField == item)
                {
                    items.Add(DataPass.rssChannel[i]);
                }
            }

        }
        albumCollection.ItemsSource = items;
    }
}