using P02._Worker_Before.Contracts;

namespace P02._Worker_Before
{
    public class Manager
    {
        public Manager(IWorker worker)
        {
            this.Worker = worker;
            worker.Work();
        }

        public IWorker Worker { get; private set; }

    }
}
