using System.ComponentModel.DataAnnotations;

public class City
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string District { get; set; }

    public int Population { get; set; }
}
