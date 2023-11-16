using Avalonia;
using Avalonia.Logging;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;
using System.Threading;

namespace AvaloniaTestApp;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    
    //public static void Main(string[] args) => BuildAvaloniaApp()
        //.StartWithClassicDesktopLifetime(args);
    [STAThread]
    public static void Main(string[] args)
    {
        InitLogging();
        try
        {
            var app = BuildAvaloniaApp();
            app.StartWithClassicDesktopLifetime(args);
        }
        catch (System.Exception ex)
        {
            Log.Error(ex, "Failed in {0}", ex.Message);
        }
        
    }

    private static void InitLogging()
    {
        Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Debug()
                            .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                            //.WriteTo.Async(wt => wt.Console())  // erfordert Serilogs.Sinks.Async
                            .WriteTo.File("log.log", 
                                            rollingInterval: RollingInterval.Day, 
                                            rollOnFileSizeLimit: true)
                            .CreateLogger();

        
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace(LogEventLevel.Debug, 
                        LogArea.Layout, LogArea.Binding, LogArea.Control, LogArea.Platform, 
                        LogArea.LinuxFramebufferPlatform, LogArea.macOSPlatform
                        );
}
