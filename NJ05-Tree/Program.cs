using System;
using System.Collections.Generic;

namespace NJ05_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> tree = new Node<string>("bootstrap", null);

            tree.AddChild("less");
            tree.AddChild("js");
            tree.AddChild("fonts");
            tree.AddChild("dist");
            tree[3].AddChild("css");
            tree[3][0].AddChild("bootstrap.css");
            tree[3][0].AddChild("bootstrap.min.css");
            tree[3][0].AddChild("bootstrap-theme.css");
            tree[3].AddChild("js");
            tree[3][1].AddChild("bootstrap.js");


            Console.WriteLine(tree.ToString());
        }
    }
}
