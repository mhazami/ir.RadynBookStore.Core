using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Environment = System.Environment;

namespace ir.RadynBookStore.Core.Utility
{
   public class ConnectionUtils
    {
        public static string DataBasePath()
        {
            string fileName = "RadynBookStore.db";
            var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(dbPath, fileName);
        }
    }
}