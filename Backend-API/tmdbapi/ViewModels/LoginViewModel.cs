namespace tmdbapi.ViewModels
{
    public class LoginViewModel: IResponse
    {
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
