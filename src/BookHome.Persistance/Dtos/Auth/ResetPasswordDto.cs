﻿namespace BookHome.Persistance.Dtos.Auth;

public class ResetPasswordDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
