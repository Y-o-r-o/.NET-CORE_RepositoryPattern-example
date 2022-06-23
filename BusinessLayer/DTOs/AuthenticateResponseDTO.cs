namespace BusinessLayer.DTOs;
public class AuthenticateResponseDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}