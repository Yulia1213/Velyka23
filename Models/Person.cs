using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Velyka23.Exeptions;

namespace Velyka23.Models
{
    class Person
    {
        private string _name;
        private string _surname;
        private string _mail;
        private DateTime _birthday;
        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;

        public Person(string name, string surname, string mail)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
        }

        public Person(string name, string surname, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
        }

        public Person(string name, string surname, string mail, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Mail = mail;
            Birthday = birthday;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }

        public string Mail
        {
            get => _mail;
            set
            {
                if (NotValid(value))
                    throw new MailExeption("Not valid email ");
                else
                    _mail = value;

            }
        }

        private bool NotValid(string mail)
        {
           
            string[] twoStrings = mail.Split('@');
            if (twoStrings.Length != 2) return true;
            string[] twoStrings2 = twoStrings[1].Split('.');
            if (twoStrings2.Length != 2) return true;
            return false;

        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                int age = Age(value);
               if (age>135)
                   throw  new AgeExeption("age > 135", age);
               else if(age < 0)
                   throw new BirthdayExeption("Birthday in the future", age);
                _birthday = value;
            }
        }
        public bool IsAdult { get { return isAdult(); }}
        public string SunSign { get { return sunSign(); }  }
        public string ChineseSign { get { return chineseSign(); } }
        public bool IsBirthday { get { return isBirthday(); }  }
        private int Age(DateTime Birthday)
        {

            if (DateTime.Now.Month < Birthday.Month
                || DateTime.Now.Month == Birthday.Month && DateTime.Now.Day < Birthday.Day)
            {
                return DateTime.Now.Year - Birthday.Year - 1;
            }

            return DateTime.Now.Year - Birthday.Year;
        }

        private bool isAdult()
        {
            if (Age(Birthday) < 18) return false;
            return true;
        }

        private string sunSign()
        {
            int day = Birthday.Day;
            int month = Birthday.Month;
            string sign = "some error";

            if (month == 12)
            {

                if (day < 22)
                    sign = "Sagittarius";
                else
                    sign = "capricorn";
            }

            else if (month == 1)
            {
                if (day < 20)
                    sign = "Capricorn";
                else
                    sign = "aquarius";
            }

            else if (month == 2)
            {
                if (day < 19)
                    sign = "Aquarius";
                else
                    sign = "pisces";
            }

            else if (month == 3)
            {
                if (day < 21)
                    sign = "Pisces";
                else
                    sign = "aries";
            }
            else if (month == 4)
            {
                if (day < 20)
                    sign = "Aries";
                else
                    sign = "taurus";
            }

            else if (month == 5)
            {
                if (day < 21)
                    sign = "Taurus";
                else
                    sign = "gemini";
            }

            else if (month == 6)
            {
                if (day < 21)
                    sign = "Gemini";
                else
                    sign = "cancer";
            }

            else if (month == 7)
            {
                if (day < 23)
                    sign = "Cancer";
                else
                    sign = "leo";
            }

            else if (month == 8)
            {
                if (day < 23)
                    sign = "Leo";
                else
                    sign = "virgo";
            }

            else if (month == 9)
            {
                if (day < 23)
                    sign = "Virgo";
                else
                    sign = "libra";
            }

            else if (month == 10)
            {
                if (day < 23)
                    sign = "Libra";
                else
                    sign = "scorpio";
            }

            else if (month == 11)
            {
                if (day < 22)
                    sign = "scorpio";
                else
                    sign = "sagittarius";
            }

            return sign;
        }

        private String chineseSign()
        {


            int sign = Birthday.Year % 12;

            switch (sign)
            {
                case 0:
                    return "Monkey year";
                case 1:
                    return "Cock year";
                case 2:
                    return "Dog year";
                case 3:
                    return "Pig year";
                case 4:
                    return "Rat year";
                case 5:
                    return "Bull year";
                case 6:
                    return "Tiger year";
                case 7:
                    return "Rabbit year";
                case 8:
                    return "Dragon year";
                case 9:
                    return "Snake year";
                case 10:
                    return "Horse year";
                case 11:
                    return "Goat year";

            }
            return "some error";


        }

        private bool isBirthday()
        {
            return DateTime.Now.Year == Birthday.Year && DateTime.Now.Month == Birthday.Month &&
                   DateTime.Now.Day == Birthday.Day;
        }
    }
}

