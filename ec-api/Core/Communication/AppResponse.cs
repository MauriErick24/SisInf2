namespace core.Communication
{
    public class AppResponse<T> where T : class
    {
        public AppResponse(bool success, string message, T entity)
        {
            Entity = entity;
            Success = success;
            Message = message;
        }

        public AppResponse(T entity) : this(true, string.Empty, entity)
        {
        }

        public AppResponse(string message) : this(false, message, null)
        {
        }

        public T Entity { get; private set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
