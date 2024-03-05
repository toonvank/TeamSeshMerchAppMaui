using Microsoft.Extensions.Logging;
using BonesAlbumInfoApp.ViewModel;
using CommunityToolkit.Maui;
using BonesAlbumInfoApp;

namespace BonesMerch2024
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            //builder.Services.AddTransient<MusicPlayerViewModel>();
            //builder.Services.AddTransient<MusicPlayer>();
            //builder.Services.AddTransient<AlbumPageViewModel>();
            //builder.Services.AddTransient<MainPage>();
            //builder.Services.AddTransient<AlbumInfoViewModel>();
            //builder.Services.AddTransient<AlbumInfo>();
            builder.Services.AddTransient<Merch>();
            builder.Services.AddTransient<MerchViewModel>();
            //builder.Services.AddTransient<Account>();
            //builder.Services.AddTransient<Register>();
            //builder.Services.AddTransient<MyAccount>();
            //builder.Services.AddTransient<UpdateAccount>();
            //builder.Services.AddTransient<myFavoritesViewModel>();
            //builder.Services.AddTransient<myFavorites>();
            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

            return builder.Build();
        }
    }
}
