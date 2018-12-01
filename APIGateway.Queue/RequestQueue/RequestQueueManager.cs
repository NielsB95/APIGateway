using System;
using System.Collections.Concurrent;
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
            // Add the request to the queue.
            this.requestQueue.Enqueue(request);

            // Notify the workers that there is a new request for
            // them to process.
            RequestReceived(this, null);
        }

        private void InitializeWorkers()
        {
            for (int i = 0; i < maxWorkers; i++)
            {
                var worker = new RequestQueueWorker(this);

                // Subscribe to the RequestReceivedEvent.
                this.RequestReceived += worker.OnRequestReceived;
                this.workers.Add(worker);
            }
        }

        public ServiceRequest ProvideRequest()
        {
            this.requestQueue.TryDequeue(out ServiceRequest request);
            return request;
        }
    }
}
