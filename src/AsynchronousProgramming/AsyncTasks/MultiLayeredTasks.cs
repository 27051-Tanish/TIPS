using System.Text.Json;
using AsynchronousProgramming.ApplicationConstants;

namespace AsynchronousProgramming.AsyncTasks
{
    /// <summary>
    /// Provides different methods for performing the multilayered async/await task.
    /// </summary>
    public class MultiLayeredTasks
    {
        /// <summary>
        /// Triggers an event when an action is occurred.
        /// </summary>
        public event Action<string>? Notify;

        /// <summary>
        /// Simulates a heavy, CPU-bound data analysis operation.
        /// It is wrapped in Task.Run to offload it from the calling thread.
        /// </summary>
        /// <returns>A target Task of integer.</returns>
        public Task<int> PerformMethodA()
        {
            return Task.Run(() =>
            {
                this.Notify?.Invoke("[MethodA] Starting heavy CPU-bound calculation on background thread...");

                long sum = 0;
                for (int i = 0; i < 5_000_000; i++)
                {
                    sum += i % 10;
                }

                int target = (int)sum;
                this.Notify?.Invoke("[MethodA] CPU calculation complete.");
                return target;
            });
        }

        /// <summary>
        /// MethodB: Orchestrates the workflow by awaiting the CPU-bound operation (MethodA)
        /// and using its results to drive an asynchronous Web Service call.
        /// </summary>
        /// <returns>The text fetched from the web API.</returns>
        public async Task<string> PerformMethodB()
        {
            this.Notify?.Invoke("[MethodB] Initiating layer. Awaiting MethodA...");

            int dataId = await this.PerformMethodA();
            this.Notify?.Invoke($"[MethodB] Received ID {dataId} from MethodA. Preparing HttpClient request...");

            string targetUrl = $"{ConstantVariables.MockApiUrl}{dataId}"; // If the mock API server has no endpoint or resource matching that specific calculated dataId, it will return a 404.
            using (HttpClient client = new HttpClient())
            {
                this.Notify?.Invoke($"[MethodB] Fetching data asynchronously from: {targetUrl}");
                HttpResponseMessage response = await client.GetAsync(targetUrl);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                this.Notify?.Invoke("[MethodB] Web service call successful. Payload received.");
                return jsonResponse;
            }
        }

        /// <summary>
        /// MethodC: The top-level application layer. It awaits the web service response
        /// from MethodB, parses the JSON string, and extracts the metadata.
        /// </summary>
        /// <returns>The element count that is the properties in the json string.</returns>
        public async Task<int> PerformMethodC()
        {
            this.Notify?.Invoke("[MethodC] Initiating top-level manager. Awaiting MethodB...");
            string jsonResult = await this.PerformMethodB();
            this.Notify?.Invoke("[MethodC] Analyzing payload. Parsing JSON structural elements...");

            using (JsonDocument document = JsonDocument.Parse(jsonResult))
            {
                int elementCount = 0;
                foreach (JsonProperty property in document.RootElement.EnumerateObject())
                {
                    elementCount++;
                }

                return elementCount;
            }
        }
    }
}
