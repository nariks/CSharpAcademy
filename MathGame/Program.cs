
using System.Diagnostics;
using System.Net;
using System.Numerics;

int gameChoice = 0;
int difficulty = 0;
int QuizLength = 1;
string operation = "";


do
{
    DisplayMenu();
    gameChoice = ReadUserInput();
    operation = ChooseOperation(gameChoice);

    if (operation == "")
        break;
    
        difficulty = ChooseDiffictulty();
        QuizLength = ChooseQuizLength();
        PlayGame(operation, difficulty, QuizLength);

} while (PlayAgain());

    

void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game. Available games to play:");
    Console.WriteLine("1 - Addition Game");
    Console.WriteLine("2 - Subtraction Game");
    Console.WriteLine("3 - Multiplication Game");
    Console.WriteLine("4 - Division Game");
    Console.WriteLine("5 - End Game\n");

}

string ChooseOperation(int gameChoice)
{
    switch (gameChoice)
    {
        case 1:
            return "addition";

        case 2:
            return "subtraction";

        case 3:
            return "multiplication";

        case 4:
            return "division";

        case 5:
        default:
            return "";
    }
}

int ChooseDiffictulty()
{
    Console.Clear();
    Console.WriteLine("Choose a difficulty level from 1 - 5");
    Console.WriteLine("1 is Easiest and 5 is Hardest\n ");
    
    return ReadUserInput();
}

int ChooseQuizLength()
{
    Console.Clear();
    Console.WriteLine("Choose number of quiz questions: 1 - 5");

    return ReadUserInput();
    
}

void PlayGame(string game, int difficulty = 1, int QuizLength = 1)
{
    string readResult = "";
    string operation = "";
    int operand1, operand2;
    int result = 0;
    const int stepSize = 21;
    Random randomNumber = new Random();
    
    Console.Clear();
    Console.WriteLine($"{game.ToUpper()} selected");
    Console.WriteLine("--------------------");
    
    int minValue = SetDifficultyLevel(difficulty);

    for(int i = 0; i < QuizLength; i++)
    {

        operand1 = randomNumber.Next(minValue, minValue + stepSize);
        operand2 = randomNumber.Next(minValue, minValue + stepSize);

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
                while (operand2 == 0 || operand1 % operand2 != 0) 
                {
                    minValue = (difficulty == 1) ? 1 : minValue;
                    operand2 = randomNumber.Next(minValue, minValue + stepSize);
                } 
                result = operand1 / operand2;
                operation = "/";
                break;

            default:
                break;
        }

        Console.WriteLine($"Q{i+1}: What is {operand1} {operation} {operand2}?");

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
            Console.WriteLine("That's correct. You scored 5 points\n");
        else
            Console.WriteLine("That's not correct\n.");
    }
}

int SetDifficultyLevel (int difficulty)
{
    switch(difficulty)
    {
        case 1:
            return 0;
        
        case 2:
            return 20;

        case 3:
            return 40;

        case 4:
            return 60;

        case 5:
            return 80;

        default:
            return 0;
    }

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

bool PlayAgain()
{
    Console.WriteLine("Would you like to play again (Y/N)?");
    string readResult = Console.ReadLine(); 
    if (readResult != null)
        return (readResult.ToLower() == "y");
    else
        return false;
}
