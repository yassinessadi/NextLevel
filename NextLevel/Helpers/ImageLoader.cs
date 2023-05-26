
namespace NextLevel.Helpers;

public static class ImageLoader
{
	public static async Task<byte[]> ImageLoaderAync(string url)
	{
		await Task.Delay(1000);
		using (var client = new HttpClient())
		{
			var response = await client.GetAsync(url);
			byte[] data;
			using (var stream = await response.Content.ReadAsStreamAsync())
			using (MemoryStream ms = new MemoryStream())
			{
				await stream.CopyToAsync(ms);
				 data = ms.ToArray();
			}
			//var StreamImage = ImageSource.FromStream(() => new MemoryStream(data));
			return data;
		}

	}
}
