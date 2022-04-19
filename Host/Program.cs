using System;
using System.ServiceModel;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Service.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("Сервер запущен!");
                Console.ReadLine();

            }
        }
    }
}
