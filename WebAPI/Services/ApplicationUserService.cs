using AutoMapper;
using WebAPI.DTOs.ApplicationUser;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.Responses;

namespace WebAPI.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly IMapper mapper;
        public ApplicationUserService(IApplicationUserRepository _applicationUserRepository,IMapper _mapper)
        {
            applicationUserRepository = _applicationUserRepository;
            mapper = _mapper;
        }
        public async Task<APIResponse<string>> DeleteEntity(Guid id)
        {
            return await applicationUserRepository.DeleteEntity(id);
        }
        public async Task<APIResponse<ICollection<ReadApplicationUserDTO>>> GetAllAsync()
        {
            var result = await applicationUserRepository.GetAllAsync();
            var resultMapped = mapper.Map<ICollection<ReadApplicationUserDTO>>(result.Data);
            return APIResponse<ICollection<ReadApplicationUserDTO>>.Success(result.Message, resultMapped);
        }
        public async Task<APIResponse<ReadApplicationUserDTO>> GetByIdAsync(Guid id)
        {
            var result = await applicationUserRepository.GetByIdAsync(id);
            var resultMapped = mapper.Map<ReadApplicationUserDTO>(result.Data);
            if(!result.IsSuccess)
                return APIResponse<ReadApplicationUserDTO>.Failure(result.Message);
            return APIResponse<ReadApplicationUserDTO>.Success(result.Message, resultMapped);
        }
        public async Task<APIResponse<ReadApplicationUserDTO>> InsertEntity(InsertApplicationUserDTO entitiy)
        {
            var mappedInput = mapper.Map<ApplicationUser>(entitiy);
            var result = await applicationUserRepository.InsertEntity(mappedInput);
            if (!result.IsSuccess)
                return APIResponse<ReadApplicationUserDTO>.Failure(result.Message);
            var resultMapped = mapper.Map<ReadApplicationUserDTO>(result.Data);
            return APIResponse<ReadApplicationUserDTO>.Success(result.Message, resultMapped);
        }
        public async Task<APIResponse<ReadApplicationUserDTO>> UpdateEntity(UpdateApplicationUserDTO entitiy)
        {
            var mappedInput = mapper.Map<ApplicationUser>(entitiy);
            var result = await applicationUserRepository.UpdateEntity(mappedInput);
            if (!result.IsSuccess)
                return APIResponse<ReadApplicationUserDTO>.Failure(result.Message);
            var resultMapped = mapper.Map<ReadApplicationUserDTO>(result.Data);
            return APIResponse<ReadApplicationUserDTO>.Success(result.Message, resultMapped);
        }
    }
}
