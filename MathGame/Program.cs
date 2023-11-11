int gameChoice = 0;

int quizLength = 1;
string operation = "";
bool play = true;

List<string> gameHistory = new List<string>();
gameHistory.Add("Question\t\t| Solution\t| Your Answer");


void StartGame()
{
    do
    {
        int difficulty = 0;

        do
        {
            DisplayMenu();
            gameChoice = ReadUserInput();
            operation = ChooseOperation(gameChoice);

            if (operation == "")
                goto ExitGame;
        
            do
            {
                difficulty = ChooseDiffictulty();
                if (difficulty != 6)
                    quizLength = ChooseQuizLength();
            } while (difficulty!= 6 && quizLength == 6);            // Go back to difficulty menu
            

        } while (difficulty == 6);              // Go back to main menu

        PlayGame(operation, difficulty, quizLength);
        play = PlayAgain();

    } while (play);
}


ExitGame:
Console.WriteLine("\nGame Over !!!");
Console.WriteLine("Press Enter to continue...");
Console.ReadLine();

    

void DisplayMenu()
{
    Console.Clear();
    Console.WriteLine("Welcome to the Math Game. Enter your choice:");
    Console.WriteLine("1 - Addition Game");
    Console.WriteLine("2 - Subtraction Game");
    Console.WriteLine("3 - Multiplication Game");
    Console.WriteLine("4 - Division Game");
    Console.WriteLine("5 - View previous games");
    Console.WriteLine("6 - End Game\n");
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
            ShowHistory();
            return "";

        case 6:
        default:
            return "";
    }
}

int ChooseDiffictulty()
{
    Console.Clear();
    Console.WriteLine("Choose a difficulty level from 1 - 5");
    Console.WriteLine("1 is Easiest and 5 is Hardest\n ");
    Console.WriteLine("Or enter 6 to go back to main menu\n");
    
    return ReadUserInput();
}

int ChooseQuizLength()
{
    Console.Clear();
    Console.WriteLine("Choose number of quiz questions: 1 - 5");
    Console.WriteLine("Or enter 6 to go back to main menu\n");

    return ReadUserInput();
    
}

void PlayGame(string game, int difficulty = 1, int QuizLength = 1)
{
    int score = 0;
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
                while (operand1 % operand2 != 0) 
                {
                    operand2 = randomNumber.Next(1, minValue + stepSize);
                } 
                result = operand1 / operand2;
                operation = "/";
                break;

            default:
                break;
        }

        string question =  $"( {operand1} {operation} {operand2} )";
        Console.WriteLine($"Qn{i+1}: What is {question} ?");
        
        int playerAnswer = GetPlayerSolution();
        
        gameHistory.Add(question + "\t\t| " + result + "\t\t| " + playerAnswer);

        if (playerAnswer == result)
        {
            Console.WriteLine("That's correct. \u2705\n");  
            score++;  
        }
        else
        {
            Console.WriteLine("That's not correct. \u274c\n");
        }
            
    }
    Console.WriteLine($"Game Over ! You scored {score} points\n");
}

int SetDifficultyLevel (int difficulty)
{
    switch(difficulty)
    {
        case 1:
            return 1;
        
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
        Console.WriteLine("Enter a number from 1 to 6");
        readResult = Console.ReadLine();
        validEntry = int.TryParse(readResult, out userChoice);
        
        if (userChoice < 1 || userChoice > 6)
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

int GetPlayerSolution()
{
    int answer = 0;
    bool validEntry = false;
        
    do
    {
        string readResult = Console.ReadLine();
        validEntry = int.TryParse(readResult, out answer);
        if (!validEntry)
            Console.WriteLine("Only numbers can be accepted as valid answer.");

    } while (!validEntry);

    return answer;
}

void ShowHistory()
{
    Console.Clear();
    Console.WriteLine("Game History\n");

    if (gameHistory.Count() == 1)
    {
        Console.WriteLine("No Games played yet!");
        return;
    }
        

    foreach (string game in gameHistory)
    {
        Console.WriteLine(game);
    }
}
