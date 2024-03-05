using BonesAlbumInfoApp.Class;
using BonesAlbumInfoApp.Model;
using BonesAlbumInfoApp.PassObjects;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BonesAlbumInfoApp.ViewModel
{
    [INotifyPropertyChanged]
    public partial class MerchViewModel
    {
        Methods m = new Methods();
        public ObservableCollection<rssChannelItem> MerchItems { get; set; }
        [ObservableProperty]
        public int carPosition = 0;
        [ObservableProperty]
        public bool isRunning = false;
        public MerchViewModel()
        {
            MerchItems = DataPass.loadedMerch;
            carouselSwitch();
        }
        private async Task WaitAndExecute(int milisec, Action actionToExecute)
        {
            await Task.Delay(milisec);
            actionToExecute();
            carouselSwitch();
        }
        private async void carouselSwitch()
        {
            try
            {
                await WaitAndExecute(4000, () => CarPosition = CarPosition + 1);
            }
            catch (Exception)
            {
                CarPosition = 0;
            }

        }
        [RelayCommand]
        private async void FilterThePrice()
        {
            // for some reason my static class "datapass" is not static and has no items so i have to manually reload the merch
            IsRunning = true;
            MerchItems.Clear();
            await m.LoadMerch();
            List<rssChannelItem> currentItems = DataPass.loadedMerch.ToList();
            MerchItems.Clear();
            foreach (var item in currentItems)
            {
                int price = int.Parse(item.priceField.Substring(0, item.priceField.IndexOf(".")));
                if (price > DataPass.minPrice && price < DataPass.maxPrice)
                {
                    MerchItems.Add(item);
                }
            }
            IsRunning = false;
        }
        [RelayCommand]
        public async void UpdateCustSource()
        {
            MerchItems = DataPass.loadedMerch;
        }
        [RelayCommand]
        public async void Stock(ObservableCollection<rssChannelItem> items)
        {
            MerchItems.Clear();
            foreach (var item in items)
            {
                MerchItems.Add(item);
            }
        }
    }
}
