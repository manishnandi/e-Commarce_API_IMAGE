using e_Commarce_WEB.Models.Dto;

namespace e_Commarce_WEB.Services.IServices
{
    public interface IBrandService
    {
        //Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        //Task<T> CreateAsync<T>(BrandDTO dto);
        Task<T> UpdateAsync<T>(BrandDTO dto);
        //Task<T> DeleteAsync<T>(int id);
    }
}
