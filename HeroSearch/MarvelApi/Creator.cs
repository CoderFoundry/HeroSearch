using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroSearch.MarvelApi
{
    public class CreatorDataWrapper
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public CreatorDataContainer Data { get; set; }
        public string Etag { get; set; }
    }

    public class CreatorDataContainer
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<Creator> Results { get; set; }
    }

    public class Creator
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string FullName { get; set; }
        public DateTime Modified { get; set; }
        public string ResourceURI { get; set; }
        public List<MarvelUrl> Urls { get; set; }
        public MarvelImage Thumbnail { get; set; }
        public SeriesList Series { get; set; }
        public StoryList Stories { get; set; }
        public ComicList Comics { get; set; }
        public EventList Events { get; set; }
    }

    public class CreatorList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<CreatorSummary> Items { get; set; }
    }

    public class CreatorSummary
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
