using System;
using System.Threading;
using System.Media;

class Program
{
    static void Main()
    {
        Console.Title = "MzansiShield Chatbot";

        ShowHeader();
        ShowAsciiLogo(); 
        PlayVoiceGreeting(); 

        string userName = GetUserName();

        ChatLoop(userName);
    }

    static void ShowHeader()
    {
        //ASCII Logo Added
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=======================================");
        Console.WriteLine("        MZANSHISHIELD ASSISTANT        ");
        Console.WriteLine("=======================================");
        Console.ResetColor();
        Console.WriteLine();
    }

    static void ShowAsciiLogo()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("▄▄▄     ▄▄▄                              ▄▄▄▄▄                 ▄▄              ▄▄");
        Console.WriteLine("███▄ ▄███                              ██▀▀▀▀█▄ █▄             ██    █▄     ▄█▀▀█▄                        █▄");
        Console.WriteLine("██ ▀█▀ ██               ▄           ▀▀ ▀██▄  ▄▀ ██    ▀▀       ██    ██     ██  ██               ▀▀      ▄██▄");
        Console.WriteLine("██     ██   ▀▀▀██ ▄▀▀█▄ ████▄ ▄██▀█ ██   ▀██▄▄  ████▄ ██ ▄█▀█▄ ██ ▄████     ██▀▀██   ▄██▀█ ▄██▀█ ██ ▄██▀█ ██");
        Console.WriteLine("██     ██     ▄█▀ ▄█▀██ ██ ██ ▀███▄ ██ ▄   ▀██▄ ██ ██ ██ ██▄█▀ ██ ██ ██   ▄ ██  ██   ▀███▄ ▀███▄ ██ ▀███▄ ██");   
      Console.WriteLine("▀██▀     ▀██▄▄▄██▄▄▄▀█▄██▄██ ▀██▄▄██▀▄██ ▀██████▀▄██ ██▄██▄▀█▄▄▄▄██▄█▀███   ▀██▀  ▀█▄██▄▄██▀█▄▄██▀▄███▄▄██▀▄██");   


      Console.ResetColor();
        Console.WriteLine();
    }

    //voice
    // voice feature added
    static void PlayVoiceGreeting()
    {
        try
        {
            SoundPlayer player = new SoundPlayer("myvoice.wav");
            player.PlaySync();
        }
        catch
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Voice file not found.");
            Console.ResetColor();
        }
    }

    // get the users name
    //added a prompt to get users name then use it to interact
    static string GetUserName()
    {
        Console.ForegroundColor = ConsoleColor.White;

        TypeText("Hi, I'm MzansiShield \n");
        TypeText("Your cybersecurity assistant.\n\n");

        TypeText("What is your name? ");
        string name = Console.ReadLine();

        Console.ForegroundColor = ConsoleColor.Green;
        TypeText($"\nNice to meet you, {name}!\n");

        return name;
    }

    // chatting here 
    // added chatbot responses to realted topics
    static void ChatLoop(string name)
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=======================================");
            Console.WriteLine(" Topics: phishing | scams | passwords | links | email");
            Console.WriteLine(" Type 'exit' to quit");
            Console.WriteLine("=======================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nYou: ");
            string input = Console.ReadLine().ToLower();

            if (input == "exit")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                TypeText($"\nGoodbye {name}, stay safe online! \n");
                break;
            }

            Respond(input, name);
        }
    }

    // responses
    static void Respond(string input, string name)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        if (input.Contains("phishing"))
        {
            TypeText($"\n{name}, be careful of phishing emails.\n");
            TypeText("Do not share personal info.\n");
        }
        else if (input.Contains("scam"))
        {
            TypeText($"\n{name}, scams often look too good to be true.\n");
            TypeText("Never send money to strangers.\n");
        }
        else if (input.Contains("password"))
        {
            TypeText($"\n{name}, use strong passwords.\n");
            TypeText("Include symbols, numbers, and do not reuse them.\n");
        }
        else if (input.Contains("link"))
        {
            TypeText($"\n{name}, avoid clicking unknown links.\n");
            TypeText("Always check the URL first.\n");
        }
        else if (input.Contains("email"))
        {
            Console.ForegroundColor = ConsoleColor.Green;

            TypeText($"\n{name}, here's a scenario:\n");
            TypeText("You receive an email saying:\n");
            TypeText("'Your bank account is locked. Click here.'\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("\nWhat do you do?\n");
            TypeText("1. Click link\n");
            TypeText("2. Contact bank\n");

            Console.Write("\nChoice: ");
            string choice = Console.ReadLine();

            if (choice == "2")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                TypeText($"\nCorrect, {name}! Always verify first.\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeText($"\nWrong, {name}! That is phishing.\n");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText($"\n{name}, I didn't understand that.\n");
        }

        Console.ResetColor();
    }

    static void TypeText(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(20);
        }
    }
}
