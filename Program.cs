Random random = new Random();
string coinFlipResult = "";
string player1 = "";
string robotPlayer = "";
int player1Health = 21;
int robotPlayerHealth = 21;

string? readResult;
string coinSelection = "";
bool validEntry = false;
int interactionSelection;

// 1st we let the player choose, and we "flip" a coin to assing the characters. If the player wins they get the "good" character (if they lose, they get the "evil" character)

Console.Clear();
Console.WriteLine("Welcome to Fantasy Duel, traveler.");
Console.WriteLine("Let's decide where your path begins with a coin flip... shall we?");
Console.WriteLine();

do
{
    int coin = random.Next(1, 3);
    Console.WriteLine("Choose: heads or tails?");
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        coinSelection = readResult.Trim().ToLower();
        if (coinSelection == "heads" || coinSelection == "tails")
        {
            if (coin == 1)
            {
                coinFlipResult = "HEADS";
            }
            else
            {
                coinFlipResult = "TAILS";
            }

            Console.WriteLine();
            Console.WriteLine($"Ok, {coinSelection} it is. Here we go...!");
            Console.WriteLine($"Fate says... {coinFlipResult}!!");
            Console.WriteLine();

            if (coinSelection.ToUpper() == coinFlipResult)
            {
                player1 = "wizard";
                robotPlayer = "warlock";
                Console.Write("It's your lucky day! ");

            }
            else
            {
                player1 = "warlock";
                robotPlayer = "wizard";
                Console.Write("Seems like you got off the wrong foot flipping the coin... ");
            }
            Console.WriteLine($"Now you must carry on as a {player1}, and you will be facing a {robotPlayer}.");
            Console.WriteLine();
            validEntry = true;
        }
    }
} while (validEntry == false);

/* THE FIGHT.
There will be at least one interaction from the player. The player can chose to attack or heal.
The interactions will be alternating and will continue while both characters are still alive.
The game announces if the player wins or looses.
*/


do
{
    validEntry = false;
    int dicePoints;

    do
    {
        Console.WriteLine("It's your turn. You can choose between");
        Console.WriteLine("\t1. Attak");
        Console.WriteLine("\t2. Heal");
        Console.WriteLine();
        Console.WriteLine("Enter your choice");
        Console.WriteLine();
        readResult = Console.ReadLine();

        if (readResult != null)
        {
            bool validNumber = false;
            validNumber = int.TryParse(readResult, out interactionSelection);

            if (validNumber == true)
            {
                dicePoints = random.Next(0, 5);

                switch (interactionSelection)
                {
                    case 1: //atack
                        robotPlayerHealth -= dicePoints;
                        Console.WriteLine();
                        Console.WriteLine($"You attack with a fireball and inflict {dicePoints} points of damage.");
                        Console.WriteLine();
                        if ( robotPlayerHealth > 0)
                        {
                            Console.WriteLine($"The {robotPlayer} has now {robotPlayerHealth} points of life.");
                        }
                        else
                        {
                            Console.WriteLine($"The {robotPlayer} is dead! \tYOU WIN!!");
                        }
                        Console.WriteLine();
                        validEntry = true;
                        break;
                    case 2: //health
                        player1Health += dicePoints;
                        Console.WriteLine();
                        Console.WriteLine($"You cast a healing spell and increase in {dicePoints} your life points");
                        Console.WriteLine();
                        Console.WriteLine($"You have now {player1Health} life points");
                        Console.WriteLine();
                        validEntry = true;
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Wrong input. Please, try again");
                        Console.WriteLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Wrong input. Please, try again");
                Console.WriteLine();
            }
        }
    } while (validEntry == false);

    if (robotPlayerHealth <= 0) continue;

    dicePoints = random.Next(0, 5);
    int robotInteraction = random.Next(1, 3);
    if (robotInteraction == 1)
    {
        player1Health -= dicePoints;
        Console.WriteLine();
        Console.WriteLine($"The {robotPlayer} attacks you with a fireball and you sustain a {dicePoints} points injury");
        Console.WriteLine();
        if(player1Health > 0)
        {
            Console.WriteLine($"You have {player1Health} points of life left.");
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("You are dead!! \tYOU LOSE!!");
        }
        Console.WriteLine();
    }
    else
    {
        robotPlayerHealth += dicePoints;
        Console.WriteLine();
        Console.WriteLine($"The {robotPlayer} casts a healing spell and regains {dicePoints} points of life. He has now {robotPlayerHealth} points of life.");
        Console.WriteLine();
    }
}
while (player1Health > 0 && robotPlayerHealth > 0);





