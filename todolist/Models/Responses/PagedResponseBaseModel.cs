namespace todolist.Models.Responses
{
    public class PagedResponseBaseModel<T> : ResponseBaseModel<T>
    {
        public int Total { get; set; }
    }
}