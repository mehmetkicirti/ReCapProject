using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers
{
    public static class FileHelper
    {
        [FileExtensionAspect(new string[] { ".png",".jpg"})]
        public static string AddImage(IFormFile file)
        {
            string sourceFileName = Path.GetTempFileName();
            using (FileStream fileStream = new FileStream(sourceFileName, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            var path = generatePath(file);
            File.Move(sourceFileName, path);
            return path;
        }
        public static IResult DeleteImage(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
            return new SuccessResult();
        }

        [FileExtensionAspect(new string[] { ".png",".jpg"})]
        public static string UpdateImage(string imagePath, IFormFile newImageFile)
        {
            var path = generatePath(newImageFile);
            if (imagePath.Length > 0)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    newImageFile.CopyTo(fileStream);
                }
            }
            File.Delete(imagePath);
            return path;
        }
        private static string generatePath(IFormFile file)
        {
            string extension = new FileInfo(file.FileName).Extension;
            string path = $@"{Environment.CurrentDirectory}\Images\Cars";
            CheckFolderExist(path);
            string filePath = $@"{Guid.NewGuid().ToString()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{extension}";
            return $@"{path}\{filePath}";
        } 
        private static void CheckFolderExist(string rootFolder)
        {
            if (!Directory.Exists(rootFolder))
            {
                Directory.CreateDirectory(rootFolder);
            }
        }
    }
}
