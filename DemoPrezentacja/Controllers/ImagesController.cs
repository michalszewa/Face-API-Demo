using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoPrezentacja.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Auth;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using DemoPrezentacja.Helpers;

namespace DemoPrezentacja.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        // make sure that appsettings.json is filled with the necessary details of the azure storage
        private readonly AzureStorageConfig storageConfig = null;
        private readonly FaceApiConfig faceApiConfig = null;


        public ImagesController(IOptions<AzureStorageConfig> config, IOptions<FaceApiConfig> faceConfig)
        {
            storageConfig = config.Value;
            faceApiConfig = faceConfig.Value;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {

            try
            {

                if (files.Count == 0)

                    return BadRequest("No files received from the upload");

                if (storageConfig.AccountKey == string.Empty || storageConfig.AccountName == string.Empty)

                    return BadRequest("sorry, can't retrieve your azure storage details from appsettings.js, make sure that you add azure storage details there");

                if (storageConfig.ImageContainer == string.Empty)

                    return BadRequest("Please provide a name for your image container in the azure blob storage");

                foreach (var formFile in files)
                {
                    if (StorageHelper.IsImage(formFile))
                    {
                        if (formFile.Length > 0)
                        {
                            using (Stream stream = formFile.OpenReadStream())
                            {
                                FaceApiHelper.imageUrl = await StorageHelper.UploadFileToStorage(stream, formFile.FileName, storageConfig);
                            }
                        }
                        else
                        {
                            return new UnsupportedMediaTypeResult();
                        }
                    }
                }
                if (FaceApiHelper.imageUrl != "")
                {
                    return new AcceptedAtActionResult("GetThumbNails", "Images", null, null);
                }
                else
                    return BadRequest("Look like the image couldnt upload to the storage");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("thumbnails")]
        public async Task<IActionResult> GetThumbNails()
        {

            try
            {
                if (FaceApiHelper.imageUrl != "")
                {
                    FaceApiResponse.FaceInfo face = await FaceApiHelper.MakeRequest(faceApiConfig);
                    return new ObjectResult(face);
                }
                else
                    return BadRequest("No image url");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
