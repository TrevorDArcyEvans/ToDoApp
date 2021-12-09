namespace ToDoAPI.Models
{
  using System.ComponentModel.DataAnnotations;

  public sealed record ToDoItemModel
  {
    public int Id { get; set; }

    [Required]
    public string Description { get; set; }

    public bool IsCompleted { get; set; }

    #region Equals overrides

    public bool Equals(ToDoItemModel other)
    {
      if (ReferenceEquals(null, other))
      {
        return false;
      }

      if (ReferenceEquals(this, other))
      {
        return true;
      }

      return Id == other.Id;
    }

    public override int GetHashCode()
    {
      return Id;
    }

    #endregion
  }
}
