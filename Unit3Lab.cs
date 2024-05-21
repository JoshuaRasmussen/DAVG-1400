using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter Temperature in Celsius:");
		int inpt1 = Convert.ToInt32(Console.ReadLine()); // Allows user to input a number related to tempature measurement in Celsius
		
		if (inpt1 > 30) // Checks if User input is over 30 degrees celsius
		{
			Console.WriteLine("Make sure to stay hydrated and avoid long exposure from the sun!");
		}
		else if (inpt1 < 15) // Checks if User input is under 15 degrees celsius
		{
			Console.WriteLine("Make sure to stay worm in this cold climate!");
		}
		
		else // gives user a prompt when other two statement requirements are not met
		{
			Console.WriteLine("Enjoy the Weather!");
		}
		
		Console.WriteLine("Enter your grade number:"); // allows user to enter a test score
		int inpt2 = Convert.ToInt32(Console.ReadLine());
		
		if (inpt2 > 89) // checks if score is 90 or above
		{
			Console.WriteLine("You got an 'A'!");
		}
		
		else if (inpt2 > 79) // checks if score is 80 or above
		{
			Console.WriteLine("You got a 'B'!");
		}
		
		else if (inpt2 > 69) // checks if score is 70 or above
		{
			Console.WriteLine("You got a 'C'!");
		}
		
		else if (inpt2 > 59) // checks if score is 60 or above
		{
			Console.WriteLine("You got an 'E'!");
		}
		
		else if (inpt2 >= 0) // checks if score is 0 or above
		{
			Console.WriteLine("You got an 'F'! Try Again Next Time!");
		}
		
		else // tells user the impossibility of getting lower than a zero
		{
			Console.WriteLine("You must have done terribly to get a negative score.");
		}
	}
}
