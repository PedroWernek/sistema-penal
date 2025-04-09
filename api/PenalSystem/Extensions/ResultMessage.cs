using PenalSystem.Enums;

// auto-explicativa (espero)
public class ResultMessage
{
    public ResultMessage(string message, ResultTypes resultTypes)
    {
        Mensagem = message?? throw new ArgumentNullException(nameof(message));
        ResultType = resultTypes;
    }

    public string Mensagem { get; }
    public ResultTypes ResultType { get; }
}