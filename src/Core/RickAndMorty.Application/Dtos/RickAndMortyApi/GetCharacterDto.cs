﻿using RickAndMorty.Application.RickAndMortyApi.Models;

namespace RickAndMorty.Application.RickAndMortyApi.Dtos
{
    public class GetCharacterDto : IRickAndMortyApiDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public GetLocationDto origin { get; set; }
        public string originId
        {
            get
            {
               if(origin.url.Length > 8)
                {
                    String urlWithoutPrefix = origin.url.Substring(7);
                    String[] urlSegments = urlWithoutPrefix.Split("/");
                    return urlSegments[urlSegments.Length - 1];
                } else
                {
                    return "";
                }
            }
        }
        public GetLocationDto location { get; set; }
        public string locationId
        {
            get
            {
                String urlWithoutPrefix = location.url.Substring(7);
                String[] urlSegments = urlWithoutPrefix.Split("/");
                return urlSegments[urlSegments.Length - 1];
            }
        }

        public List<string> episode { get; set; }
        public List<string> episodeIdList 
        { 
            get 
            {
               return episode.Select(url =>
                {
                    String urlWithoutPrefix = url.Substring(7);
                    String[] urlSegments = urlWithoutPrefix.Split("/");
                    return urlSegments[urlSegments.Length - 1];
                }).ToList();
            } 
        }

        public string created { get; set; }
    }

}
