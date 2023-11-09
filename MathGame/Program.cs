
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

    do
    {
        Console.WriteLine("Enter a number from 1 to 5");
        readResult = Console.ReadLine();
        validEntry = int.TryParse(readResult, out gameChoice);
        
        if (gameChoice < 1 || gameChoice > 5)
            validEntry = false;
                
    } while (!validEntry);

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
        break;

        default:
        break;
    }

    PlayGame(game);



}


// void additionGame()
// {
//     string readResult = "";
//     int operand1, operand2, result;
//     Random randomNumber = new Random();
    
//     Console.Clear();
//     Console.WriteLine("Addition Game selected");
    
//     operand1 = randomNumber.Next(101);
//     operand2 = randomNumber.Next(101);
//     result = operand1 + operand2;

//     Console.WriteLine($"What is {operand1} + {operand2}?");
//     readResult = Console.ReadLine();

//     if (int.Parse(readResult) == result)
//         Console.WriteLine("That's correct. You scored 5 points");
//     else
//         Console.WriteLine("That's not correct.");


// }

// void subtractionGame()
// {
//     string readResult = "";
//     int operand1, operand2, result;
//     Random randomNumber = new Random();
    
//     Console.Clear();
//     Console.WriteLine("Subtraction Game selected");
    
//     operand1 = randomNumber.Next(101);
//     operand2 = randomNumber.Next(101);
//     result = operand1 - operand2;

//     Console.WriteLine($"What is {operand1} - {operand2}?");
//     readResult = Console.ReadLine();

//     if (int.Parse(readResult) == result)
//         Console.WriteLine("That's correct. You scored 5 points");
//     else
//         Console.WriteLine("That's not correct.");
// }

// void multiplicationGame()
// {
//     string readResult = "";
//     int operand1, operand2, result;
//     Random randomNumber = new Random();
    
//     Console.Clear();
//     Console.WriteLine("Subtraction Game selected");
    
//     operand1 = randomNumber.Next(11);
//     operand2 = randomNumber.Next(11);
//     result = operand1 * operand2;

//     Console.WriteLine($"What is {operand1} * {operand2}?");
//     readResult = Console.ReadLine();

//     if (int.Parse(readResult) == result)
//         Console.WriteLine("That's correct. You scored 5 points");
//     else
//         Console.WriteLine("That's not correct.");
// }

/* void divisionGame()
{
    string readResult = "";
    int operand1, operand2, result;
    Random randomNumber = new Random();
    
    Console.Clear();
    Console.WriteLine("Subtraction Game selected");
    
    operand1 = randomNumber.Next(101);
    do 
    {
        operand2 = randomNumber.Next(1, 101);
    } while (operand1 % operand2 != 0);
    
    result = operand1 / operand2;

    Console.WriteLine($"What is {operand1} / {operand2}?");
    readResult = Console.ReadLine();

    if (int.Parse(readResult) == result)
        Console.WriteLine("That's correct. You scored 5 points");
    else
        Console.WriteLine("That's not correct.");
} */

void PlayGame(string game, string difficulty = "easy")
{
    string readResult = "";
    string operation = "";
    int operand1, operand2;
    int result = 0;
    Random randomNumber = new Random();
    
    Console.Clear();
    Console.WriteLine($"{game} selected");
    
    operand1 = randomNumber.Next(101);
    operand2 = randomNumber.Next(101);

    if (game == "addition")
    {
        result = operand1 + operand2;
        operation = "+";
    }
    else if (game == "subtraction")
    {
        result = operand1 - operand2;
        operation = "-";
    }
    else if (game == "multiplication")
    {
        result = operand1 * operand2;
        operation = "*";
    }
    else if (game == "division")
    {
        while (operand1 % operand2 != 0); 
        {
            operand2 = randomNumber.Next(1, 101);
        } 
        result = operand1 / operand2;
        operation = "/";
    }
        
    Console.WriteLine($"What is {operand1} {operation} {operand2}?");
    readResult = Console.ReadLine();

    if (int.Parse(readResult) == result)
        Console.WriteLine("That's correct. You scored 5 points");
    else
        Console.WriteLine("That's not correct.");
}

