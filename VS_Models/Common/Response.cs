namespace VS_Models.Common
{
    /// <summary>
    /// A data container that maintain & transfer data between ui & api
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public T? Data { get; set; }
        public List<T>? DataList { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}
