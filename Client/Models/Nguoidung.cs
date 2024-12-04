using System;
using System.Collections.Generic;

namespace Client.Models;

public partial class Nguoidung
{
    public string Mand { get; set; } = null!;

    public string? Tennd { get; set; }

    public string? Nationality { get; set; }

    public string? Email { get; set; }

    public string? Matkhau { get; set; }

    public byte[]? Imageuser { get; set; }
}
