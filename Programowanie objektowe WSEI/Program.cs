using System;

namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = Person.OfName("Adam");
            Console.WriteLine(person);
            Money money = Money.Of(12, Currency.PLN) ?? Money.Of(0, Currency.PLN);
            Console.WriteLine(money.Value + " " + money.Currency);
            Money result = 0.22m * money;
            Console.WriteLine(result.Value);
            result = (money + Money.Of(5, money.Currency)) * 0.5m;
            Console.WriteLine(result.Value);
            if (money > result)
            {
                Console.WriteLine("money większe");
            }
            else
            {
                Console.WriteLine("result większe");
            }
            if (money == Money.Of(12, Currency.PLN))
            {
                Console.WriteLine("Równe");
            } else
            {
                Console.WriteLine("Różne");
            }
            int a = 10;
            long b = 10L;
            b = a; //niejawne
            a = (int)b; // jawne
            decimal price = money;
            double cost = (double)money;
            float c = (float)money;
            Console.WriteLine("MONEY");
            Console.WriteLine(money);
            Console.WriteLine(money.ToString());
            Console.WriteLine(a == b);
            Console.WriteLine(money.Equals(Money.Of(13, Currency.PLN)));

            IEquatable<Money> ie = money;


            Money[] prices =
            {
                Money.Of(5, Currency.PLN),
                Money.Of(6, Currency.EUR),
                Money.Of(57, Currency.USD),
                Money.Of(58, Currency.PLN),
                Money.Of(59, Currency.USD),
                Money.Of(50, Currency.EUR)
            };
            Console.WriteLine("sort");
            Array.Sort(prices);
            foreach(var p in prices)
            {
                Console.WriteLine(p.ToString());
            }
            Student[] persons =
            {
                new Student("Kowalska", "Anna", 4),
                 new Student("Iksinski", "Jan", 3),
                  new Student("Iksinski", "Marek", 2),
                   new Student("Iksinski", "Marek", 3)
            };
            Console.WriteLine("sort student");
            Array.Sort(persons);
            foreach (var p in persons)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }

    public class Person
    {
        private string firstName;

        public Person(string _firstName)
        {
            this.FirstName = _firstName;
        }

        public static Person OfName(string name)
        {
            if (name != null && name.Length >= 2)
            {
                return new Person(name);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value != null && value.Length >= 2)
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Imię zbyt krótkie");
                }
            }
        }

        public override string ToString()
        {
            return $"FirstName: {FirstName}";
        }
    }

    public enum Currency
    {
        PLN = 2,
        USD = 3,
        EUR = 1
    }


    public class Money : IEquatable<Money>, IComparable<Money>
    {
        private readonly decimal _value;
        private readonly Currency _currency;
        private Money(decimal value, Currency currency)
        {
            _value = value;
            _currency = currency;
        }

        public static Money operator *(Money money, decimal factor)
        {
            return Money.Of(money.Value * factor, money.Currency);
        }

        public static Money operator *(decimal factor, Money money)
        {
            return Money.Of(money.Value * factor, money.Currency);
        }

        public static bool operator <(Money a, Money b)
        {
            return a.Value < b.Value;
        }

        public static bool operator >(Money a, Money b)
        {
            return a.Value > b.Value;
        }

        public static Money operator +(Money a, Money b)
        {
            IsSameCurrencies(a, b);
            return Money.Of(a.Value + b.Value, a.Currency);
        }

        public static implicit operator decimal(Money money) //implicit niejawny
        {
            return money.Value;
        }
        public static explicit operator double(Money money) //explicit jawny
        {
            return (double)money.Value;
        }
        private static void IsSameCurrencies(Money a, Money b)
        {
            if (a.Currency != b.Currency)
            {
                throw new ArgumentException("Different currencies!");
            }
        }

        public decimal Value
        {
            get { return _value; }
        }

        public Currency Currency
        {
            get
            {
                return _currency;
            }
        }

        public static Money? Of(decimal value, Currency currency)
        {
            return value < 0 ? null : new Money(value, currency);
        }

        public static Money? OfName(decimal value, Currency currency)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return new Money(value, currency);
            }
        }

        public override string ToString()
        {
            return $"Value: {_value} {_currency}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money other)
        {
            return other != null &&
                   _value == other._value &&
                   _currency == other._currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_value, _currency);
        }

        public int CompareTo(Money other)
        {
            int curResult = -_currency.CompareTo(other.Currency);
            if (curResult == 0)
            {
                return -_value.CompareTo(other.Value);
            } else
            {
                return curResult;
            }
        }
    }



    public class Student : IComparable<Student>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public decimal Average { get; set; }

        public Student(string surname, string name, decimal average)
        {
            Surname = surname;
            Name = name;
            Average = average;
        }

        public int CompareTo(Student other)
        {
            var surnameResult = Surname.CompareTo(other.Surname);
            if (surnameResult != 0) return surnameResult;
            var nameResult = Name.CompareTo(other.Name);
            if (nameResult != 0) return nameResult;
            return Average.CompareTo(other.Average);
        }
        public override string ToString()
        {
            return $"Student: {Surname} {Name} {Average}";
        }
    }
}

// Do zrobienia cw 10, metody rozszerzajace, stan