using MyCarHistory.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCarHistory
{
    static class Program
    {
        public static string DB_ROOT_FOLDER =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyCarLog");
        public static string DB_PATH = Path.Combine(DB_ROOT_FOLDER, "data.db");


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            if (Directory.Exists(DB_ROOT_FOLDER) == false) {
                Directory.CreateDirectory(DB_ROOT_FOLDER);
            }

            using (CarDBContext db = new CarDBContext()) {
                db.Database.EnsureCreated();
                db.SaveChanges();
            }

            Application.Run(new Form1());
        }
    }
}
