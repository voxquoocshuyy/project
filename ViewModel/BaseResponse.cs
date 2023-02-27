namespace webapi;

public class BaseResponse<T>
{

    public int Code { get; set; }
    public string Msg { get; set; }
    public T Data { get; set; }
}

public class ModelsResponse<T>
{
    public int Code { get; set; }
    public string Msg { get; set; }
    public List<T> Data { get; set; }
}