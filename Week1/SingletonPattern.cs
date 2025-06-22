using System;

namespace SingletonPattern
{
    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();

        private Logger() { }

        public static Logger Instance
        {
            get { return instance; }
        }

        public void Log(string message)
        {
            Console.WriteLine("LOG: " + message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            logger1.Log("This is a log message.");

            if (object.ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("Both logger1 and logger2 are the same instance.");
            }
            else
            {
                Console.WriteLine("Different instances exist! Singleton failed.");
            }
        }
    }
}
