using System;


    internal class GuessWord2
{
    static void Main(string[] args)
    {
        Start();
        Console.ReadKey();
    }

    static void Start()
    {

        Console.WriteLine("System Guessed the Name of fruit. Try, to guess it.");
        string[] fruits = { "apple", "peach", "watermelon", "melon", "strawberry",
                            "orange","berry","cherry","banana","grape","Kiwi","Lemon","pineapple"};

        Random randomWord = new Random();
        int index = randomWord.Next(0, fruits.Length);

        char[] Array = fruits[index].ToCharArray();

        CheckLetterWord(Array);
    }

    static string GetLetter()
    {
        Console.Write("Try guess the word or enter a letter: ");

        return Console.ReadLine();
    }

    static void CheckLetterWord(char[] Array)
    {
        char[] tempArray = new char[Array.Length];
        int counter = 0;

        string enteredWord;
        string mainWord;

        bool noMathces;

        for (int index = 0; index < tempArray.Length; index++)
        {
            tempArray[index] = '*';
        }

        do
        {
            enteredWord = GetLetter().ToString();
            mainWord = new string(Array);

            noMathces = true;

            char symbol = enteredWord[0];

            for (int index = 0; index < Array.Length; index++)
            {
                if (Array[index].Equals(symbol) && tempArray[index] == '*')
                {
                    tempArray[index] = Array[index];
                    counter++;
                    noMathces = false;
                }
            }

            if (noMathces)
            {
                Console.WriteLine("Such letter not Included...\n");
            }

            if (mainWord.Equals(enteredWord))
            {
                Victory();
                DrawArray(enteredWord.ToCharArray());
                return;
            }

            if (counter == Array.Length)
            {
                Victory();
                DrawArray(mainWord.ToCharArray());
                return;
            }

            Console.WriteLine();

            DrawArray(tempArray);

        } while (counter < Array.Length);
    }

    static void DrawArray(char[] Array)
    {
        Console.Write("Hidden word is: ");
        for (int index = 0; index < Array.Length; index++)
        {
            Console.Write(Array[index]);
        }
        Console.WriteLine("\n");
    }

    static void Victory()
    {
        Console.WriteLine();
        Console.WriteLine("Congratulation You guessed the word.!");
    }
}
