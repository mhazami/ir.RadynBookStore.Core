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
        public static readonly string DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "moneyback.db");

       
    }
}