using System;

namespace MyApplication
{
  class Program
  {
    static void Main(string[] args)
    {
      // addition practice
      int x = 153 + 60;
      int sum1 = x + 35;
      int sum2 = sum1 + x;
      Console.WriteLine(sum2); // writes the answer on terminal
      
      // subtraction practice
      int sub1 = sum2 - sum1;
      Console.WriteLine(sub1); // writes the answer on terminal
      
      // division practice
      int div1 = 150 / 25;
      Console.WriteLine(div1); // writes the answer on terminal
      
      // multiplication practice
      int mul1 = div1 * 100;
      Console.WriteLine(mul1); // writes the answer on terminal
      
      // modification practice
      int mod1 = mul1 % 7;
      Console.WriteLine(mod1); // writes the answer on terminal
      
      // incrementation practice
      mod1++;
      Console.WriteLine(mod1); // writes the answer on terminal
      
      // decrementation practice
      mul1--;
      Console.WriteLine(mul1); // writes the answer on terminal
      
      // float practice
      double decimals = 15.49;
      Console.WriteLine(decimals); // writes the answer on terminal
      
      // character practice
      char favoriteletter = 'J';
      Console.WriteLine(favoriteletter); // writes the answer on terminal
      
      // boolean practice
      bool answer = true;
      Console.WriteLine(answer); // writes the answer on terminal
      
      // string practice
      string text = "Hello World";
      Console.WriteLine(text); // writes the answer on terminal
     }
  }
}
