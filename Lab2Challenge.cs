using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("please enter a number: ");
		int number = Convert.ToInt32(Console.ReadLine()); // allows user to input a starting number
		
		double deci = 32.14; // makes a floating number
		
		bool answer = true; // makes a boolean variable
		
		Console.WriteLine("Please enter a sentence or phrase:");
		string text = Console.ReadLine(); // allows user to input a string of their very own
		
		Console.WriteLine("Please enter a number to add to your original integer:");
		int addition = Convert.ToInt32(Console.ReadLine()); // allows user to input an addition variable
		
		Console.WriteLine("Please enter a number to subtract from your original integer:");
		int subtraction = Convert.ToInt32(Console.ReadLine()); // allows user to input an subtraction variable
		
		Console.WriteLine("Please enter a number to multiply your original integer:");
		int Multiplication = Convert.ToInt32(Console.ReadLine()); // allows user to input a multiplication variable
		
		Console.WriteLine("Please enter a number to divide your original integer:");
		int Division = Convert.ToInt32(Console.ReadLine()); // allows user to input a division variable
		
		int sum = number + addition; // adds the first number and addition variable
		
		int div = number / Division; // divides the first number and Division variable
		
		int sub = number - subtraction; // subtracts the first number and subtraction variable
		
		int mul = number * Multiplication; // multiplies the first number and Multiplication variable
		
		// prints all of the variables in this line of code
		Console.WriteLine(number);
		Console.WriteLine(deci);
		Console.WriteLine(answer);
		Console.WriteLine(text);
		Console.WriteLine(sum);
		Console.WriteLine(sub);
		Console.WriteLine(div);
		Console.WriteLine(mul);
	}
}
