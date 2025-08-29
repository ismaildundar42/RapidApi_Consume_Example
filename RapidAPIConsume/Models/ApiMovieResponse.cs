namespace RapidAPIConsume.Models
{
    public class ApiMovieResponse
    {
        public string Page { get; set; }
        public List<ApiMovieViewModel> Result { get; set; }
    }
}
