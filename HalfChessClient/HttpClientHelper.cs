using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HalfChessClient
{
    public class LoginData
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

    }
    public class StartData
    {
        public int PlayerId { get; set; }
        public object player { get; set; }
    }

    public class EndData
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public object player { get; set; }
    }

    public class HttpClientHelper
    {
        //singletone;
        private static HttpClientHelper _instance;
        private static readonly object _lock = new object();
        private HttpClient client;
        private HttpClientHelper()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5284/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClientHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new HttpClientHelper();
                        }
                    }
                }
                return _instance;
            }
        }

        public async Task<string> LoginAsync(string playerName, int playerID)
        {
            LoginData requestData = new LoginData
            {
                PlayerId = playerID,
                PlayerName = playerName
            };

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/games/login", requestData).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<String>();
                }
                else
                {
                    return ("Fail");
                }
            }
            catch (Exception e)
            {
                return (e.Message);
            }
        }

        public async Task<int> StartAsync(int playerId)
        {
            StartData requestData = new StartData
            {
                PlayerId = playerId,
                player = null
            };

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/games/start", requestData).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<int>();
                }
                else
                {
                    return 0; // Indicating failure with a non-success status code
                }
            }
            catch
            {
                return -1; // Indicating an error occurred
            }
        }


        public async Task<string> EndAsync(int id, string result)
        {
            EndData requestData = new EndData
            {
                Id = id,
                Result = result  // Accepts "Win", "Lose", or "Draw"
            };
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/games/end", requestData).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<string>();
                }
                else
                {
                    return "Fail";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<int> PromotePawnAsync()
        {
            try
            {
                
                var promotionRequest = new { LastMove = new { } };

                // Send the request to the server with the promotionRequest as the body
                HttpResponseMessage response = await client.PostAsJsonAsync("api/games/promote", promotionRequest).ConfigureAwait(false);

                // Check if the response was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the integer response (1, 2, or 3)
                    return await response.Content.ReadAsAsync<int>();
                }
                else
                {
                    // Handle failure response
                    return -1; // Indicate failure
                }
            }
            catch (Exception e)
            {
                // Handle any exceptions that occur during the request
                Console.WriteLine($"Exception occurred: {e.Message}");
                return -1; // Indicate failure
            }
        }
        public async Task<List<int>> GetGameIdsAsync()
        {
            try
            {
                // Make an HTTP GET request to fetch game IDs
                HttpResponseMessage response = await client.GetAsync("api/games/game-ids").ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response into a list of integers
                    List<int> gameIds = await response.Content.ReadAsAsync<List<int>>();
                    return gameIds;
                }
                else
                {
                    // Handle non-success status codes
                    Console.WriteLine($"Failed to retrieve game IDs. Status Code: {response.StatusCode}");
                    return new List<int>(); // Return an empty list on failure
                }
            }
            catch (Exception e)
            {
                // Handle exceptions that occur during the request
                Console.WriteLine($"Exception occurred while retrieving game IDs: {e.Message}");
                return new List<int>(); // Return an empty list on exception
            }
        }



        public async Task<Move> MoveAsync(string boardJson)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("api/games/move", boardJson).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Move move = Move.JsonDeserialize(result);

                    return move;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null; // No variable used here, suppressing the warning
            }


        }
    }
}
