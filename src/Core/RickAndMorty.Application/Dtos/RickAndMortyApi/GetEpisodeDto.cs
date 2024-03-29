﻿using RickAndMorty.Application.RickAndMortyApi.Models;

namespace RickAndMorty.Application.RickAndMortyApi.Dtos
{
    public class GetEpisodeDto : IRickAndMortyApiDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public string url { get; set; }
        public string created { get; set; }
        public List<string> characters { get; set; }
        public List<string> characterIdList
        {
            get
            {
               if(characters != null && characters.Count > 0)
                {
                    return characters.Select(url =>
                    {
                        String urlWithoutPrefix = url.Substring(7);
                        String[] urlSegments = urlWithoutPrefix.Split("/");
                        return urlSegments[urlSegments.Length - 1];
                    }).ToList();
                }
                else
                {
                    return new List<string>();
                }
            }
        }
    }

}
