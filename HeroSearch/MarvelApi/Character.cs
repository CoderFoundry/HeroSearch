using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HeroSearch.MarvelApi.Marvel;

namespace HeroSearch.MarvelApi
{
       public class CharacterDataWrapper
        {
            /// <summary>
            /// The HTTP status code of the returned result.,
            /// </summary>
            public int Code { get; set; }
            
            /// <summary>
            /// A string description of the call status.,
            /// </summary>
            public string Status { get; set; }
            
            /// <summary>
            /// The copyright notice for the returned result.,
            /// </summary>
            public string Copyright { get; set; }
            
            /// <summary>
            /// The attribution notice for this result. 
            /// Please display either this notice or the contents of the attributionHTML field on all screens which contain data from the Marvel Comics API.,
            /// </summary>
            public string AttributionText { get; set; }
            
            /// <summary>
            /// An HTML representation of the attribution notice for this result. 
            /// Please display either this notice or the contents of the attributionText field on all screens which contain data from the Marvel Comics API.,
            /// </summary>
            public string AttributionHTML { get; set; }
            
            /// <summary>
            /// The results returned by the call.,
            /// </summary>
            public CharacterDataContainer Data { get; set; }
            /// <summary>
            ///  A digest value of the content returned by the call.
            /// </summary>
            public string Etag { get; set; }
        }

        public class CharacterDataContainer
        {

            /// <summary>
            /// The requested offset (number of skipped results) of the call.,
            /// </summary>
            public int Offset { get; set; }

            /// <summary>
            /// The requested result limit.,
            /// </summary>
            public int Limit { get; set; }

            /// <summary>
            /// The total number of resources available given the current filter set.,
            /// </summary>
            public int Total { get; set; }

            /// <summary>
            /// The total number of results returned by this call.,
            /// </summary>
            public int Count { get; set; }

            /// <summary>
            /// The list of characters returned by the call.
            /// </summary>
            public List<Character> Results { get; set; }
        }

        public class Character
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Modified { get; set; }
            public string ResourceURI { get; set; }
            public List<MarvelUrl> Urls { get; set; }
            public MarvelImage Thumbnail { get; set; }
            public ComicList Comics { get; set; }
            public StoryList Stories { get; set; }
            public EventList Events { get; set; }
            public SeriesList Series { get; set; }
        }

        public class CharacterList
        {
            public int Available { get; set; }
            public int Returned { get; set; }
            public string CollectionURI { get; set; }
            public List<CharacterSummary> Items { get; set; }
        }

        public class CharacterSummary
        {
            public string ResourceURI { get; set; }
            public string Name { get; set; }
            public string Role { get; set; }
        }
    }
