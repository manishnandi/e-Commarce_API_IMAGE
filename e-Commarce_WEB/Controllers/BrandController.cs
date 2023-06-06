using e_Commarce_WEB.Models;
using e_Commarce_WEB.Models.Dto;
using e_Commarce_WEB.Services.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace e_Commarce_WEB.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BrandController(IBrandService brandService, IWebHostEnvironment webHostEnvironment)
        {
            _brandService = brandService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> IndexBrand()
        {
            BrandDTO brand = new BrandDTO();
            var response = await _brandService.GetAsync<APIResponse>(id: 1);
            if(response != null && response.IsSuccess)
            {
                brand = JsonConvert.DeserializeObject<BrandDTO>(Convert.ToString(response.Result));
            }
            return View(brand);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBrand(BrandDTO dto)
        {
            
            if (ModelState.IsValid)
            {
                var response = await _brandService.UpdateAsync<APIResponse>(dto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Villa updated successfully";
                    return RedirectToAction(nameof(IndexBrand));
                }
            }

            TempData["error"] = "Error encourted.";
            return View("IndexBrand", dto);
        }
    }
}
