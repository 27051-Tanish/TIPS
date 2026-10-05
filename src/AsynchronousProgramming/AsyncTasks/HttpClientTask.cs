namespace AsynchronousProgramming.AsyncTasks
{
    /// <summary>
    /// Simulates downloading of content from a URL using the HttpClient class.
    /// </summary>
    public class HttpClientTask
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _url = @"https://www.geeksforgeeks.org/";

        /// <summary>
        /// Downloads content from an url using async and await.
        /// </summary>
        /// <returns>The downloaded content.</returns>
        public async Task<string> DownloadContentAsync()
        {
            string content = await this._httpClient.GetStringAsync(this._url);
            return content;
        }
    }
}
