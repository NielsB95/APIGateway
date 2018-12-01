using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using APIGateway.Queue.Entities;

namespace APIGateway.Queue.RequestQueue
{
    public class RequestQueueManager : IRequestQueueManager, IRequestProvider
    {
        private readonly int maxWorkers = 3;

        private ConcurrentQueue<ServiceRequest> requestQueue;
        private ConcurrentBag<RequestQueueWorker> workers;

        private event EventHandler RequestReceived;

        public RequestQueueManager()
        {
            this.requestQueue = new ConcurrentQueue<ServiceRequest>();
            this.workers = new ConcurrentBag<RequestQueueWorker>();

            this.InitializeWorkers();
        }

        public void Enqueue(ServiceRequest request)
        {
            this.requestQueue.Enqueue(request);
        }

        private void InitializeWorkers()
        {
            for (int i = 0; i < maxWorkers; i++)
            {
                var worker = new RequestQueueWorker(this);

                // Subscribe to the RequestReceivedEvent.
                this.RequestReceived += worker.OnRequestReceived;

                workers.Add(worker);
            }
        }

        public ServiceRequest ProvideRequest()
        {
            this.requestQueue.TryDequeue(out ServiceRequest request);
            return request;
        }
    }
}
