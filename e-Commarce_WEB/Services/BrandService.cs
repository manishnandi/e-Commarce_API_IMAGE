using e_Commarce_UTILITY;
using e_Commarce_WEB.Models;
using e_Commarce_WEB.Models.Dto;
using e_Commarce_WEB.Services.IServices;

namespace e_Commarce_WEB.Services
{
    public class BrandService : BaseService, IBrandService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string ecommarceUrl;

        public BrandService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            ecommarceUrl = configuration.GetValue<string>("ServiceUrls:EcommarceAPI");

        }


        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.GET,
                Url = ecommarceUrl + "/api/Brand/id?id=" + id
            });
        }


        public Task<T> UpdateAsync<T>(BrandDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = ecommarceUrl + "/api/Brand"
            });
        }
    }
}
