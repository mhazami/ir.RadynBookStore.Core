using Android.Support.Annotation;
using System.ComponentModel.DataAnnotations;

namespace DataStructure
{
    public class File
    {
        [Keep]
        public int Id { get; set; }

        public string FileName { get; set; }

        public byte[] Content { get; set; }

        public string Extention { get; set; }
    }
}
