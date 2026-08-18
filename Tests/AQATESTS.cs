using System.Net.Http.Json;
using System.Text.Json;
using System.Net;
using AutoTestsForApplications.DTO;

namespace AutoTestsForApplications.Tests
{
    public class Tests
    {
        private static HttpClient client;
        [OneTimeSetUp]
        public void Setup()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("https://reqres.in/api/")
            };
            client.DefaultRequestHeaders.Add("x-api-key", "free_user_3I0Gf8mCfHVlgZ0Eb2Itz1StKCf");

        }
        [Test]
        public async Task Test1()
        {
         using HttpResponseMessage response = await client.GetAsync("users/2");
        response.EnsureSuccessStatusCode();
        }

        [Test]
        public async Task Test2()
        {
            using HttpResponseMessage response = await client.GetAsync("users/2");
            string jsonGet = await response.Content.ReadAsStringAsync();
            UserResponseDTO userResponse = JsonSerializer.Deserialize<UserResponseDTO>(jsonGet);
            UserDataDTO user = userResponse.Data;
        }

        [Test]
        public async Task Test3()
        {
            var newUser = new CreateUserRequestDTO
            {
                Name = "ilya",
                Job = "Company1"
            };

            using HttpResponseMessage response = await client.PostAsJsonAsync("users", newUser);
            response.EnsureSuccessStatusCode();
            string jsonPost = await response.Content.ReadAsStringAsync();
            CreateUserResponseDTO created = JsonSerializer.Deserialize<CreateUserResponseDTO>(jsonPost);
        }

            [Test]

            public async Task Test4()
            {
                var newUser2 = new CreateUserRequestDTO
                {
                    Name = "ilya",
                    Job = "Company2"
                };
                using HttpResponseMessage response = await client.PutAsJsonAsync("users/2", newUser2);
                response.EnsureSuccessStatusCode();
            }

            [Test]

            public async Task Test5()
            {
                using HttpResponseMessage response = await client.DeleteAsync("users/2");
                response.EnsureSuccessStatusCode();
            }

            [OneTimeTearDown]
            public void TearDown()
            {
                client.Dispose();
            }
        }
    }
