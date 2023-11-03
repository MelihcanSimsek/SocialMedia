using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if(file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;
            var path = GuidHelper.Create() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            var result = NewPath(path);
            File.Move(sourcePath, result);
            return path;
           
        }

        public static void Delete(string path)
        {
            string filePath = NewPath(path);
            File.Delete(filePath);
        }

        public static string Update(string oldpath,IFormFile file)
        {
            Delete(oldpath);
            return Add(file);
        }

        private static string NewPath(string file)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\Uploads\images";
            string result = $@"{path}\{file}";
            return result;
        }
    }
}
