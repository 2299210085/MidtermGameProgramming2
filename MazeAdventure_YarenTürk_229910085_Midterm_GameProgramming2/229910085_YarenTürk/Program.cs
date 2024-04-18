using System;
using System.Threading.Tasks;

// Player class
class Player
{
    public int Health { get; set; }  // Player's health value
    public int FireballCount { get; set; }  // Player's fireball count
    public int PotionCount { get; set; }  // Player's potion count

    // Player constructor
    public Player(int health, int fireballCount, int potionCount)
    {
        Health = health;
        FireballCount = fireballCount;
        PotionCount = potionCount;
    }

    // Method for attacking with sword and spear
    public void AttackWithSwordAndSpear(Dragon dragon)
    {
        Console.WriteLine("Grimlok is attacking the dragon with sword and spear!");
        dragon.Health -= 20; // Decrease dragon's health by 20
        Console.WriteLine($"Dragon's health: {dragon.Health}"); // Show dragon's current health after the attack
    }

    // Method for collecting potion
    public void CollectPotion()
    {
        Console.WriteLine("Grimlok is collecting a potion in the forest.");

        Health += 20; // Increase health value by 20

        Console.WriteLine($"Grimlok's potion power increased! New health value: {Health}");

        Console.WriteLine($"Grimlok's health: {Health}"); // Show player's current health
        // Dragon's health status cannot be shown here as the dragon variable is not defined within this method
        Console.WriteLine(); // Add a blank line

        Console.WriteLine("\nChoose an action:"); // Show options to the user
        Console.WriteLine("1. Collect potion");
        Console.WriteLine("2. Continue exploring");
        Console.WriteLine("3. Exit the game");

        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice)) // Ask for a valid input from the user
        {
            Console.WriteLine("Invalid input. Please try again."); // Display invalid input message
        }

        // Perform the selected action
        switch (choice)
        {
            case 1:
                CollectPotion(); // Option to collect potion
                break;
            case 2:
                // Continue exploring (loop continues)
                break;
            case 3:
                Console.WriteLine("Exiting the game.");
                return; // Exit the game
            default:
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3."); // Display invalid choice message
                break;
        }
    }
}

// Dragon class
class Dragon
{
    public int Health { get; set; }  // Dragon's health value
    public int FireballCount { get; set; }  // Dragon's fireball count
    public int PotionCount { get; set; }  // Dragon's potion count

    // Dragon constructor
    public Dragon(int health, int fireballCount, int potionCount)
    {
        Health = health;
        FireballCount = fireballCount;
        PotionCount = potionCount;
    }

    // Method for reacting to daytime attack
    public void DaytimeAttack()
    {
        Console.WriteLine("Dragon is attacking Grimlok with a fireball!");
        Health -= 20; // Decrease dragon's health by 20
        Console.WriteLine($"Grimlok's health: {Health}"); // Show Grimlok's current health after the attack
    }

