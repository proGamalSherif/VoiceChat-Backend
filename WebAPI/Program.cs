
using Microsoft.EntityFrameworkCore;
using WebAPI.DBContext;
using WebAPI.Interfaces.Repositories;
using WebAPI.Interfaces.Services;
using WebAPI.MappingProfiles;
using WebAPI.RealtimeSignalR;
using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Add Db Context
            builder.Services.AddDbContext<VoiceDBContext>(option=>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Add Automapper
            builder.Services.AddAutoMapper(typeof(ApplicationUserProfile));

            //Add Repositories
            builder.Services.AddScoped<IApplicationUserRepository, ApplicationUserRepository>();
            builder.Services.AddScoped<IRoomChatRepository, RoomChatRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();
            builder.Services.AddScoped<IVoiceCallingRepository, VoiceCallingRepository>();
            builder.Services.AddScoped<IUserStatusRepository, UserStatusRepository>();

            //Add Services
            builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
            builder.Services.AddScoped<IRoomChatService, RoomChatService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IUserConnectionService, UserConnectionService>();
            builder.Services.AddScoped<IVoiceCallingService, VoiceCallingService>();
            builder.Services.AddScoped<IUserStatusService, UserStatusService>();

            //Add Swagger
            builder.Services.AddSwaggerGen();

            //Add SignalR
            builder.Services.AddSignalR();

            //Allow Any Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                        policy.WithOrigins("https://voice-chat-ui.vercel.app")
                        .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    });
            });

            builder.Services.AddControllers();
            var app = builder.Build();
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors("AllowAll");
            app.MapControllers();
            app.MapHub<ChatHub>("/chathub");
            app.MapHub<CallHub>("/callhub");
            app.Run();
        }
    }
}
