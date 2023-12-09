using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityFramWorkWithoutMigrations
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });




            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddDbContext<AppDbContext>(
                options =>
            options.UseSqlite($"Filename=Maui.db3"));
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static string GetDatabasePath()
        {
            var databasePath = "";
            var databaseName = "Maui.db3";

            if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseName);
            }
            if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                SQLitePCL.Batteries_V2.Init();
                databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), databaseName); ;
            }

            return databasePath;

        }
    }


}


