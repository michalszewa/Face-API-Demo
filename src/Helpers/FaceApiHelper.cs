﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DemoPrezentacja.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DemoPrezentacja.Helpers
{
    public class FaceApiHelper
    {
        public static string imageUrl = "";
        public static async Task<List<FaceApiResponse.FaceInfo>> MakeRequest(FaceApiConfig _faceApiConfig)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", $"{_faceApiConfig.SubscriptionKey}");

            // Request parameters
            queryString["returnFaceId"] = "true";
            queryString["returnFaceLandmarks"] = "false";
            queryString["returnFaceAttributes"] = "Age,gender,smile,glasses,facialHair,emotion";
            string uri = _faceApiConfig.UriBase + "?" + queryString;

            var data = new JObject
            {
                ["url"] =
                    $"{imageUrl}"
            };
            var json = JsonConvert.SerializeObject(data);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, stringContent);

            string content = response.Content.ReadAsStringAsync().Result;
            List<FaceApiResponse.FaceInfo> faces = JsonConvert.DeserializeObject<List<FaceApiResponse.FaceInfo>>(content);

            return faces;
        }
    }
}
