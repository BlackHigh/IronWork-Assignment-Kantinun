// See https://aka.ms/new-console-template for more information
using System.Text;


//Variable
//static Config (Can be dynamic too , can discuss in interview)
Dictionary<decimal, List<char>> phoneAlphabet = new()

{
    { 0, new List<char> { ' ' } },
    { 1, new List<char> { '&', '\'', '(' } },
    { 2, new List<char> { 'A', 'B', 'C' } },
    { 3, new List<char> { 'D', 'E', 'F' } },
    { 4, new List<char> { 'G', 'H', 'I' } },
    { 5, new List<char> { 'J', 'K', 'L' } },
    { 6, new List<char> { 'M', 'N', 'O' } },
    { 7, new List<char> { 'P', 'Q', 'R', 'S' } },
    { 8, new List<char> { 'T', 'U', 'V' } },
    { 9, new List<char> { 'W', 'X', 'Y', 'Z' } }
};

//Method Section
//
//Assignment Method
//string? for implementing nullable varialbe
string oldPhonePad(string? input) 
{
    StringBuilder monitor = new StringBuilder(); //PhoneMonitor
    StringBuilder inputMonitor = new StringBuilder(); //InputMonitor (Thing you type In)

    if (!String.IsNullOrWhiteSpace(input))
    {
        //you don't need to for each and print for each character but I'm simulating what you going to see when you typing
        //in OldPhone

        string[] charracterList = input.Split(' '); //split the space from each character

        foreach(string character in charracterList) //Loop for each Character
        {
            int i = 0; //for loop count
            int count = 0; //for number duplication count
            foreach (char ch in character)
            {
                if (ch.Equals('*') || ch.Equals('#') ||  decimal.TryParse(ch.ToString(), out decimal result))
                {
                    inputMonitor.Append(ch);
                    if (ch.Equals('#')) //end typing
                    {
                        Console.WriteLine("typing: {0}", inputMonitor.ToString());
                        Console.WriteLine("end Typing");
                        return monitor.ToString(); //can be exploit
                    }
                    else if (ch.Equals('*') && monitor.Length > 1) //delete previous char
                    {
                        
                        Console.WriteLine("typing: {0}", inputMonitor.ToString());
                        Console.WriteLine("deleting previous char");
                        monitor.Remove(monitor.Length - 1, 1);
                        Console.WriteLine("Showing: {0}", monitor.ToString());
                    }
                    //can use Mod(%) to simplifly but I want to demonstate the phone monitor
                    else if (i != 0 && ch.Equals(character[i - 1]))
                    {
                        if (phoneAlphabet.TryGetValue(decimal.Parse(ch.ToString()), out var test))
                        {
                            count++;
                            if (count >= phoneAlphabet[decimal.Parse(ch.ToString())].Count) count -= phoneAlphabet[decimal.Parse(ch.ToString())].Count;
                            monitor.Remove(monitor.Length - 1, 1);
                            monitor.Append(phoneAlphabet[decimal.Parse(ch.ToString())][count]);
                            Console.WriteLine("typing: {0}", inputMonitor.ToString());
                            Console.WriteLine("Showing: {0}", monitor.ToString());

                        }
                        else return "?????";
                    }
                    else if (i != 0 && !ch.Equals(character[i - 1]))
                    {
                        return "?????";
                    }
                    else
                    {
                        count = 0;
                        if (phoneAlphabet.TryGetValue(decimal.Parse(ch.ToString()), out var test))
                        {
                            monitor.Append(phoneAlphabet[decimal.Parse(ch.ToString())][count]);
                            Console.WriteLine("typing: {0}", inputMonitor.ToString());
                            Console.WriteLine("Showing: {0}", monitor.ToString());
                        }
                        else return "?????";
                    }
                }
                else return "?????";
                i++;
            }
        }
    }

    return monitor.ToString();
}

//Tweak Phone Pad Output
//string? for implementing nullable varialbe
string newPhonePad(string? input)
{
    StringBuilder monitor = new StringBuilder(); //PhoneMonitor
    StringBuilder inputMonitor = new StringBuilder(); //Input Monitor (Thing you type In)

    if (!String.IsNullOrWhiteSpace(input))
    {
       //you don't need to for each and print for each character but I'm simulating what you going to see when you typing
        //in OldPhone

        string[] charracterList = input.Split(' '); //split the space from each character (Not nessacary much in newPhone)

        foreach (string character in charracterList) //Loop for each Character
        {
            int i = 0; //for loop count
            int count = 0; //for number duplication count
            foreach (char ch in character)
            {
                if (ch.Equals('*') || ch.Equals('#') || decimal.TryParse(ch.ToString(), out decimal result))
                {
                    inputMonitor.Append(ch);
                    if (ch.Equals('#')) return monitor.ToString(); //can be exploit
                    else if (ch.Equals('*') && monitor.Length > 1) monitor.Remove(monitor.Length - 1, 1);
                    //can use Mod(%) to simplifly but I want to demonstate the phone monitor
                    else if (i != 0 && ch.Equals(character[i - 1]))
                    {
                        if (phoneAlphabet.TryGetValue(decimal.Parse(ch.ToString()), out var test))
                        {
                            count++;
                            if (count >= phoneAlphabet[decimal.Parse(ch.ToString())].Count) count -= phoneAlphabet[decimal.Parse(ch.ToString())].Count;
                            monitor.Remove(monitor.Length - 1, 1);
                            monitor.Append(phoneAlphabet[decimal.Parse(ch.ToString())][count]);
                            Console.WriteLine("typing: {0}", inputMonitor.ToString());
                            Console.WriteLine("Showing: {0}", monitor.ToString());

                        }
                        else return "?????";
                    }
                    else
                    {
                        count = 0;
                        if (phoneAlphabet.TryGetValue(decimal.Parse(ch.ToString()), out var test))
                        {
                            monitor.Append(phoneAlphabet[decimal.Parse(ch.ToString())][count]);
                            Console.WriteLine("typing: {0}", inputMonitor.ToString());
                            Console.WriteLine("Showing: {0}", monitor.ToString());
                        }
                        else return "?????";
                    }
                    i++;
                }
                else return "?????";
            }
        }
    }

    return monitor.ToString();
}

static void writeDotLine() 
{
    Console.WriteLine("------------------------------------------------------------------");
}


//Main Section

Console.WriteLine("Hello, World! ,Hello Iron Work!, Hello my new Boss!");
writeDotLine();
writeDotLine();
Console.Write("What's your name: "); 
string? name = Console.ReadLine();
Console.WriteLine("Nice you pass : Mr. {0}", name); //LOL
writeDotLine();
Console.Write("JUst Kidding Pleaes write your input: ");
string? input = Console.ReadLine();
writeDotLine();
writeDotLine();
string oldOutput = oldPhonePad(input);
Console.WriteLine("Nokia 1150 output: {0}", oldOutput); //Assignment Output
writeDotLine();
string newOutput = newPhonePad(input);
Console.WriteLine("Nokia 3310 output: {0}", newOutput); //Tweak Output
if (!String.IsNullOrEmpty(input) && (input.Replace(" ", "").Replace("*", "").Replace("#", "").Trim().Equals("36776") || input.Equals("36667 7666"))) Console.WriteLine("You Know What, I Don't know where I should go");
writeDotLine();
writeDotLine();
Console.WriteLine("End of program");

