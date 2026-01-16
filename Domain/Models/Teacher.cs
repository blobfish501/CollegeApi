namespace Domain.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Department Department { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
