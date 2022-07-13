namespace BusinessLayer.DTOs;

public class LoginDTO
{
    /// <summary>
    /// User email
    /// </summary>
    /// <example>tom@test.com</example>
    public string Email { get; set; }

    /// <summary>
    /// User password.
    /// Must have two sybols, one upper case and one number.
    /// </summary>
    /// <example>Pa$$w0rd</example>
    public string Password { get; set; }
}