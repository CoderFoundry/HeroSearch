using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroSearch.MarvelApi
{
    public class SeriesDataWrapper
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public SeriesDataContainer Data { get; set; }
        public string Etag { get; set; }
    }

    public class SeriesDataContainer
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public List<Series> Results { get; set; }
    }

    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResourceURI { get; set; }
        public List<MarvelUrl> Urls { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Rating { get; set; }
        public DateTime Modified { get; set; }
        public MarvelImage Thumbnail { get; set; }
        public ComicList Comics { get; set; }
        public StoryList Stories { get; set; }
        public EventList Events { get; set; }
        public CharacterList Characters { get; set; }
        public CreatorList Creators { get; set; }
        public SeriesSummary Next { get; set; }
        public SeriesSummary Previous { get; set; }
    }

    public class SeriesSummary
    {
        public string ResourceURI { get; set; }
        public string Name { get; set; }
    }

    public class SeriesList
    {
        public int Available { get; set; }
        public int Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<SeriesSummary> Items { get; set; }
    }
}
