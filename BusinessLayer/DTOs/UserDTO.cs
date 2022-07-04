namespace BusinessLayer.DTOs;

public class UserDTO
{
    /// <summary>
    /// User display name.
    /// </summary>
    /// <example>ThereGoesMyNickname</example>
    public string DisplayName { get; set; }

    /// <summary>
    /// Biography/description of user.
    /// </summary>
    /// <example>I'm 22 years old, currently studing at VT.</example>
    public string? Bio { get; set; }
}
