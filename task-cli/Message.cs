public enum MessageType {
    Info = 0,
    Warning = 1, 
    Error = 2
}
internal static class Message {

    public static void Format(string msg, MessageType msgType) {
        switch(msgType) {
            case MessageType.Error :
                msg = $"Error: {msg}";
                break;
            case MessageType.Warning:
                msg = $"Warning: {msg}";
                break;
        }
        Console.WriteLine(msg);
    }
}