namespace Domain.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}