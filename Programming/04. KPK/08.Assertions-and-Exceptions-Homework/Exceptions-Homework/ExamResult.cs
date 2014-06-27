using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException("The grade should be positive number!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("Minimal grade should be positive number!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Maximal grade should be bigger than minimal grade!");
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentException("The comment is empty! Please write some!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
