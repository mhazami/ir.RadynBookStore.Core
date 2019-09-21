using Android.Database;
using Android.Graphics;
using DataStructure.Repository;


namespace ir.RadynBookStore.Core.Utility
{
    public class FileHandler
    {
        public static Bitmap ConverteToBitmap(int fileId)
        {
            Bitmap image = null;
            var file = new DbManager(ConnectionUtils.DataBasePath).GetFile(fileId);
            image = BitmapFactory.DecodeByteArray(file.Content, 0, file.Content.Length);
            return image;

        }
    }
}