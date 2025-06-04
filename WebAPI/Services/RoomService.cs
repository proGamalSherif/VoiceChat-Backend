using AutoMapper;
using WebAPI.DTOs.Room;
using WebAPI.DTOs.UserConnection;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.Responses;

namespace WebAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IUserConnectionService userConnectionService;
        private readonly IMapper mapper;
        public RoomService(IRoomRepository _roomRepository,IMapper _mapper, IUserConnectionService _userConnectionService)
        {
            roomRepository = _roomRepository;
            mapper = _mapper;
            userConnectionService = _userConnectionService;
        }
        public async Task<APIResponse<string>> DeleteEntity(int id)
        {
            return await roomRepository.DeleteEntity(id);
        }
        public async Task<APIResponse<ICollection<ReadRoomDTO>>> GetAllAsync()
        {
            var result = await roomRepository.GetAllAsync();
            if (!result.IsSuccess)
                return APIResponse<ICollection<ReadRoomDTO>>.Failure(result.Message);
            var mappedResult = mapper.Map<ICollection<ReadRoomDTO>>(result.Data);
            return APIResponse<ICollection<ReadRoomDTO>>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadRoomDTO>> GetByIdAsync(int id)
        {
            var result = await roomRepository.GetByIdAsync(id);
            if (!result.IsSuccess)
                return APIResponse<ReadRoomDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadRoomDTO>(result.Data);
            return APIResponse<ReadRoomDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadRoomDTO>> InsertEntity(InsertRoomDTO entitiy)
        {
            var mappedInput = mapper.Map<Room>(entitiy);
            var result = await roomRepository.InsertEntity(mappedInput);
            if (!result.IsSuccess)
                return APIResponse<ReadRoomDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadRoomDTO>(result.Data);
            return APIResponse<ReadRoomDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadRoomDTO>> InsertEntityWithUser(Guid userId, InsertRoomDTO entity)
        {
            var result = await InsertEntity(entity);
            if(!result.IsSuccess || result.Data == null)
                return APIResponse<ReadRoomDTO>.Failure(result.Message);
            var userConnection = new InsertUserConnectionDTO
            {
                UserId = userId,
                RoomId = result.Data.RoomId,
            };
            var userResult = await userConnectionService.InsertEntity(userConnection);
            if (!userResult.IsSuccess || userResult.Data == null)
                return APIResponse<ReadRoomDTO>.Failure(userResult.Message);
            var mappedResult = mapper.Map<ReadRoomDTO>(result.Data);
            return APIResponse<ReadRoomDTO>.Success(result.Message, mappedResult);
        }
        public async Task<APIResponse<ReadRoomDTO>> UpdateEntity(UpdateRoomDTO entitiy)
        {
            var mappedInput = mapper.Map<Room>(entitiy);
            var result = await roomRepository.UpdateEntity(mappedInput);
            if (!result.IsSuccess)
                return APIResponse<ReadRoomDTO>.Failure(result.Message);
            var mappedResult = mapper.Map<ReadRoomDTO>(result.Data);
            return APIResponse<ReadRoomDTO>.Success(result.Message, mappedResult);
        }
    }
}
