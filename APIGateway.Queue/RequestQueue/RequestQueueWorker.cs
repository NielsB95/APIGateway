using System;
namespace APIGateway.Queue.RequestQueue
{
    public enum WorkerState
    {
        Idle,
        Busy
    }

    public class RequestQueueWorker
    {
        public WorkerState State { get; private set; }
        private IRequestProvider requestProvider;

        public RequestQueueWorker(IRequestProvider requestProvider)
        {
            this.State = WorkerState.Idle;
            this.requestProvider = requestProvider;
        }

        public virtual void OnRequestReceived(object sender, EventArgs e)
        {
            // Return if the worker is Busy.
            if (this.State == WorkerState.Busy)
                return;

            // Keep working while there is somehting on the queue.
            while (State != WorkerState.Idle)
                this.Work();
        }

        private void Work()
        {
            // Get the request from the queue.
            var request = requestProvider.ProvideRequest();

            if (request != null)
            {
                State = WorkerState.Busy;
                request.Process();
            }
            else
            {
                State = WorkerState.Idle;
            }
        }
    }
}
