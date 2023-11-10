
using System.Diagnostics;
using System.Numerics;

DisplayMenu();
ProcessInput();

void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game. Available games to play:");
    Console.WriteLine("1 - Addition Game");
    Console.WriteLine("2 - Subtraction Game");
    Console.WriteLine("3 - Multiplication Game");
    Console.WriteLine("4 - Division Game");
    Console.WriteLine("5 - End Game");

}

void ProcessInput()
{
    int gameChoice = 0;
    string readResult = "";
    string game = "";
    bool validEntry = false;

    gameChoice = ReadUserInput();

    switch (gameChoice)
    {
        case 1:
            game = "addition";
            break;

        case 2:
            game = "subtraction";
            break;

        case 3:
            game = "multiplication";
            break;

        case 4:
            game = "division";;
            break;

        case 5:
        default:
            break;
    }

    if (gameChoice != 5)
        PlayGame(game, ChooseDiffictulty());
}


int ChooseDiffictulty()
{
    Console.Clear();
    Console.WriteLine("Choose a difficulty level from 1 - 5");
    Console.WriteLine("1 is Easiest and 5 is Hardest ");
    
    return ReadUserInput();
}

void PlayGame(string game, int difficulty = 1)
{
    string readResult = "";
    string operation = "";
    int operand1, operand2;
    int result = 0;
    Random randomNumber = new Random();
    
    Console.Clear();
    Console.WriteLine($"{game} selected");
    
    int minValue = SetDifficultyLevel(difficulty);
    operand1 = randomNumber.Next(minValue, minValue + 21);
    operand2 = randomNumber.Next(minValue, minValue + 21);

    switch(game)
    {
        case "addition":
            result = operand1 + operand2;
            operation = "+";
            break;

        case "subtraction":
            result = operand1 - operand2;
            operation = "-";
            break;

        case "multiplication":
            result = operand1 * operand2;
            operation = "*";
            break;

        case "division":
            while (operand1 % operand2 != 0) 
            {
                operand2 = randomNumber.Next(1, 101);
             } 
            result = operand1 / operand2;
            operation = "/";
            break;

        default:
            break;
    }
    
    Console.WriteLine($"What is {operand1} {operation} {operand2}?");

    int answer = 0;
    bool validEntry = false;

    do
    {
        readResult = Console.ReadLine();
        validEntry = int.TryParse(readResult, out answer);
        if (!validEntry)
            Console.WriteLine("Only numbers can be accepted as valid answer.");
    
    } while (!validEntry);
    
    if (answer == result)
        Console.WriteLine("That's correct. You scored 5 points");
    else
        Console.WriteLine("That's not correct.");
}

int SetDifficultyLevel (int difficulty)
{
    int minValue = 0;

    switch(difficulty)
    {
        case 1:
            minValue = 0;
            break;
        
        case 2:
            minValue = 20;
            break;

        case 3:
            minValue = 40;
            break;

        case 4:
            minValue = 60;
            break;

        case 5:
            minValue = 80;
            break;
    }

    return minValue;
}

int ReadUserInput()
{
    string readResult = "";
    int userChoice = 0;
    bool validEntry = false;

    do
    {
        Console.WriteLine("Enter a number from 1 to 5");
        readResult = Console.ReadLine();
        validEntry = int.TryParse(readResult, out userChoice);
        
        if (userChoice < 1 || userChoice > 5)
            validEntry = false;
                
    } while (!validEntry);

    return userChoice;

}

