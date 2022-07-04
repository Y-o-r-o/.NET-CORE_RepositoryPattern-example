using Swashbuckle.AspNetCore.Annotations;

namespace BusinessLayer.DTOs;
public class AuthenticateResponseDTO
{
    /// <summary>
    /// Access token.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2NTYzMjE5MjYsImV4cCI6MTY1NjMyNTUyNiwiaWF0IjoxNjU2MzIxOTI2fQ.XH5IBkUDdiaPBvJw3Hw5u15puEVPoM6Fjn_k6G0-Rp0</example>
    public string AccessToken { get; set; }

    /// <summary>
    /// Access token.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjJlY2IwMDNkLTVmMDktNGY4MS04MmY3LWVlNzM4ODE2NTQzMiIsImVtYWlsIjoidG9tQHRlc3QuY29tIiwibmFtZSI6InRvbSIsIm5iZiI6MTY1NjU2OTU0NCwiZXhwIjoxNjU2NTY5NjA0LCJpYXQiOjE2NTY1Njk1NDR9.TnQwrd5X6w8FJvC7w7Hqk6JcUYAOY1d035QSL7tLu0E</example>
    public string RefreshToken { get; set; }
}