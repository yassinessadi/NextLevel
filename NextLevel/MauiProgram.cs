using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
#if __ANDROID__
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using NextLevel.Services.Base;
using NextLevel.Services.ViewServices;
using NextLevel.ViewModel;
using NextLevel.Views;

namespace NextLevel;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseMauiCommunityToolkitMediaElement()
			.UseFFImageLoading()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddTransient<ChannelsPage>();
		builder.Services.AddTransient<ChannelsViewModel>();
		builder.Services.AddTransient<IParserService, ParserService>();
		builder.Services.AddTransient<IDialogService, DialogService>();


//		Microsoft.Maui.Handlers.FlyoutViewHandler.Mapper.AppendToMapping("MyCustomization", (handler, view) =>
//		{
//#if ANDROID
//			handler.PlatformView.SetBackgroundResource(Resource.Drawable.mtrl_bottomsheet_drag_handle);
//#endif
//		});



#if __ANDROID__
		ImageHandler.Mapper.PrependToMapping(nameof(Microsoft.Maui.IImage.Source), (handler, view) => PrependToMappingImageSource(handler, view));
#endif
		return builder.Build();
	}

#if __ANDROID__
	public static void PrependToMappingImageSource(IImageHandler handler, Microsoft.Maui.IImage image)
	{
		handler.PlatformView?.Clear();
		var res = image.DesiredSize;
	}
#endif
}
