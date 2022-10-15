namespace TeamSeshMerchAppMaui;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
		albumCollection.ItemsSource = DataPass.passedAlbum;
		this.Title = DataPass.passedAlbum[0].titleField;
    }
}