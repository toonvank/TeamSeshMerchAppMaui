using AndroidX.ConstraintLayout.Helper.Widget;

namespace TeamSeshMerchAppMaui;

public partial class FilterPage : ContentPage
{
	Methods m = new Methods();
    public FilterPage()
	{
		InitializeComponent();
		grStock.ItemsSource = m.availability();
    }

	private void grStock_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataPass.filteredList =
		  (List<rssChannelItem>)(from item in DataPass.rssChannel
		  where item.availabilityField == m.availability()[grStock.SelectedIndex]
		  select item);
    }
}