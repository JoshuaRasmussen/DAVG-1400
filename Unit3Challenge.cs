using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Enter Temperature in Celsius:");
		int inpt1 = Convert.ToInt32(Console.ReadLine()); // Allows user to input a number related to tempature measurement in Celsius
		
		if (inpt1 > 40) // Checks if User input is over 40 degrees celsius
		{
			Console.WriteLine("How are you able to Survive? Are you superhuman?");
		}
		
		else if (inpt1 > 30) // Checks if User input is over 30 degrees celsius
		{
			Console.WriteLine("Make sure to stay hydrated and avoid long exposure from the sun!");
		}
		
		else if (inpt1 < 20) // Checks if User input is under 20 degrees celsius
		{
			Console.WriteLine("Make sure to wear a light jacket!");
		}
		
		else if (inpt1 < 10) // Checks if User input is under 10 degrees celsius
		{
			Console.WriteLine("Make sure to stay worm in this cold climate!");
		}
		
		else if (inpt1 < 0) // Checks if User input is under 0 degrees celsius
		{
			Console.WriteLine("If you don't have a heated coat, you may want to head towards a warmer region");
		}
		
		else // gives user a prompt when other two statement requirements are not met
		{
			Console.WriteLine("Enjoy the Weather!");
		}
		
		
		Console.WriteLine("Enter your favorite class subject:"); // allows user to enter their favorite subject
		string inpt3 = Console.ReadLine();
		
		
		Console.WriteLine("Enter the score for your subjects exam:"); // allows user to enter a test score
		int inpt2 = Convert.ToInt32(Console.ReadLine());
		
		if (inpt2 > 89) // checks if score is 90 or above
		{
			Console.WriteLine("You got an 'A' on your exam!");
		}
		
		else if (inpt2 > 79) // checks if score is 80 or above
		{
			Console.WriteLine("You got a 'B' on your exam!");
		}
		
		else if (inpt2 > 69) // checks if score is 70 or above
		{
			Console.WriteLine("You got a 'C' on your exam!");
		}
		
		else if (inpt2 > 59) // checks if score is 60 or above
		{
			Console.WriteLine("You got an 'E' on your exam!");
		}
		
		else if (inpt2 >= 0) // checks if score is 0 or above
		{
			Console.WriteLine("You got an 'F' on your exam! Try Again Next Time!");
		}
		
		else // tells user the impossibility of getting lower than a zero
		{
			Console.WriteLine("You must have done terribly to get a negative score.");
		}
		
		switch (inpt3) // shows the user a motivating message depending on the subject that the users wrote down
		{
			case "math":
				Console.WriteLine("Math may be a hard subject to grasp, but it will be quite a useful subject for measuring, accounting, and programming code!");
				break;
			case "english":
				Console.WriteLine("English helps with learning how to read and write! This subject can help lead into writing professional books and stories as well as helping with the ability to speak English!");
				break;
			case "history":
				Console.WriteLine("It is always fun to learn about the past! History Helps us learn about important moments that helped change lives for the better or for the worse!");
				break;
			case "science":
				Console.WriteLine("If you are interested in finding out about the way things in our world were created, Science is the subject for you!");
				break;
			case "social studies":
				Console.WriteLine("Social Studies is a great way to learn about different cultures around the world! you can learn about about the differences between cultures and how they act in their communities!");
				break;
			case "art":
				Console.WriteLine("Art is one of the best ways to show off your creativity! You can learn to draw, ink, paint, and print various different types of art");
				break;
			case "computer science":
				Console.WriteLine("interested in working with Computers? Then Computer Science is the field for you! you can learn how to program computers or create your own website!");
				break;
			case "physical education":
				Console.WriteLine("Interested in being fit and helping others with their fitness goals? Physical Education is the best subject to learn how to be physically fit with excersize and activities!");
				break;
			case "Biology":
				Console.WriteLine("Want to know more about Environments, animal relatives, and how the evolution works, then Biology is the best subject for you!");
				break;
			default: // if there is no code for the subject, this line of code will be used
				Console.WriteLine("If you enjoy the subject so far, I would advise looking further into the subject to find out more about it");
				break;
		}
		
	}
}
