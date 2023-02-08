namespace LunarExplorer.Model
    ;
public class RoverException : Exception {
    public String message_ = "";
    public RoverException(String message)
    {
        message_ = message;
        Console.Write($"{message_}: ");
    }
}