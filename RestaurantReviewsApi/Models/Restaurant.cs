using System;
using System.Collections.Generic;

namespace RestaurantReviewsApi.Models;

public partial class Restaurant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Review { get; set; }

    public int? Rating { get; set; }
}
