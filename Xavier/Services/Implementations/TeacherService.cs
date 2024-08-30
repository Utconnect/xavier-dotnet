using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Utconnect.Common.Models;
using Utconnect.Common.Models.Errors;
using Utconnect.Teacher.Models;
using Utconnect.Teacher.Services.Abstract;

namespace Utconnect.Teacher.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<TeacherConfig> _config;

        public TeacherService(IHttpClientFactory clientFactory, IOptions<TeacherConfig> config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public async Task<Result<TeacherResponse>> GetById(Guid userId)
        {
            string teacherUrl = _config.Value.Url;

            if (string.IsNullOrEmpty(teacherUrl))
            {
                return Result<TeacherResponse>.Failure(new InternalServerError("Teacher URL is empty"));
            }

            var requestUrl = $"{teacherUrl}/teacher/{userId}";
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            try
            {
                string content = await response.Content.ReadAsStringAsync();
                Result<TeacherResponse>? data = JsonConvert.DeserializeObject<Result<TeacherResponse>>(content);
                return data ?? Result<TeacherResponse>.Failure(new InternalServerError("Retrieved data is null"));
            }
            catch (Exception)
            {
                return Result<TeacherResponse>.Failure(new InternalServerError("Cannot decode response"));
            }
        }

        public async Task<Result<TeacherResponse>> GetByUserId(Guid userId)
        {
            string teacherUrl = _config.Value.Url;

            if (string.IsNullOrEmpty(teacherUrl))
            {
                return Result<TeacherResponse>.Failure(new InternalServerError("Teacher URL is empty"));
            }

            var requestUrl = $"{teacherUrl}/teacher/user/{userId}";
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            try
            {
                string content = await response.Content.ReadAsStringAsync();
                Result<TeacherResponse>? data = JsonConvert.DeserializeObject<Result<TeacherResponse>>(content);
                return data ?? Result<TeacherResponse>.Failure(new InternalServerError("Retrieved data is null"));
            }
            catch (Exception)
            {
                return Result<TeacherResponse>.Failure(new InternalServerError("Cannot decode response"));
            }
        }
    }
}