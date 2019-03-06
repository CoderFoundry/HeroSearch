using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace HeroSearch.MarvelApi
{
    public class Marvel
    {
        private const string BASE_URL = "http://gateway.marvel.com/v1/public";
        private readonly string  _publicKey = "Your-Marvel-PUBLIC-Api-Key-Here";
        private readonly string _privateKey = "Your-Marvel-PRIVATE-Api-Key-Here";
        private static HttpClient _client = new HttpClient();
        

        //example how call to MArvel API
        //ts = timestamp
        //Hash =md5(ts+privateKey+publicKey)
        //http://gateway.marvel.com/v1/public/comics?ts=1&apikey=1234&hash=ffd275c5130566a2916217b101f26150

        public Marvel()
        {


        }
        /// <summary>
        /// Returns a list of Characters
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="NameStartsWith"></param>
        /// <param name="ModifiedSince"></param>
        /// <param name="Comics"></param>
        /// <param name="Series"></param>
        /// <param name="Events"></param>
        /// <param name="Stories"></param>
        /// <param name="Order"></param>
        /// <param name="Limit"></param>
        /// <param name="Offset"></param>
        /// <returns></returns>
        public async Task<CharacterDataWrapper> GetCharacters(string Name = null,
                                            string NameStartsWith = null,
                                            DateTime? ModifiedSince = null,
                                            IEnumerable<int> Comics = null,
                                            IEnumerable<int> Series = null,
                                            IEnumerable<int> Events = null,
                                            IEnumerable<int> Stories = null,
                                            IEnumerable<OrderBy> Order = null,
                                            int? Limit = null,
                                            int? Offset = null)
        {
            
            //we need a timestamp
            string timestamp = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            //we need use a hash to call the marvel api
            string s = String.Format("{0}{1}{2}",timestamp, _privateKey, _publicKey);
            
            string hash = CreateHash(s);
            //format the url string  with search critieria          
            string requestURL = String.Format(BASE_URL + "/characters?ts={0}&apikey={1}&hash={2}&name={3}", timestamp,_publicKey,hash,Name);
            
            var url = new Uri(requestURL);
                
            var response = await _client.GetAsync(url);
                        
            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync(); 
            }

            CharacterDataWrapper cdw = JsonConvert.DeserializeObject<CharacterDataWrapper>(json);
            return cdw;
        }
        /// <summary>
        /// Retruns a list of comics for a given Character
        /// </summary>
        /// <param name="CharacterId"></param>
        /// <param name="Format"></param>
        /// <param name="FormatType"></param>
        /// <param name="NoVariants"></param>
        /// <param name="DateDescript"></param>
        /// <param name="DateRangeBegin"></param>
        /// <param name="DateRangeEnd"></param>
        /// <param name="HasDigitalIssue"></param>
        /// <param name="ModifiedSince"></param>
        /// <param name="Creators"></param>
        /// <param name="Series"></param>
        /// <param name="Events"></param>
        /// <param name="Stories"></param>
        /// <param name="SharedAppearances"></param>
        /// <param name="Collaborators"></param>
        /// <param name="Order"></param>
        /// <param name="Limit"></param>
        /// <param name="Offset"></param>
        /// <returns></returns>
        public async Task<ComicDataWrapper> GetComicsForCharacter(int CharacterId,
                                                        ComicFormat? Format = ComicFormat.Comic,
                                                        ComicFormatType? FormatType = ComicFormatType.Comic,
                                                        bool? NoVariants = null,
                                                        DateDescriptor? DateDescript = null,
                                                        DateTime? DateRangeBegin = null,
                                                        DateTime? DateRangeEnd = null,
                                                        bool? HasDigitalIssue = null,
                                                        DateTime? ModifiedSince = null,
                                                        IEnumerable<int> Creators = null,
                                                        IEnumerable<int> Series = null,
                                                        IEnumerable<int> Events = null,
                                                        IEnumerable<int> Stories = null,
                                                        IEnumerable<int> SharedAppearances = null,
                                                        IEnumerable<int> Collaborators = null,
                                                        IEnumerable<OrderBy> Order = null,
                                                        int? Limit = null,
                                                        int? Offset = null)
        {


            //we need a timestamp
            string timestamp = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
            //we need use a hash to call the marvel api
            string s = String.Format("{0}{1}{2}", timestamp, _privateKey, _publicKey);
            string hash = CreateHash(s);
            string requestURL = String.Format(BASE_URL + "/characters/{3}/comics?ts={0}&apikey={1}&hash={2}&format=comic&formatType=comic&limit=30", timestamp, _publicKey, hash, CharacterId);

            var url = new Uri(requestURL);

            var response = await _client.GetAsync(url);

            string json;
            using (var content = response.Content)
            {
                json = await content.ReadAsStringAsync();
            }
            
            ComicDataWrapper cdw = JsonConvert.DeserializeObject<ComicDataWrapper>(json);

            return cdw;            
        }

        private string CreateHash(string input)
        {
              var hash = String.Empty;
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                    StringBuilder sBuilder = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }

                    hash = sBuilder.ToString();
                }
                return hash;
                        
        }

    }
    public class MarvelError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }

    public class MarvelUrl
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class MarvelImage
    {
        public string Path { get; set; }
        public string Extension { get; set; }
        public override string ToString()
        {
            return string.Format("{0}.{1}", Path, Extension);
        }
        public string ToString(Image size)
        {
            return string.Format("{0}{1}.{2}", Path, size.ToParameter(), Extension);
        }
    }
    public class TextObject
    {
        public string Type { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }

}
