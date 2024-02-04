using RickAndMorty.Application.RickAndMortyApi.Models;

namespace RickAndMorty.Application.RickAndMortyApi.Dtos
{
    public class GetLocationDto : IRickAndMortyApiDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string dimension { get; set; }
        public string url { get; set; }        
        public string created { get; set; }
        public List<string> residents { get; set; }
        public List<string> residentIdList
        {
            get
            {
                if (residents != null && residents.Count > 0)
                {
                    return residents.Select(url =>
                    {
                        String urlWithoutPrefix = url.Substring(7);
                        String[] urlSegments = urlWithoutPrefix.Split("/");
                        return urlSegments[urlSegments.Length - 1];
                    }).ToList();
                } else
                {
                    return new List<String>();
                }
             
            }
        }
    }

}
