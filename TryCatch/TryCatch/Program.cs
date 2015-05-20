using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

public delegate string  HelloFunctionDelegate(string message);

public delegate string ShowNumberDelegation(int number);
class performance
{
    public int performClass(int a, int b)
    {
        return a + b;
    }
}
    class Program
    {
        public string AnotherMethod(int num)
        {
            return "The number is " + num;
        }

        public string PresentingNumber()
        {
            ShowNumberDelegation numberDelegation = new ShowNumberDelegation(AnotherMethod);
            string showNumber = numberDelegation(5);
            return showNumber;
        }
        public static string hello(string message)
        {
         
            return message;
        }
        public static void Main(string[] args)
        {
            HelloFunctionDelegate delegateMethod   = new HelloFunctionDelegate(hello);
            string message = delegateMethod("hello This is my first delegate method");
            Console.WriteLine(message);
            Program program = new Program();
            Console.WriteLine(program.PresentingNumber());
            Console.ReadLine();
        }
    }

