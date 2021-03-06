namespace Lib.ApiServices.OpenWeatherMap
{
    public class GetWeatherResponse
    {
        public Coord coord { get; set; }
        public Weather[] weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public float visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public float dt { get; set; }
        public Sys sys { get; set; }
        public float id { get; set; }
        public string name { get; set; }
        public float cod { get; set; }

        public class Coord
        {
            public float lon { get; set; }
            public float lat { get; set; }
        }

        public class Main
        {
            public float temp { get; set; }
            public float pressure { get; set; }
            public float humidity { get; set; }
            public float temp_min { get; set; }
            public float temp_max { get; set; }
            public float sea_level { get; set; }
            public float grnd_level { get; set; }
        }

        public class Wind
        {
            public float speed { get; set; }
            public float deg { get; set; }
            public float gust { get; set; }
        }

        public class Clouds
        {
            public float all { get; set; }
        }

        public class Sys
        {
            public float type { get; set; }
            public float id { get; set; }
            public float message { get; set; }
            public string country { get; set; }
            public float sunrise { get; set; }
            public float sunset { get; set; }
        }

        public class Weather
        {
            public float id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }
    }
}
