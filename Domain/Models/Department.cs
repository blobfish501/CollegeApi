namespace Domain.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}