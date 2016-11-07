namespace DayCare.Models.Utilities
{
    public enum AlertType
    {
        Error,
        Info,
        Warning,
        Success
    }

    public class Alert
    {
        public AlertType Type { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
        public string ExceptionMessage { get; set; }

        public Alert()
        {
            Type = AlertType.Success;
            Dismissable = true;
        }
        public Alert(AlertType type, string message)
        {
            Type = type;
            Message = message;
            Dismissable = true;
        }
    }  
}