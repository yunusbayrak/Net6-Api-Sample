﻿namespace UnluCoSample.Api.Helpers;
public class BaseApiResponse
{
    public object Message { get; set; }
    public int StatusCode { get; set; }
}

public class BaseApiResponse<T> : BaseApiResponse
{
    public T Data { get; set; }
}