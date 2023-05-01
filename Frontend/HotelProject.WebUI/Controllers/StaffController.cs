using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir tane istemci oluşturuyoruz
            var responseMessage = await client.GetAsync("http://localhost:1426/api/Staff"); //Get ile url den istekte bulunuyoruz
            if (responseMessage.IsSuccessStatusCode)//200-299 arasında herhangi bir kod
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//response mesajın içeriğini oku
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);//Gelen veriyi json a deserilize et ve Uı katmanındaki models içerisinde oluşturduğumuz StaffViewModele aktar
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffVM model)
        {
           
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);//Gelen Datayı seralize edip json a çeviriyoruz
            StringContent stringContent=new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:1426/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:1426/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            model.Cdate = System.DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:1426/api/Staff/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:1426/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
