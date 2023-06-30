namespace SushiRest.Api.Entities;

public class DbImage : Entity
{
    #region Fields

    public string? Extension { get; set; }
    public string Name => $"{Id}.{Extension}";

    #endregion

}