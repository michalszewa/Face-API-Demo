# Face API Demo!

Hi! I've made this demo for my presentation about **Microsoft Azure services** and using **RESTful APIs** with it.

As a front layer here is a web site with dropzone where you can drop your image with faces to detect and analyze. I've also wanted to store uploaded images so I connected it with Azure's Blob Storage Service.
On succesfull uploading JavaScript functions are trigerred which handles jquerys AJAX calls to application backend endpoint where data are processed.
## Technologies
This web application contains two layers which was written in following technologies:
- **Frontend:** HTML, CSS (bootstrap framework), JavaScript (jquery AJAX for API calls to backend endpoints + JSON)
- **Backend:** C# ASP .NET Core 2 MVC + **Micorosft Azure Services:** Blob storage, Face Api Service

# Screens
- Main page view: 
![alt text](https://i.ibb.co/Mn0dzT6/zdj5.png)

- Test photo
![alt text](https://study.com/cimages/multimages/16/thumbs_up_students.jpeg)
- Result info about detected faces (blue color means male and red is for females)

![alt text](https://i.ibb.co/SsnFccn/zdj6.png)

# Setup
You have to add appsettings.json file that contains code as showed below and specify your credentials for Microsoft Azure's Storage Service and FaceApi Service.

    {
        "AzureStorageConfig": {
            "AccountName": "-",
            "AccountKey": "-",
            "ImageContainer": "-"
        },
        "AzureFaceApiConfig": {
            "SubscriptionKey": "-",
            "UriBase": "-"
        }
    } 


## Authors
- Michał Szewczak
