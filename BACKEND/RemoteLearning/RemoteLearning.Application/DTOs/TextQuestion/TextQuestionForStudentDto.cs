namespace RemoteLearning.Application.DTOs.TextQuestion;

public class TextQuestionForStudentDto
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string[] Answers { get; set; } = new string[4];
}
