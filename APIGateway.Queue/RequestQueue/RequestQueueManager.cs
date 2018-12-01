using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIGateway.Queue.Entities;

namespace APIGateway.Queue.RequestQueue
{
    public class RequestQueueManager : IRequestQueueManager
    {
        private ConcurrentQueue<ServiceRequest> requestQueue;

        public RequestQueueManager()
        {
            this.requestQueue = new ConcurrentQueue<ServiceRequest>();
        }

        public void Enqueue(ServiceRequest request)
        {
            this.requestQueue.Enqueue(request);
        }
    }
}
