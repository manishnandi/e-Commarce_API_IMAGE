using AutoMapper;
using e_Commarce_API.Data;
using e_Commarce_API.Models;
using e_Commarce_API.Models.Dto;
using e_Commarce_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace e_Commarce_API.Controllers
{
    [Route("api/Brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public BrandController(ApplicationDbContext context, IMapper mapper, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _response = new();
            _fileService = fileService;
        }

        [HttpGet("id", Name = "GetBrand")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetBrand(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var brand = await _context.Brand.FirstOrDefaultAsync(b => b.Id == id);

                if (brand == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                _response.Result = _mapper.Map<BrandDTO>(brand);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut("id", Name ="UpdateBrand")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateBrand([FromForm]BrandDTO model)
        {
            try
            {
                if (model == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                if (model.FileNavLogo != null)
                {
                    //UPLOAD NAV LOGO
                    var fileResult = _fileService.SaveImage(model.FileNavLogo);
                    if(fileResult.Item1 == 1)
                    {
                        model.NavLogo = fileResult.Item2;
                    }
                }

                if (model.FileLogo != null)
                {
                    //UPLOAD LOGO
                    var fileResult = _fileService.SaveImage(model.FileLogo);
                    if (fileResult.Item1 == 1)
                    {
                        model.Logo = fileResult.Item2;
                    }
                }

                var brand = _mapper.Map<Brand>(model);
                _context.Brand.Update(brand);
                await _context.SaveChangesAsync();
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
    }
}
