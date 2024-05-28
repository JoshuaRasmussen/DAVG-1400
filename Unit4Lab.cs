using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Please input a positive number: ");
		int inpt = Convert.ToInt32(Console.ReadLine()); // Allows User to input a positive number of their choice
		
		int strt = 1; // helps out with creating the pyramid rows
		
		if (inpt <= 0) // will not allow numbers that are negative or zero to be inputted
		{
			Console.WriteLine("Invalid value! Please enter a number that isn't zero or a negative!");
		}
		
		else // if inpt is the value 1 or higher, the program will provide a pyramid based on the number
		{
			while (inpt > 0) // loop stops if user inputted number is lower than 1
			{
				string num = Convert.ToString(strt); // turns row number into a string
				
				string str = ""; // allows for a string row to be created
				
				int i = strt; // helps with the row creating loop
				
				while (i > 0) // creates a row string with the help of strt
				{
					str = str + num;
					
					i--; // decreases i so that the loop isn't infinite
				}
				Console.WriteLine(str); // prints the row string
				
				strt++; // increases the row number for the pyramid
				
				inpt--; // decreases the inputted number so the loop isn't infinite

			}	
		}
	}
}
