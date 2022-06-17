﻿#nullable disable
using System.Net;
using tmdbapi.Repos.IRepos;


namespace tmdbapi.Repos
{
    public class MovieHelper : IMovieHelper
    {

        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<string> Get(string requestURL)
        {
            try
            {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                    | SecurityProtocolType.Tls11
                    | SecurityProtocolType.Tls12;

                using (var result = await _httpClient.GetAsync(requestURL))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        string content = await result.Content.ReadAsStringAsync();
                        return content;
                    }
                    else
                    {
                        string content = await result.Content.ReadAsStringAsync();
                        throw new Exception(content);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
