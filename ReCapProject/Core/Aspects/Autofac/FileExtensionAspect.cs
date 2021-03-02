using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac
{
    public class FileExtensionAspect:MethodInterception
    {
        private string[] _allowedExtensions;
        public FileExtensionAspect(string[] extensions)
        {
            _allowedExtensions = extensions;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var formFile = (IFormFile)invocation.Arguments[0];
            var fileInfo = new FileInfo(formFile.FileName);
            if (!_allowedExtensions.Contains(fileInfo.Extension))
            {
                throw new Exception("Geçerli formatta resim yükleyin.");
            }
        }
    }
}
