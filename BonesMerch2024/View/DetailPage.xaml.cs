using BonesAlbumInfoApp.Model;
using BonesAlbumInfoApp.PassObjects;

namespace TeamSeshMerchAppMaui;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
        List<rssChannelItem> rssChannels = new List<rssChannelItem>();
        rssChannels = DataPass.passedAlbum;
        rssChannels[0].descriptionField = rssChannels[0].descriptionField.Replace("\r", "").Replace("\n\n", "\n");
        albumCollection.ItemsSource = rssChannels;
		this.Title = DataPass.passedAlbum[0].idField.ToString();
        crsImages.ItemsSource = imageSources();
    }

	private async void visitSite_Clicked(object sender, EventArgs e)
	{
        try
        {
            Uri uri = new Uri(DataPass.passedAlbum[0].linkField);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Something went wrong opening link", ex.Message, "OK");
        }
    }
    public List<string> imageSources(){
        List<string> images = new List<string>
        {
            DataPass.passedAlbum[0].image_linkField
        };
        foreach (var item in DataPass.passedAlbum[0].additional_image_linkField.Split(","))
        {
            images.Add(item);
        }
        return images;
    }
    private void skipBack_Clicked(object sender, EventArgs e)
    {
        try
        {
            crsImages.Position = crsImages.Position - 1;
        }
        catch (Exception){}
    }

    private void skipFrwd_Clicked(object sender, EventArgs e)
    {
        try
        {
            crsImages.Position = crsImages.Position + 1;
        }
        catch (Exception){}
    }
}