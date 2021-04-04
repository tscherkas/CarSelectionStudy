using System;

namespace Models
{
    [Serializable]
    public class CarListItem
    {
        public int id { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public string html_url { get; set; }

    }
}