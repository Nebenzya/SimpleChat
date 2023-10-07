using System;
using System.ServiceModel;

namespace Host
{
    internal class Program
    {
        private static ServiceHost host;
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

            try
            {
                using (host = new ServiceHost(typeof(Service.ServiceChat)))
                {
                    host.Open();
                    Console.WriteLine($"Статус сервера - {host.State}");
                    foreach (var endp in host.Description.Endpoints)
                    {
                        Console.WriteLine($"{endp.Name}\t{endp.Address}");
                    }

                    Console.WriteLine("Нажмите \"Enter\" чтобы остановить Host");
                    Console.ReadLine();
                }
            }
            catch (Exception ex )
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Close();
            }
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Close();
        }

        static void Close()
        {
            if (host != null && host.State != CommunicationState.Closed)
            {
                host?.Close();
                Console.WriteLine("Подключение закрыто!");
            }
        }
    }
}
