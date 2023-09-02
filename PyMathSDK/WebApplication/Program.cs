using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using WebApplication;

public class Program
{
    public static void Main(string[] args)
    {

        try
        {
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
        }
        finally
        {
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}