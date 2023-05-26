using System.Text.RegularExpressions;
using Newtonsoft.Json;
using NextLevel.Helpers;
using NextLevel.Models;

namespace NextLevel.Services.Base
{
    public class ParserService : IParserService
    {

		private List<ChannelModel> Channels;
        public string URLP = Constants.UrlPattern;
        public string LogoP = Constants.LogoPattern;
        public string TitleP = Constants.TitlePattern;
        public async Task<string> GetPlayList(string URL)
        {
			using StreamReader reader = File.OpenText(URL);
			var result = await reader.ReadToEndAsync();
			Channels = new List<ChannelModel>();
			foreach (Match item in Regex.Matches(result, URLP))
			{
				var All = item.Groups[0].Value;
				var Title = Regex.Match(All, TitleP);
				var Img = Regex.Match(All, LogoP);
				//using group-title
				var GroupTitle = Title.Groups[1].Value;

				//List of tv
				var Logo = Img.Groups[1].Value;
				var Name = item.Groups[1].Value;
				var Link = item.Groups[2].Value;
				Channels.Add(new ChannelModel
				{
					ImageUrl = Logo,
					Name = Name,
					Url = Link,
					GroupTitle = GroupTitle
				});
			}
			//var channel = Channels.Skip(PageSize * (PageNumber - 1)).Take(PageSize);
			// ( 3 * (1 - 1 ) ) = 3
			return JsonConvert.SerializeObject(Channels);
		}
    }
}
