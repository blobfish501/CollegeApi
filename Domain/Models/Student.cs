namespace Domain.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public int GroupId { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Group Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
