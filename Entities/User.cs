using System;
using System.Collections.Generic;

namespace library.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public override string ToString()
    {
        return $"id = {UserId}   |name = {Username} ,         | email = {Email}         | i am a {Role}";
    }
}
