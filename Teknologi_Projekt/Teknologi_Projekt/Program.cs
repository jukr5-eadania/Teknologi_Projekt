using System.Threading;

const string uniqueMutexName = "com_mycompany_apps_appname";
using (Mutex mutex = new Mutex(true, uniqueMutexName, out bool createdNew))
{
    if (!createdNew)
    {
        // Another instance is already running; exit the application
        return;
    }

    // Start the game
    using (var game = new Teknologi_Projekt.GameWorld()) // Replace with your actual game class
    {
        game.Run();
    }
}
