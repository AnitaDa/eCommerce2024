using System;
using System.Collections.Generic;

namespace eCommerce2024.API.Database.Models;

public partial class Efmigrationshistory
{
    public string MigrationId { get; set; } = null!;

    public string ProductVersion { get; set; } = null!;
}
