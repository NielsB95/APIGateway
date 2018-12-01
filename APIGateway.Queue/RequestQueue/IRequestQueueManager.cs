using System;
using APIGateway.Queue.Entities;

namespace APIGateway.Queue.RequestQueue
{
    public interface IRequestQueueManager
    {
        void Enqueue(ServiceRequest request);
    }
}
