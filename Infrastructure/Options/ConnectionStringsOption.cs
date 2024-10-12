namespace Infrastructure.Options;

public abstract class ConnectionStringsOption
{
    public string DefaultConnection { get; set; } = string.Empty;
}