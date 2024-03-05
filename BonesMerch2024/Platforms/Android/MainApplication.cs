using Android.App;
using Android.Runtime;
using BonesMerch2024;
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]

namespace BonesAlbumInfoApp;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
