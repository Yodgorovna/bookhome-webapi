﻿namespace BookHome.Persistance.Dtos.Auth;

public class ResetPasswordDto
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}
