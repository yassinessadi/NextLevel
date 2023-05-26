using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using NextLevel.Models;
using CommunityToolkit.Mvvm.Input;
using NextLevel.Services.Base;

namespace NextLevel.ViewModel
{
    public partial class ChannelsViewModel : ObservableObject
    {
        private List<ChannelModel> All_entries;

        private int PageSize = 100;
        public ObservableCollection<ChannelModel> entries { get; set; } = new ObservableCollection<ChannelModel>();
        private IParserService _Service;
        public ChannelsViewModel(IParserService Service)
        {
            _Service = Service;
            GetChannel();
		}

        [ObservableProperty]
        bool _isBusy;


        private void GetChannel()
        {
            entries.Clear();
            IsBusy = true;
            Task.Run(async() =>
            {
                var result = await _Service.GetPlayList("\"/data/data/com.companyname.nextlevel/cache/2203693cc04e0be7f4f024d5f9499e13/42f8b176b2a849478645bd2aae067393/playlist_95331685042564_plus.m3u\"");
                //var result = await _Service.GetPlayList("C:\\Users\\Essadi\\Desktop\\playlist_95331685042564_plus.m3u");
				All_entries = JsonConvert.DeserializeObject<List<ChannelModel>>(result);
				//windows// C:\Users\Essadi\Desktop\playlist_9441681660060_plus.m3u
				//android// /data/data/com.companyname.nextlevel/cache/2203693cc04e0be7f4f024d5f9499e13/f462061c512348e793c6bffde880c04d/playlist_40551680897445_plus.m3u
				App.Current.Dispatcher.Dispatch(() =>
                {
                    var RecordOfEntries = All_entries.Take(PageSize).ToList();
                    foreach (var Record in RecordOfEntries)
                    {
                        entries.Add(Record);
                    }
				});
				IsBusy = false;
            });
		}

		[RelayCommand]
		void LoadMoreData()
        {

        }
    } 
}



































































//public ObservableCollection<ChannelModel> Channel { get; private set; } = new();
//public List<ChannelModel> AllChannel { get; private set; }
//public int LoadedItemCount { get; set; } = 0;
//[ObservableProperty]
//private bool _isBusy;
//public Command Open { get; set; }
//IParserService _Service;
//public ChannelsViewModel(IParserService Service)
//{
//	Open = new Command(Loading___);
//	_Service = Service;
//}

//private const int PageSize = 200;

//[RelayCommand]
//async void Loading___()
//{
//	var FileLocation = await FilePicker.PickAsync();
//	if (FileLocation == null)
//		return;

//	IsBusy = true;
//	await Task.Run(async () =>
//	{
//		var Location = FileLocation.FullPath;
//		//var data = await _Service.GetPlayList(Location);
//		var res = await Task.FromResult(await _Service.GetPlayList(Location));
//		AllChannel = JsonConvert.DeserializeObject<List<ChannelModel>>(res);
//		App.Current.Dispatcher.Dispatch(() =>
//		{
//			foreach (var item in AllChannel.Take(PageSize))
//			{
//				Channel.Add(new ChannelModel()
//				{
//					GroupTitle = item.GroupTitle,
//					ImageUrl = item.ImageUrl,
//					Name = item.Name,
//					Url = item.Url
//				});
//			}
//			IsBusy = false;
//		});
//	});
//}

