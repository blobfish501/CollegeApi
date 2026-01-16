namespace Domain.Models;
public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}