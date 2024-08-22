﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using TaskManager.Web.Models.Dto;
using TaskManager.Web.Models;

namespace TaskManager.Web.Controllers
{
    public class TaskManagerController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public TaskManagerController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<TaskManagerDto> response = new List<TaskManagerDto>();
            try
            {
                //Get All Tasks from Web API :

                var client = httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7036/api/TaskManager");

                httpResponseMessage.EnsureSuccessStatusCode();

                var taskManagerDto = await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<TaskManagerDto>>();

                if (taskManagerDto == null)
                {
                    throw new ArgumentNullException(nameof(httpResponseMessage));
                }


                response.AddRange(taskManagerDto);
            }
            catch (Exception ex)
            {
                //Log the Exception
                throw ex;
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTaskModel model)
        {
            var client = httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7036/api/TaskManager"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")     //Convert to JSON Content
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<TaskManagerDto>();

            if (response != null)
            {
                return RedirectToAction("Index", "TaskManager");
            }

            return View();
        }
    }
}
