public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }

    // Extra getter to access the student's name since it's private in base class
    private string GetStudentName()
    {
        // Usa GetSummary e separa o nome do tópico (não ideal, mas contorna o escopo de acesso)
        return GetSummary().Split(" - ")[0];
    }
}
