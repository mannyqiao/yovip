

namespace Enjoy.Core.Services
{
    using System.Threading;
    public class DataWriteStreamService : IDataWriteStreamService<IDataEntity>
    {
        private DataWriteStreamService() { }
        private static DataWriteStreamService stream;
        private static object state = new object();
        public static DataWriteStreamService Stream
        {
            get
            {
                lock (state)
                {
                    if (stream == null)
                    {
                        lock (state)
                        {
                            stream = new DataWriteStreamService();
                            stream.Run(new CancellationToken());
                        }
                    }
                    return stream;
                }
            }
        }
        protected BatchProcessor<IDataEntity> Processor;
        protected CancellationToken Token;
        protected IDataWriteDirectlyService<IDataEntity> WriteDirectly;

        public void Stop()
        {
            this.Processor.Complete();
        }

        public void Write(IDataEntity entity)
        {
            this.Processor.Pass(entity);
        }
        protected void InitializeBlocks(
           CancellationToken token,
           int size = 50, int interval = 1, int degree = 5,
           bool isWaiting = true)
        {
            WriteDirectly = new DataWriteDirectlyService();
            this.Processor = new BatchProcessor<IDataEntity>(WriteDirectly.Save, size, interval, degree, isWaiting);
            this.Processor.Initialize(token);
        }

        protected void Run(CancellationToken token)
        {
            InitializeBlocks(token);
        }
    }
}
