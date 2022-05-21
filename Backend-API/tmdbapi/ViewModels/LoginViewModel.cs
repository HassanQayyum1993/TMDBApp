namespace tmdbapi.ViewModels
{
    public class LoginViewModel: IResponse
    {
        public String? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
