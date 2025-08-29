namespace RapidAPIConsume.Models
{
    public class FootballNewsViewModel
    {

            public Result[] result { get; set; }


        public class Result
        {
            public int id { get; set; }
            public string title { get; set; }
            public int?[] categories { get; set; }
            public int?[] leagues { get; set; }
            public int[] teams { get; set; }
        }

    }
}
