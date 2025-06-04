using AutoMapper;
using WebAPI.DTOs.UserConnection;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.Responses;
namespace WebAPI.Services
{
    public class UserConnectionService : IUserConnectionService
    {
        private readonly IUserConnectionRepository userConnectionRepository;
        private readonly IMapper mapper;
        public UserConnectionService(IUserConnectionRepository _userConnectRepository,IMapper _mapper)
        {
            userConnectionRepository = _userConnectRepository;
            mapper = _mapper;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            return await userConnectionRepository.DeleteEntity(id);
        }
        public async Task<APIResponse<ICollection<ReadUserConnectionDTO>>> GetAllAsync()
        {
            var result = await userConnectionRepository.GetAllAsync();
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ICollection<ReadUserConnectionDTO>>.Failure(result.Message);
            var mappedResult = mapper.Map<ICollection<ReadUserConnectionDTO>>(result.Data);
            return APIResponse<ICollection<ReadUserConnectionDTO>>.Success(result.Message,mappedResult);
        }
        public async Task<APIResponse<ICollection<ReadUserConnectionDTO>>> GetAllByUserId(Guid userId)
        {
            var result = await userConnectionRepository.GetAllByUserId(userId);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ICollection<ReadUserConnectionDTO>>.Failure(result.Message);
            var mappedResult = mapper.Map<ICollection<ReadUserConnectionDTO>>(result.Data);
            return APIResponse<ICollection<ReadUserConnectionDTO>>.Success(result.Message,mappedResult);
        }
        public async Task<APIResponse<ReadUserConnectionDTO>> GetByIdAsync(int id)
        {
            var result = await userConnectionRepository.GetByIdAsync(id);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ReadUserConnectionDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadUserConnectionDTO>(result.Data);
            return APIResponse<ReadUserConnectionDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadUserConnectionDTO>> InsertEntity(InsertUserConnectionDTO entitiy)
        {
            var mappedInput = mapper.Map<UserConnection>(entitiy);
            var result = await userConnectionRepository.InsertEntity(mappedInput);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ReadUserConnectionDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadUserConnectionDTO>(result.Data);
            return APIResponse<ReadUserConnectionDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadUserConnectionDTO>> UpdateEntity(UpdateUserConnectionDTO entitiy)
        {
            var mappedInput = mapper.Map<UserConnection>(entitiy);
            var result = await userConnectionRepository.UpdateEntity(mappedInput);
            if (!result.IsSuccess || result.Data == null)
                return APIResponse<ReadUserConnectionDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadUserConnectionDTO>(result.Data);
            return APIResponse<ReadUserConnectionDTO>.Success(result.Message, mappedResult);
        }
    }
}
