using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
 
    class Program
    {
        static void Main(string[] args)
        {
            var head = new Node("1");
            head.AddNext(new Node("2"));
            head.AddNext(new Node("3"));
            var node4 = new Node("4");
            head.AddNext(node4);
            head.AddNext(new Node("5"));

            head.DisplayAll();
            node4.Remove();

            Console.WriteLine("after remove");
            head.DisplayAll();

            Console.WriteLine();

            head.Next.Next.DisplayBack();


            Console.WriteLine();
            Console.WriteLine("count: " + head.Count());
        }
    }

    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(string _name)
        {
            Name = _name;
        }

        public void AddNext(Node newNode)
        {
            var lastNode = this.ToEnd();

            newNode.Prev = lastNode;
            lastNode.Next = newNode;
        }

        public void Remove()
        {
            Node prevNode = this.Prev;
            Node nextNode = this.Next;

            prevNode.Next = nextNode;
            nextNode.Prev = prevNode;
        }
       
        public Node ToEnd()
        {
            if (this.Next == null)
                return this;

            return this.Next.ToEnd();
        }

        public Node ToFront()
        {
            if (this.Prev == null)
                return this;

            return this.Prev.ToFront();
        }

        public int Count()
        {
            var curr = this.ToFront();
            var counter = 1;

            while(curr.Next != null)
            {
                counter++;
                curr = curr.Next;
            }

            return counter++;
        }

        public void DisplayAll()
        {
            var curr = this.ToFront();

            Console.WriteLine($"{curr.Name}");

            while (curr.Next != null)
            {
                curr = curr.Next;
                Console.WriteLine($"{curr.Name}");
            }
        }

        public void DisplayBack()
        {
            Console.Write($"{this.Name}");

            if (this.Prev != null)
            {
                Console.Write("->");
                this.Prev.DisplayBack();
            }
        }
    }
}