namespace todolist.Models.Responses
{
    public class ResponseBaseModel<T>
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string Errors { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Error
    }
}