namespace mission06_Hagerty.Models;

public class Movie
{
    public int MovieId { get; set; } // Primary Key
    public string Category { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; } // Dropdown (G, PG, PG-13, R)
    public bool? Edited { get; set; } // Nullable for not required
    public string? LentTo { get; set; } // Nullable
    public string? Notes { get; set; } // Max 25 chars
}