using NettLL.Design.DatabaseOperations.DataAccess.DataManager;
using NettLL.Design.DatabaseOperations.Entities;
using NettLL.Design.DatabaseOperations.SeedDatabase;

namespace NettLL.Design
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
           // Options.pathForScenes = null;
            //Options.pathVideos = null;
            //Options.pathSounds = null;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());
        }
    }
}