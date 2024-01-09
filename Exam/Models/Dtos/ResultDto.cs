namespace Models.dtos;

public class ResultDto
{
    public List<Log> Logs { get; set; }
    public Character Winner { get; set; }

    public ResultDto() { }
}