using NorthwindTraders.MVC5.ViewModels;
using NorthwindTraders.MVC5.NorthwindServiceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NorthwindTraders.MVC5.Mappers;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NorthwindTraders.MVC5.Controllers
{
    public class DataController : ApiController
    {
        private readonly HttpClient employeeApiClient;

        public DataController()
        {
            // TODO: Load this address from settings (web.config/database/etc)
            employeeApiClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:54593/")
            };

            employeeApiClient.DefaultRequestHeaders.Accept.Clear();
            employeeApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [HttpGet, Route("Data/ReadAllCategories")]
        public List<Category_DTO> ReadAllCategories()
        {
            var categories = null as List<Category_DTO>;

            using (var proxy = new NorthwindContractClient())
                categories = proxy.ReadAllCategories();

            return categories;
        }

        [HttpGet, Route("Data/ReadProductsByCategory/{categoryID}")]
        public List<ProductViewModel> ReadProductsByCategory(int categoryID)
        {
            var products = null as List<Product_DTO>;

            using (var proxy = new NorthwindContractClient())
                products = proxy.ReadProductsByCategory(categoryID);

            return products.ConvertAll(ProductMapper.Map);
        }

        [HttpGet, Route("Data/ReadEmployeeCount")]
        public async Task<int> ReadEmployeeCount()
        {
            var employeeCount = JsonConvert.DeserializeObject<int>(
                await employeeApiClient.GetStringAsync("Employee/ReadEmployeeCount"));

            return employeeCount;
        }

        [HttpGet, Route("Data/ReadEmployeesByTitle/{title}")]
        public async Task<List<EmployeeViewModel>> ReadEmployeesByTitle(string title)
        {
            var employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(
                await employeeApiClient.GetStringAsync($"Employee/ReadEmployeesByTitle/{title}"));

            return employees;
        }

        [HttpGet, Route("Data/ReadDistinctTitles")]
        public async Task<List<string>> ReadDistinctTitles()
        {
            var titles = JsonConvert.DeserializeObject<List<string>>(
                await employeeApiClient.GetStringAsync("Employee/ReadDistinctTitles"));

            return titles;
        }

        [HttpPost, Route("Data/CreateEmployee")]
        public async Task<int> CreateEmployee(CreateEmployeeViewModel employee)
        {
            var response = await employeeApiClient.PostAsJsonAsync("Employee/CreateEmployee", employee);

            return JsonConvert.DeserializeObject<int>(await response.Content.ReadAsStringAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                employeeApiClient.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
