using System;

namespace Lab_3
{
    class Stack<T>
    {
        private T[] _arr = new T[100];
        private int _last = -1;

        public void Push(T item)
        {
            //warunki testowe _last
            _arr[++_last] = item;
        }

        public T Pop()
        {
            //warunki testujące _last
            return _arr[_last--];
        }
    }
    class Reward
    {
        public Reward GiveTo<T>(T target)
        {
            Console.WriteLine($"Reward goes to {target}");
            return this;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stringStack = new Stack<string>();
            stringStack.Push("abcd");
            Reward reward = new Reward();
            // Loading many data
            reward.GiveTo<string>("director");
            reward.GiveTo(12m);
            reward.GiveTo((object)"adst");
            // stringStack.Push(124); nie można dodawać teraz liczb CHYBA, ŻE TO OBJECT
            Stack<Object> objectStack = new Stack<object>();
            objectStack.Push(123);
            objectStack.Push("hejka");
            string v = stringStack.Pop();
            object v1 = objectStack.Pop();
            ValueTuple<string, decimal, int> product = ValueTuple.Create("laptop", 1200m, 2);
            Console.WriteLine(product.Item1);
            Console.WriteLine(product);
            (string, decimal, int) tuple = ("laptop", 1200m, 2);
            Console.WriteLine(product == tuple); //krotki
            (string name, decimal price, int quantity) wpis = tuple;
            wpis = (name: "laptop1",
                price: 1200m, quantity: 2);
            Console.WriteLine(tuple);
        }
    }
}
