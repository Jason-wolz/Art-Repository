using System;
using System.Drawing;
using System.Windows.Forms;

namespace Capstone_Project
{
    static class Program//for-Future:: add field "currentLocation" to artwork table
    {                                           
        public static bool nightMode = false;
        public static int fontSize = 0;         
        public static bool fromCollection;        
        public static int rowId;               
        public static readonly string photos = "Photos";
        public static readonly string allExhib = "Full Exhibition";
        public static readonly string allArt = "All Artwork";
        public static readonly string simpleExhib = "Simple Exhibition";
        public static readonly string simpleArt = "Simple Artwork";
        public static readonly string inter = "Interface";
        public static readonly string name = "Name";
        public static readonly string medium = "Medium";
        public static readonly Color nightColor = Color.FromArgb(16, 39, 58);
        public static readonly Color dayColor = Color.FromArgb(222, 225, 234);
        /// <summary>                              
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DataSetClass.CreateDatabase();
            Application.Run(new MainScreen());
        }
    }
}
