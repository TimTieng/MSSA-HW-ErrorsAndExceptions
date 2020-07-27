/*
Class: ISTA 220 - Programming Fundamentals in C#
Student: Tim Tieng
Instructor: Christine Lee
Date: 24JUL2020
Description: MSSA HW - Intro to Error/Exception Handling and Variable Overflow; Building off HW1 Math formula revisions.
Revised By: Tim Tieng
Revised On: 26JUL2020
Revisions Made:
1. Revised and used Code structure from HW1- MathFormulaRevisions as base code for methods (24JUL)
2. Added Main Menu Feature (24JUL)
3. Removed  and replaced duplicate code - fixed this by creating a NegativeValueErrorMessage() to print Invalid input for negative value input (26JUL)
4. Removed and replaced duplicate code - fixed this by creating a FinallyRedirectMessage() for all FINALLY Blocks (26JUL)
*/
using System;

namespace HWErrorsExceptionsTimTieng
{
    class Program
    {
        static void Main(string[] args)
        {
            //Break Down each HW task as its own method; use Main Menu to call those methods
            Console.Clear();
            bool DisplayMenu = true;
            while (DisplayMenu == true)
            {
                DisplayMenu = MainMenu();
            }
            MainMenu();
        }
        private static bool MainMenu()
        {
            //MainMenu Feature - 4 Separate HW tasks, 5 options to choose
            Console.WriteLine("1. Option 1 - Calculate the circumference of a circle!");
            Console.WriteLine("2. Option 2 - Calculate the area of a circle!");
            Console.WriteLine("3. Option 3 - Calculate the area of a triangle!");
            Console.WriteLine("4. Option 4 - Quadratic Equation Program!");
            Console.WriteLine("5. Option 5 - Exit Program");
            string result = Console.ReadLine(); //Capture user input and use for If-Else If statements 

            if (result == "1")
            {
                CircumferenceCircle();
                return true;
            }
            else if (result == "2")
            {
                AreaCircle();
                return true;
            }
            else if (result == "3")
            {
                AreaTriangle();
                return true;
            }
            else if (result == "4")
            {
                QuadraticEquation();
                return true;
            }
            else if (result == "5")
            {
                Console.Clear();
                return false; 
            }
            else
            {
                return false;
            }
        }
        private static void CircumferenceCircle()
        {
            Console.Clear();//When Option is selected, this clears the Main Menu screen from Console
            double circleCircumference;//Declare variables outside Try-Catch; Did not work if if declared within TRY
            double userRadius;
            try//check for variable overflow - determine if userRadius value exceed double limit
            {
                userRadius = checked(double.MaxValue + 1);
            }
            catch (System.OverflowException sofe)
            {
                Console.WriteLine($"Error due to: {sofe.Message}");
            }
            try
            {
                Console.WriteLine("This program takes user input to calculate the circumference of a circle");
                Console.Write("Please enter a value for your radius: ");
                userRadius = Convert.ToDouble(Console.ReadLine());
                //Intentional Line Break
                if (userRadius < 0)
                {
                    NegativeValueErrorMessage();
                    Console.Write("Please enter a value for your radius: ");
                    userRadius = Convert.ToDouble(Console.ReadLine()); //having this here ensures the invalid response is not used for calculations
                }
                //Calculate Circumference
                circleCircumference = 2 * Math.PI * userRadius;
                Console.WriteLine($"The circumference of a circle with a radius of {userRadius} is: {circleCircumference}.");
                Console.ReadLine();
                Console.Clear();//Used to ensure main menu does not print when displaying method results
            }
            catch (FormatException fe)//Format exception if user inputs a char vs numerical value
            {
                Console.WriteLine($"Invalid Input due to: {fe.Message}");
                Console.ReadLine();
                Console.Clear();
            }
            finally//Code block executes regardless if an exception is "thrown". 
            {
                FinallyRedirectMessage();
            }
        }
        private static void AreaCircle()
        {
            Console.Clear();
            double circleArea;
            double userRadius;
            try//Check for variable overflow
            {
                userRadius = checked(double.MaxValue + 1);
            }
            catch (System.OverflowException sofe)
            {
                Console.WriteLine($"Error due to: {sofe.Message}");
            }
            try
            {
                Console.WriteLine("This program takes user input to calculate the area of a circle!");
                Console.Write("Please enter the value for your radius: ");
                userRadius = Convert.ToDouble(Console.ReadLine());
                //Intentional Line Break
                if (userRadius < 0)
                {
                    NegativeValueErrorMessage();
                    Console.Write("Please enter a value for your radius: ");
                    userRadius = Convert.ToDouble(Console.ReadLine());
                }
                //Calculate Area
                circleArea = Math.PI * Math.Pow(userRadius, 2);
                Console.WriteLine($"The area of a circle with a radius of {userRadius} is: {circleArea}");
                Console.ReadLine();
                Console.Clear();
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Invalid Input due to: {fe.Message}");
                Console.ReadLine();
                Console.Clear();
            }
            finally
            {
                FinallyRedirectMessage();
            }
        }
        private static void AreaTriangle()//Use Heron's Formula
        {
            Console.Clear();
            double triangleArea, length1, length2, length3,
                   heronsPValue, parenthesis1,parenthesis2,
                   parenthesis3, radicandValue;//A lot of variables because I want to break down components of the formula
            try
            {
                Console.WriteLine("This program takes user input to calcuate a Triangle's area using Heron's Formula");
                Console.Write("Enter the value of length 1: ");
                length1 = Convert.ToDouble(Console.ReadLine());
                if (length1 < 0)
                {
                    NegativeValueErrorMessage();
                    Console.Write("Enter the value of length 1: ");
                    length1 = Convert.ToDouble(Console.ReadLine());
                }
                Console.Write("Enter the value of length 2: ");
                length2 = Convert.ToDouble(Console.ReadLine());
                if (length2 < 0)
                {
                    NegativeValueErrorMessage();
                    Console.Write("Enter the value of length 2: ");
                    length2 = Convert.ToDouble(Console.ReadLine());
                }
                Console.Write("Enter the value of length 3: ");
                length3 = Convert.ToDouble(Console.ReadLine());
                if (length3 < 0)
                {
                    NegativeValueErrorMessage();
                    Console.Write("Enter the value of length 3: ");
                    length3 = Convert.ToDouble(Console.ReadLine());
                }
                //Calculate Heron's P Value to be used as variable later on
                heronsPValue = (length1 + length2 + length3) / 2;
                //Use HeronsPValue to calculate values in Parenthesis
                parenthesis1 = (heronsPValue - length1);
                parenthesis2 = (heronsPValue - length2);
                parenthesis3 = (heronsPValue - length3);
                //Combine Parenthesis values to create the Radicandvalue for simplifying calculations
                radicandValue = (heronsPValue * parenthesis1 * parenthesis2 * parenthesis3);
                //Calculate Area using Math.Sqrt Method using radicandValue as argument
                triangleArea = Math.Sqrt(radicandValue);
                Console.WriteLine($"The area of the triangle using Heron's Formula is: {triangleArea}");
                Console.ReadLine();
                Console.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Invalid Input due to: {e.Message}");
                Console.ReadLine();
                Console.Clear();
            }
            finally
            {
                FinallyRedirectMessage();
            }
        }
        private static void QuadraticEquation()
        {
            Console.Clear();
            double aValue, bValue, cValue, deltaRoot, x1, x2;
            try
            {
                Console.WriteLine("This program simplifies the Quadratic Equation based of user input");
                Console.Write("Please enter the value for 'A'");
                aValue = Convert.ToDouble(Console.ReadLine());

                Console.Write("Please enter the value for 'B'");
                bValue = Convert.ToDouble(Console.ReadLine());

                Console.Write("Please enter the value for 'C'");
                cValue = Convert.ToDouble(Console.ReadLine());

                deltaRoot = Math.Sqrt(bValue * bValue - (4 * aValue * cValue));

                if (deltaRoot >=0)
                {
                    x1 = (-bValue + deltaRoot) / (2 * aValue);
                    x2 = (-bValue - deltaRoot) / (2 * aValue);
                    Console.WriteLine($"The possible root values are: x1 = {x1} and x2 = {x2}");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("There are no roots");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (FormatException fe)//Determine if program or user is inputing incorrect values
            {
                Console.WriteLine($"Invalid Input due to: {fe.Message}");
                Console.ReadLine();
                Console.Clear();
            }
            catch (DivideByZeroException dbz)//Determine if Program or user is attempting to divide by zero
            {
                Console.WriteLine($"Invalid Input due to: {dbz.Message}");
                Console.ReadLine();
                Console.Clear();
            }
            finally
            {
                FinallyRedirectMessage();
            }
        }
        private static void NegativeValueErrorMessage()
        {
            Console.WriteLine("Invalid Response: Negative Values not permitted!");
        }
        private static void FinallyRedirectMessage()
        {
            Console.WriteLine("You will be redirected to the main menu");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
/*
 References Used:

    1. https://www.mathsisfun.com/quadratic-equation-solver.html was used to check if values returned in QuadraticFormula were correct.
    2. https://docs.microsoft.com/en-us/dotnet/api/system.exception?view=netcore-3.1 was used to reference Exception Class possibilities
    3. https://www.tutorialsteacher.com/csharp/csharp-exception-handling was used to supplement exception handling lessons in book.
    4. https://kencenerelli.wordpress.com/2015/08/04/using-the-checked-and-unchecked-keywords-in-c-to-perform-overflow-checking/
       used to determine how to include Checked/Unchecked keywords to address variable overflow issues in CircumferenceCircle and AreaCircle
       methods.
    5. https://www.johndcook.com/blog/2010/06/08/c-math-gotchas/ Used to determine what the max value for a Double datatype
 */
