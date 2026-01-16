namespace Domain.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int EnrollmentId { get; set; }

    public int GradeValue { get; set; }

    public DateOnly GradeDate { get; set; }

    public virtual Enrollment Enrollment { get; set; } = null!;
}
