using System;
using System.Linq;
using System.Threading.Tasks;

namespace Zadatak6
{
    public class Factorials
    {
        public static async void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return await FactorialDigitSum(n);
        }

        public static async Task<int> FactorialDigitSum(int number)
        {
            return await Task.Run(() => Factorial(number).ToString().Sum(c => c - '0'));
        }

        static int Factorial(int number)
        {
            int result = number;
            for (int i = 1; i < number; i++)
                result = result * i;
            return result;
        }
    }
}