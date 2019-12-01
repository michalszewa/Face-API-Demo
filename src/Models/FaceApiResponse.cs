using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPrezentacja.Models
{
    public class FaceApiResponse
    {
        public class FaceRectangle
        {
            public int top { get; set; }
            public int left { get; set; }
            public int width { get; set; }
            public int height { get; set; }
        }

        public class FacialHair
        {
            public double moustache { get; set; }
            public double beard { get; set; }
            public double sideburns { get; set; }
        }

        public class Emotion
        {
            public double anger { get; set; }
            public double contempt { get; set; }
            public double disgust { get; set; }
            public double fear { get; set; }
            public double happiness { get; set; }
            public double neutral { get; set; }
            public double sadness { get; set; }
            public double surprise { get; set; }
        }

        public class FaceAttributes
        {
            public double smile { get; set; }
            public string gender { get; set; }
            public double age { get; set; }
            public FacialHair facialHair { get; set; }
            public string glasses { get; set; }
            public Emotion emotion { get; set; }
        }

        public class FaceInfo
        {
            public string faceId { get; set; }
            public FaceRectangle faceRectangle { get; set; }
            public FaceAttributes faceAttributes { get; set; }
        }
    }
}

