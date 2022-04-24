using System;
using System.Windows.Forms;

namespace Capstone_Project
{
    static class Program//accesss to database needed:All art
    {                                              //one photo per art 
        public static bool nightMode = false;      //maybe single art
        public static int fontSize = 1;            //simple exhibitionx
        public static bool fromCollection;         //all exhibitionx
        public static int rowID;                   //maybe single exhibition
        /// <summary>                              //all art done in last 12 months
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginScreen());
        }
    }
}