    // Method for attacking with fireballs
    public void AttackWithFireballs(Player grimlok)
    {
        grimlok.Health -= 20; // Decrease Grimlok's health by 20
        Console.WriteLine($"Grimlok's health: {grimlok.Health}"); // Show Grimlok's current health after the attack
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Grimlok stepped into the dark and mysterious forest, ready for an adventurous journey. Courage, the sole strength in his heart, was the force propelling him forward in this challenging quest. However, the labyrinthine paths of the forest quickly drew him in, and he lost his way in an instant.\n");

        Console.WriteLine("With his heart racing, Grimlok drew his sword and prepared himself. Before him stood a creature as large as a dragon, with eyes filled with fire. The time had come to bravely face the danger ahead.\n");

        Console.WriteLine("As the monster roared, its cry echoing through the forest, Grimlok attacked boldly. His sword pierced the creature's armor, and the battle began with a clang. A fierce struggle ensued, intense enough to pierce through the silence of the forest.\n");

        // Create instances of Player and Dragon
        Player grimlok = new Player(100, 5, 3); // Starting health: 100
        Dragon dragon = new Dragon(100, 10, 2); // Starting health: 100

        // Game loop
        while (grimlok.Health > 0 && dragon.Health > 0)
        {
            // Determine randomly whether there will be an encounter with a potion or a dragon
            Random randomEvent = new Random();
            int eventResult = randomEvent.Next(2); // 0 for potion, 1 for dragon
            switch (eventResult)
            {
                case 0:
                    Console.WriteLine("\nYou found a potion in the forest!");
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Collect potion");
                    Console.WriteLine("2. Continue exploring");

                    int potionChoice;
                    while (!int.TryParse(Console.ReadLine(), out potionChoice))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }

                    if (potionChoice == 1)
                    {
                        grimlok.CollectPotion(); // Grimlok collects the potion
                    }
                    else if (potionChoice == 2)
                    {
                        // Continue exploring (loop continues)
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    }
                    break;
                case 1:
                    Console.WriteLine("\nA dragon appeared before you!");
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Attack the dragon with sword and spear");
                    Console.WriteLine("2. Prepare a trap using natural elements in the surroundings and try to incapacitate the dragon.");
                    Console.WriteLine("3. Escape");

                    int battleChoice;
                    while (!int.TryParse(Console.ReadLine(), out battleChoice))
                    {
                        Console.WriteLine("Invalid input. Please try again.");
                    }

                    if (battleChoice == 1)
                    {
                        grimlok.AttackWithSwordAndSpear(dragon); // Grimlok attacks the dragon
                        dragon.Health -= 20; // Decrease dragon's health by 20 (Grimlok attacked)
                        Console.WriteLine($"Dragon's health: {dragon.Health}"); // Show dragon's current health after the attack
                        if (dragon.Health <= 0)
                        {
                            Console.WriteLine("Congratulations! You defeated the dragon and progressed successfully.");
                            Console.WriteLine("Grimlok left the forest in triumph.");
                            return; // End the game
                        }
                        else
                        {
                            Console.WriteLine("Dragon is attacking Grimlok with a fireball!");
                            dragon.AttackWithFireballs(grimlok); // Dragon attacks Grimlok with a fireball
                            grimlok.Health -= 20; // Decrease Grimlok's health by 20 (Dragon attacked)
                            Console.WriteLine($"Grimlok's health: {grimlok.Health}"); // Show Grimlok's current health after the attack
                            if (grimlok.Health <= 0)
                            {
                                Console.WriteLine("Grimlok was defeated by the dragon. Game over!");
                                Console.WriteLine("Unfortunately, Grimlok died.");
                                return; // End the game after the battle
                            }
                            else
                            {
                                Console.WriteLine("Grimlok dodged the fireball attack.");
                            }
                        }
                    }
                    else if (battleChoice == 2)
                    {
                        Console.WriteLine("Grimlok is preparing a trap using natural elements in the surroundings to incapacitate the dragon!");
                        dragon.Health -= 50; // Decrease dragon's health by 50 (Due to trap effect)
                        Console.WriteLine($"Dragon's health: {dragon.Health}"); // Show dragon's current health after the trap
                        if (dragon.Health <= 0)
                        {
                            Console.WriteLine("Congratulations! You incapacitated the dragon with a trap and progressed successfully.");
                            Console.WriteLine("Grimlok left the forest in triumph.");
                            return; // End the game
                        }
                        else
                        {
                            Console.WriteLine("Dragon is attacking Grimlok with a fireball!");
                            dragon.AttackWithFireballs(grimlok); // Dragon attacks Grimlok with a fireball
                            grimlok.Health -= 20; // Decrease Grimlok's health by 20 (Dragon attacked)
                            Console.WriteLine($"Grimlok's health: {grimlok.Health}"); // Show Grimlok's current health after the attack
                            if (grimlok.Health <= 0)
                            {
                                Console.WriteLine("Grimlok was defeated by the dragon. Game over!");
                                Console.WriteLine("Unfortunately, Grimlok died.");
                                return; // End the game after the battle
                            }
                            else
                            {
                                Console.WriteLine("Grimlok dodged the fireball attack.");
                            }
                        }
                    }
                    else if (battleChoice == 3)
                    {
                        Console.WriteLine("Grimlok is escaping from the dragon. Coward!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    }
                    break;
            }

            Console.WriteLine($"Grimlok's health: {grimlok.Health}"); // Show player's current health
            Console.WriteLine($"Dragon's health: {dragon.Health}"); // Show dragon's current health
            Console.WriteLine(); // Add a blank line

            Console.WriteLine("\nChoose an action:"); // Show options to the user
            Console.WriteLine("1. Collect potion");
            Console.WriteLine("2. Continue exploring");
            Console.WriteLine("3. Exit the game");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice)) // Ask for a valid input from the user
            {
                Console.WriteLine("Invalid input. Please try again."); // Display invalid input message
            }

            // Perform the selected action
            switch (choice)
            {
                case 1:
                    grimlok.CollectPotion(); // Option to collect potion
                    break;
                case 2:
                    // Continue exploring (loop continues)
                    break;
                case 3:
                    Console.WriteLine("Exiting the game.");
                    return; // Exit the game
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3."); // Display invalid choice message
                    break;
            }
        }

        Console.WriteLine("Game over!"); // Display game over message
    }
}