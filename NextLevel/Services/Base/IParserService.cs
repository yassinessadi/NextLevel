using NextLevel.Models;

namespace NextLevel.Services.Base
{
    public interface IParserService
    {
        public Task<string> GetPlayList(string URL);
    }
}
