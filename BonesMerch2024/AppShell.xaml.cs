using BonesAlbumInfoApp;
using BonesAlbumInfoApp.Class;
using BonesAlbumInfoApp.PassObjects;
using TeamSeshMerchAppMaui;

namespace BonesMerch2024
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
            Routing.RegisterRoute(nameof(Merch), typeof(Merch));

            Methods m = new Methods();
            DataPass.currencyIndex = Preferences.Default.Get("currency", 2);
            _ = m.LoadMerch();

        }
    }
}
