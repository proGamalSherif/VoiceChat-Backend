using AutoMapper;
using WebAPI.DTOs.UserStatus;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.Responses;

namespace WebAPI.Services
{
    public class UserStatusService : IUserStatusService
    {
        private readonly IUserStatusRepository userStatusRepository;
        private readonly IMapper mapper;
        public UserStatusService(IUserStatusRepository _userStatusRepository,IMapper _mapper)
        {
            userStatusRepository = _userStatusRepository;   
            mapper = _mapper;
        }
        public async Task<APIResponse<ICollection<ReadUserStatusDTO>>> GetAllUsersOnlineInRoom(int roomId)
        {
            var responseResult = await userStatusRepository.GetAllUsersOnlineInRoom(roomId);
            if(!responseResult.IsSuccess)
                return APIResponse<ICollection<ReadUserStatusDTO>>.Failure(responseResult.Message);
            var mappedResult = mapper.Map<ICollection<ReadUserStatusDTO>>(responseResult.Data);
            return APIResponse<ICollection<ReadUserStatusDTO>>.Success(responseResult.Message,mappedResult);
        }
        public async Task<APIResponse<bool>> GetUserStatus(Guid userId, int roomId)
        {
            var responseResult = await userStatusRepository.GetUserStatus(userId, roomId);
            return responseResult;
        }

        public async Task LogoutUser(Guid userId)
        {
            await userStatusRepository.LogoutUser(userId);   
        }

        public async Task<APIResponse<ReadUserStatusDTO>> SetUserStatus(InsertUserStatusDTO userStatus)
        {
            var mappedInput = mapper.Map<UserStatus>(userStatus);
            if (mappedInput.IsLogged)
               await userStatusRepository.SetUserOffline(mappedInput.UserId, mappedInput.RoomId);
            var responseResult = await userStatusRepository.SetUserStatus(mappedInput);
            if (!responseResult.IsSuccess)
                return APIResponse<ReadUserStatusDTO>.Failure(responseResult.Message);
            var mappedResult = mapper.Map<ReadUserStatusDTO>(responseResult.Data);
            return APIResponse<ReadUserStatusDTO>.Success(responseResult.Message, mappedResult);
        }
    }
}
