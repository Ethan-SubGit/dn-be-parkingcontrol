using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Parkgin.Server.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Parkgin.Server.Api.Service
{
    public class FileService : IFileService
    {
        private readonly AppSettings _appSettings;

        public FileService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="files"></param>
        /// <param name="subDirectory"></param>
        public void SaveFile(List<IFormFile> files, string subDirectory)
        {
            subDirectory = subDirectory ?? string.Empty;
            //var target = Path.Combine("D:\\work\\instarcokr\\source\\project\\parkingControl\\parkingControl\\parkingBackendTemplate\\Parkgin.Server.Api\\UploadedFiles\\", subDirectory);
            var folderName = Path.Combine("UploadedFiles", "Images");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            Directory.CreateDirectory(pathToSave);
            files.ForEach(async file =>
            {
                if (file.Length <= 0) return;
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);


                //var filePath = Path.Combine(target, file.FileName);
                //using (var stream = new FileStream(filePath, FileMode.Create))
                //{
                //    await file.CopyToAsync(stream);
                //}
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            });
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subDirectory"></param>
        /// <returns></returns>
        public (string fileType, byte[] archiveData, string archiveName) FetechFiles(string subDirectory)
        {
            var zipName = $"archive-{DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine("D:\\work\\instarcokr\\source\\project\\parkingControl\\parkingControl\\parkingBackendTemplate\\Parkgin.Server.Api\\UploadedFiles\\", subDirectory)).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        var theFile = archive.CreateEntry(file);
                        using (var streamWriter = new StreamWriter(theFile.Open()))
                        {
                            streamWriter.Write(File.ReadAllText(file));
                        }

                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string SizeConverter(long bytes)
        {
            var fileSize = new decimal(bytes);
            var kilobyte = new decimal(1024);
            var megabyte = new decimal(1024 * 1024);
            var gigabyte = new decimal(1024 * 1024 * 1024);

            switch (fileSize)
            {
                case var _ when fileSize < kilobyte:
                    return $"Less then 1KB";
                case var _ when fileSize < megabyte:
                    return $"{Math.Round(fileSize / kilobyte, 0, MidpointRounding.AwayFromZero):##,###.##}KB";
                case var _ when fileSize < gigabyte:
                    return $"{Math.Round(fileSize / megabyte, 2, MidpointRounding.AwayFromZero):##,###.##}MB";
                case var _ when fileSize >= gigabyte:
                    return $"{Math.Round(fileSize / gigabyte, 2, MidpointRounding.AwayFromZero):##,###.##}GB";
                default:
                    return "n/a";
            }
        }
    }
}
