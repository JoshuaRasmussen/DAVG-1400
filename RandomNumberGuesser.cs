using System;
					
public class Program
{
	public static void Main()
	{
		Random rnd = new Random(); //Initializes the random library
    
		int usrinpt = -1; //defaults to a number outside of the range 1 through t10 so the loop can start
    
		int num = rnd.Next(1,10); //Creates a random number between 1 and 10
    
		int attempts = 0; //Keeps track of user attempts
    
		while (usrinpt != num) //The game goes through a loop until the user correctly guesses the number
		{
			Console.WriteLine("provide a number between 1 and 10:");
			usrinpt = Convert.ToInt32(Console.ReadLine()); //allows the user to change usrinpt
      
			if (usrinpt < 1) //Is used to prevent use of any negative numbers alongside 0
			{
				Console.WriteLine("No negative numbers or 0!");
			}
      
			else if (usrinpt > 10) //Is used to prevent use of numbers bigger than 10
			{
				Console.WriteLine("No numbers bigger than 10!");
			}
      
			else if (usrinpt > num) //Tells user to increase the number input
			{
				Console.WriteLine("the number is smaller than " + usrinpt + "!");
			}
      
			else if (usrinpt < num) //Tells user to decrease the number input
			{
				Console.WriteLine("The number is bigger than " + usrinpt + "!");
			}
      
			else //Congrats the user when user correctly guesses the number that has been randomly generated
			{
				Console.WriteLine("Congrats!!! you guessed the number! It took you " + attempts + " Tries!");
			}
      
			attempts++; //Increments attempts whenever the user inputs a number
		}
	}
}
