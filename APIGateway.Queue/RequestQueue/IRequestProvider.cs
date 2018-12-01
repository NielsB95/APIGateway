using System;
using APIGateway.Queue.Entities;

namespace APIGateway.Queue.RequestQueue
{
    public interface IRequestProvider
    {
        ServiceRequest ProvideRequest();
    }
}
