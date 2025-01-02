using Microsoft.AspNetCore.SignalR;

namespace SignalRChatServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR();
            builder.Services.AddCors();

            var app = builder.Build();            

            app.UseRouting();

            app.UseCors(x =>
            {
                x.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapHub<Chat>("/chat");
            });

            app.Run();
        }
    }
}
