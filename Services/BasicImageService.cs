using AddressBook.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AddressBook.Services
{
    public class BasicImageService : IImageService
    {
        public string ConvertByteArrayToFile(byte[] filedata, string extenstion)
        {
            if (filedata is null) return string.Empty;

            string imageBase64Data = Convert.ToBase64String(filedata);
            return $"data:{extenstion};based64,{imageBase64Data}";
        }

        public async Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file)
        {
            using MemoryStream memoryStream = new();
            await file.CopyToAsync(memoryStream);
            byte[] byteFile = memoryStream.ToArray();

            return byteFile;

        }
    }
}
