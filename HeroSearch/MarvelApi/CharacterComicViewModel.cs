using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroSearch.MarvelApi
{
    public class CharacterComicViewModel
    {
        /// <summary>
        /// return a character and the comics
        /// </summary>
        public Character Character { get; set; }

        public List<Comic> Comics { get; set; }

        public string AttributionText { get; set; }
    }
}
