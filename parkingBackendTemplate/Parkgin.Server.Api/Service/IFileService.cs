using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Parkgin.Server.Api.Service
{
    public interface IFileService
    {
        void SaveFile(List<IFormFile> files, string subDirectory);
    }
}