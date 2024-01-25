using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementTest
{
    [TestFixture]
    internal class UserControllerTest 
    {
        private HttpClient _client;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // One-time setup code, e.g., initializing the HTTP client
            _client = new HttpClient();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // One-time teardown code, e.g., disposing of resources
            _client.Dispose();
        }
        [Test]
        public async Task GetStudents_ReturnsOkResult()
        {
            var response = await _client.GetAsync("https://api/Student/All");
            response.EnsureSuccessStatusCode();
        }

        }
    }
