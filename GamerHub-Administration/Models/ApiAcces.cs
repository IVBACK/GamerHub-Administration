using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GamerHub_Administration.Models
{
    public static class ApiAcces
    {
        public static Uri uri;

        public static async Task<Admin> AdminLogin(Admin adminLoginRequest)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(adminLoginRequest);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PostAsync(uri + "Api/Admin/Login", stringContent);

            if (response.IsSuccessStatusCode)
            {
                Admin adminResponse = response.Content.ReadAsAsync<Admin>().Result;
                return adminResponse;
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Post>> GetPostsAsync(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var resp = await client.GetAsync(uri + "Api/Post");

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(jsonString);
                return postList;
            }
            else
            {
                return null;
            }
        }
        public static async Task<HttpResponseMessage> AddPostAsync(Post post, string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(post);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PostAsync(uri + "Api/Post/CreatePost", stringContent);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Succesfull");
                return null;
            }
            else
            {
                MessageBox.Show("Something Went Wrong");
                return null;
            }
        }
        public static async Task<HttpResponseMessage> PostUpdateAsync(Post post, string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(post);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PutAsync(uri + "Api/Post/UpdatePost", stringContent);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Succesfull");
                return null;
            }
            else
            {
                MessageBox.Show("Something Went Wrong");
                return null;
            }
        }
        public static async Task<HttpResponseMessage> DeletePostAsync(int? id, string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(id);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PostAsync(uri + "Api/Post/DeletePost", stringContent);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Succesfull");
                return null;
            }
            else
            {
                MessageBox.Show("Something Went Wrong");
                return null;
            }
        }

        ///

        public static async Task<List<User>> GetUsersAsync(string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var resp = await client.GetAsync(uri + "Api/Users");

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                List<User> userList = JsonConvert.DeserializeObject<List<User>>(jsonString);
                return userList;
            }
            else
            {
                return null;
            }
        }

        public static async Task<HttpResponseMessage> DeleteUserAsync(int? id, string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(id);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PostAsync(uri + "Api/Users/DeleteUser", stringContent);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Succesfull");
                return null;
            }
            else
            {
                MessageBox.Show("Something Went Wrong");
                return null;
            }
        }

        public static async Task<List<User>> GetFriendsAsync(string token, int? id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var json = JsonConvert.SerializeObject(id);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var resp = await client.PostAsync(uri + "Api/Friendship/GetFriends", stringContent);

            if (resp.IsSuccessStatusCode)
            {
                var jsonString = await resp.Content.ReadAsStringAsync();
                List<User> userList = JsonConvert.DeserializeObject<List<User>>(jsonString);
                return userList;
            }
            else
            {
                return null;
            }
        }
    }
}
