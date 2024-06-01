using System;
					
public class Program
{
	public static void Main()
	{
		string[] foods = {"1","2","3","4","5"}; //Initiallizes an "Empty" Array for user inputted foods
    
		int num = 0; //helps with going through the array in the replacement process
    
		int plcmnt = 1; //helps keep track of the food place for the user
    
		Console.WriteLine("Please Enter your top 5 favorite foods individually:");
		while (num != 5) //Loop will stop when num reaches the fifth slot in the array
		{
			Console.WriteLine("number" + plcmnt + ":");
			string usrinpt = Console.ReadLine(); //Allows user to input their favorite food individually
      
			foods[num] = usrinpt; //places user input into their rightful section in the array
      
			plcmnt++;// Increases placement number
      
			num++;// Increases array replacement number
		}
		while (num != 0) goes back through the whole array
		{
			num--;//decreases array placement number
      
			switch (num) //gives each item in the array a unique message
			{
				case 0:
					Console.WriteLine("I really enjoy eating " + foods[num] + " for my meeals!");
					break;
				case 1:
					Console.WriteLine("I will alway give myself an escuse to eat " + foods[num] + "!");
					break;
				case 2:
					Console.WriteLine("I will get my hands on a(n) " + foods[num] + " whenever I can!");
					break;
				case 3:
					Console.WriteLine("I can't get enough of " + foods[num] + "!");
					break;
				case 4:
					Console.WriteLine("I like eating " + foods[num] + "!");
					break;
			}
		}
	}
}
