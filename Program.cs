namespace ProducerConsumer
{

    public class Program
    {
        public static Cookie[] cookieArray = new Cookie[10];
        public static Queue<Cookie> cookieQ = new Queue<Cookie>();
        public static List<Cookie> consumedQueueCookies = new List<Cookie>();
        public static List<Cookie> consumedArrayCookies = new List<Cookie>();

        // Index is used to keep track on how many cookies there is, in the cookieArray
        public static int Index = 0;

        public static void Main()
        {
            Console.WriteLine("1. Array\n2. Queue");

            // Switch case on user input
            switch (Console.ReadLine())
            {

                case "1":
                    // Create an instance of the producer and consumer for the array solution
                    Producer producerArray = new Producer();
                    Consumer consumerArray = new Consumer();

                    Console.Clear();
                    ThreadPool.QueueUserWorkItem(producerArray.ProduceArray);
                    ThreadPool.QueueUserWorkItem(consumerArray.ConsumeArray);
                    break;
                case "2":
                    Console.Clear();
                    // Create an instance of the producer and consumer for the queue solution
                    Producer producer = new Producer();
                    Consumer consumer = new Consumer();
                    ThreadPool.QueueUserWorkItem(producer.ProduceQueue);
                    ThreadPool.QueueUserWorkItem(consumer.ConsumeQueue);

                    break;
                default: Console.WriteLine("Wrong Input"); break;
            }
            Console.ReadLine();
        }
    }
}