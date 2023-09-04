namespace AicoAssistant
{
    public class Program
    {
        static void Main(string[] args)
        {
            string key = null;
            bool running = false;
            OpenAiApiClient client = null;

            key = Constants.Key;
            if (key == null)
            {
                Console.WriteLine("I do not have a key to connect to the mainframe. please type out your key and press enter.");
                key = Console.ReadLine();
            }


            while (client == null)
            {
                APIConnection connection = new APIConnection(key);
                client = connection.Connect();
                if (client != null)
                {
                    Console.WriteLine("connected to the mainframe :D ask ahead!");
                    running = true;
                }
                if (client == null)
                {
                    Console.WriteLine("the connection failed. maybe the key was wrong? try again please.");
                    key = Console.ReadLine();
                }
            }

            while (running)
            {
                string prompt = Console.ReadLine();
                if (prompt != null)
                {
                    SendPrompt(prompt, client);
                }
            }
        }

        static void SendPrompt(string prompt, OpenAiApiClient client)
        {
            string generatedText = client.GenerateTextAsync(prompt).GetAwaiter().GetResult();
            Console.WriteLine(generatedText);
        }
    }
}