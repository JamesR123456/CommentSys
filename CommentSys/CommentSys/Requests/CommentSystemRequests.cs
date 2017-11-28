using RestSharp;
using Newtonsoft.Json;
using Models;

namespace CommentSys.Requests
{
    //TODO: Create generic request builder to always add bearer token and x org-id to request headers.
    //TODO: 
    public class CommentSystemRequests
    {
        /*token appears to not be working correctly. Made an attempt with swagger also
        and it was rejected with 401. Taking a look via jwt.io shows it as not expired but did have a signature error.  
        */
        public static string bearerToken = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjA4NEYyMTRGQkIzODJGNDRCQjkzOTkwMEFENEM5OTI0NkIzNkM4RjEiLCJ0eXAiOiJKV1QiLCJ4NXQiOiJDRThoVDdzNEwwUzdrNWtBclV5WkpHczJ5UEUifQ.eyJlbWFpbCI6ImNvZGUudGVzdEB0ZXN0LnRlc3QiLCJnaXZlbl9uYW1lIjoiY29kZSIsImZhbWlseV9uYW1lIjoidGVzdCIsInVzZXIiOiJ7XCJpZFwiOlwiODZiNTc5NmQtMzc2Mi00ODdhLTlhNDAtMDE1ODA0NjZjN2RlXCIsXCJvcmdhbml6YXRpb25zXCI6W3tcIm9yZ2FuaXphdGlvblwiOntcImlkXCI6XCI5MzU4MDQ2NS00ZDE0LTQ5ODQtOGRjZC0wNjMyNjU5NmRjZWZcIixcIm5hbWVcIjpcIlRlc3QgT3JnYW5pemF0aW9uXCJ9LFwicm9sZXNcIjpbXX0se1wib3JnYW5pemF0aW9uXCI6e1wiaWRcIjpcIjc1YjJmZTliLTMwOGEtNDU2MS1hNTk4LTcxYTAwMzNjNTc1ZFwiLFwibmFtZVwiOlwiVG91cmlzbSBIb2xkaW5ncyBMaW1pdGVkXCJ9LFwicm9sZXNcIjpbXX1dfSIsInN1YiI6IjkzMWVjMjFmLTViODktNDNlMS1hMzc2LTI5YTJlYWRkZmU0MCIsImp0aSI6ImZkY2M4ODMzLWFmNGUtNDM1OC1iNTliLTgyOGE4ZmJmZWI4ZCIsInVzYWdlIjoiaWRfdG9rZW4iLCJhdWQiOiJjb3Ntb3MiLCJub25jZSI6ImQ0NDNiYzhkNTgyODQxN2ZiY2EwOGNiOWNmZWVlNGI4IiwiYXpwIjoiY29zbW9zIiwibmJmIjoxNTEwNjg4MjQ1LCJleHAiOjE1MTE5NjA2NDUsImlhdCI6MTUxMDY4ODI0NSwiaXNzIjoiaHR0cHM6Ly90ZXN0YWNjb3VudHMudGhsb25saW5lLmNvbS8ifQ.tpOb8p7CjojErbqVYrg4Aki2WBSlDms257h1cJGeAFwQ7J440Lj9n2kCsk_4Ax43alS0ngEZdGvDc1C_AtJGpgEoqWYpGHsCLgpqfho68mSySdl4VMbu_ymoPNV4OR1dc3yI3CnXhqP8ElxMuEUz6wmCCEyJ3JNTQrJQXVmG3QXrroo0yMwaC_aZJdT4Uaarij6YJWZ7cOW1h0eikAQPUGAFcVowsaRpLR_6Jk6d6jjwDZdQKctRzvvVopRGoZUuWtm4VN9pXaTGa4Z35ypKW1p637rUXQf6ZTgBeMLXg5yZbb7pTv3pADzdR_0zWlHfPloyR86_P29VmmaF3UYZ4oOykHezF1nt6EZPocafzplHElSRsj6oXZ_fNxFc5PdVHvgUuzhnRncIB5ApL1DRJfwXXh1lfddSdZqo43PKnrZU7P4dFVYYg1EIHqD4waB6LnWdoWbErz6iO_LbAzgsO1LEpTKKOLQSBk9nBf_YO0LY93uPcE-HD5neGFeMqyDaZjahAZcIxrkyjgIA9OdbGwGJYEJsJtBQAE0ZTeqS2yAyfnT94VUBCbR3y9PgxGs09sDzpKkUQtlcyhSEY_1G64d77efYqi_b2d9JgnwkWIks3W3lXOgIvINZHIy8HiawC_wT-GuxKBI0VO36pBMcZYk8mD3BHZdJ-WsFsDD79q82";
        private const string xOrgid = "93580465-4d14-4984-8dcd-06326596dcef";
        
        private RestClient client;

        //TODO: Abstract out url to central config to define server ones to make env change easier.
        public CommentSystemRequests()
        {
            client = new RestClient("https://apigateway-test.aws.thlonline.com");
        }


        /// <summary>
        /// Gets all comments or a comment of a specific ID.
        /// </summary>
        /// <returns></returns>
        public IRestResponse<CommentResponse> GetComment(string commentId = null)
        {
            var  request = string.IsNullOrEmpty(commentId) ? new RestRequest($"/v1/comments/", Method.GET) 
                : new RestRequest($"/v1/comments/{commentId}", Method.GET);
       
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            request.AddHeader("X-OrganizationId", xOrgid);

            return client.Execute<CommentResponse>(request);            
        }



        /// <summary>
        /// Posts a comment to the system.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public IRestResponse<CommentResponse> PostComment(string thecomment)
        {
            var request = new RestRequest($"/v1/comments/", Method.POST);
            request.AddHeader("Authorization", $"Bearer {bearerToken}");
            request.AddHeader("X-OrganizationId", xOrgid);

            var body = new Comment { comment = thecomment };

            var serialised = JsonConvert.SerializeObject(body);
            request.AddBody(serialised);
            var result = client.Execute<CommentResponse>(request);
            return result;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class Comment
    {
        public string comment { get; set; }
    }
}
