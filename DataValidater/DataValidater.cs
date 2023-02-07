using Lager.UserCommunications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lager.DataValidater
{
    public class DataValidater : IDataValidater
    {
        private readonly string _defaultMessage = "Invalid data, enter once again...";

        public bool CheckLength(int length, string? phrase)
        {
            var checkLength = false;
            if (phrase != null)
            {
                if (phrase.Length < length) checkLength = true;
            }
            return checkLength;
        }
        public bool CheckLengthAndNumber(int length, string? userInput)
        {
            bool check;
            var checkNumber = true;
            var checkLength = false;
            if (userInput != null)
            {
                if (userInput.Length < length)
                {
                    checkLength = true;
                    foreach(var item in userInput)
                    {
                        if(char.IsDigit(item)) checkNumber = false; 
                    }
                }
            }
            if (checkLength && checkNumber) check = true;
            else check = false;
            return check;
        }

        public bool CheckEmail(string? phrase)
        {
            var check = false;

                if (phrase != null)
                {
                if (phrase.Contains("@")) check = true;
                }
            return check;
        }

        public bool CheckNumber(int length, string? phrase)
        {
            var check = false;
                if (phrase != null)
                {
                    if (phrase.Length < length)
                    {
                        var checkInt = int.TryParse(phrase, out _);
                        var checkFloat = float.TryParse(phrase, out _);
                        var checkDouble = double.TryParse(phrase, out _);

                        if (checkInt || checkFloat || checkDouble) check = true;
                    }
                }
            return check;
        }

        public int CheckNumberOutInt(string? phrase)
        {
            var userInputInt = 0;
                if (phrase != null)
                {
                        var checkInt = int.TryParse(phrase, out userInputInt);
                }
            return userInputInt;
        }
        public double CheckNumberOutDouble(string? phrase)
        {
            var phraseDouble = 0.00;
                if (phrase != null)
                {
                        var checkDouble = Double.TryParse(phrase, out phraseDouble);
                }
            return phraseDouble;
        }
        public bool CheckDate(string? phrase)
        {
            var check = false;
                if (phrase != null)
                {
                    if (DateTime.TryParse(phrase, out _)) check = true;
                }
            return check;
        }

        public DateTime CheckDateOut (string? phrase)
        {
            DateTime newDate = new DateTime(2000, 0, 0, 0, 0, 0);
            if (phrase != null)
            {
                var check = DateTime.TryParse(phrase, out newDate);
            }
            return newDate;
        }

        public void ErrorMessage(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }
        public void ErrorMessage()
        {
            Console.Clear();
            Console.WriteLine(_defaultMessage);
            Console.WriteLine("Press any key to continue... ");
            Console.ReadKey();
        }

        public float CheckNumberOutFloat(string? phrase)
        {
            float phraseFloat = 0;
            if (phrase != null)
            {
                var checkFloat = float.TryParse(phrase, out phraseFloat);
            }
            return phraseFloat;
        }

        
    }
}
