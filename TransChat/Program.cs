using System;

namespace TransChat
{
    class Program
    {
        static void Main(string[] args)
        {
            var Port = 48750;
            var client = new Client();

            Console.WriteLine("Welcome to TransChat! Please enter your username.");

            //get username
            string username;
            do
            {
                Console.Write(Environment.NewLine + "username: ");
                username = Console.ReadLine();
            } 
            while (string.IsNullOrWhiteSpace(username));
            client.Name = username.Trim();

            
            Console.Write(Environment.NewLine);
            

            Console.Write("server password: ");
            var password = Console.ReadLine();

        }
    }
}
