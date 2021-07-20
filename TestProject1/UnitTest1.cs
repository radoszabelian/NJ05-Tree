using Microsoft.VisualStudio.TestTools.UnitTesting;
using NJ05_Tree;
using System;
using System.Collections.Generic;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIterationOfChildren()
        {
            List<string> l = new List<string>() { "nyuszi" };
            Node<string> tree = new Node<string>("root", l);

            var index = 0;
            foreach (var node in tree)
            {
                Assert.AreEqual("nyuszi", node);
                index++;
            }
            Assert.AreEqual(1, index);
        }

        [TestMethod]
        public void TestIndexOperator()
        {
            List<string> l = new List<string>() { "nyuszi" };
            Node<string> tree = new Node<string>("root", l);

            var result = tree[0].Value;

            Assert.AreEqual("nyuszi", result);
        }

        [TestMethod]
        public void TestAddChildAsString()
        {
            List<string> l = new List<string>() { "nyuszi" };
            Node<string> tree = new Node<string>("root", l);

            tree.AddChild("beka");

            Assert.AreEqual("beka", tree[1].Value);
        }

        [TestMethod]
        public void TestAddChildAsNode()
        {
            List<string> l = new List<string>() { "nyuszi" };
            Node<string> tree = new Node<string>("root", l);

            tree.AddChild(new Node<string>("beka"));

            Assert.AreEqual("beka", tree[1].Value);
            Assert.AreEqual(2, tree.NumberOfChildren);
        }

        [TestMethod]
        public void TestRemoveChild()
        {
            List<string> l = new List<string>() { "nyuszi" };
            Node<string> tree = new Node<string>("root", l);

            tree.RemoveChild("nyuszi");

            Assert.AreEqual(0, tree.NumberOfChildren);
        }

        [TestMethod]
        public void TestContains()
        {
            List<string> l = new List<string>() { "nyuszi" };
            Node<string> tree = new Node<string>("root", l);

            tree.AddChild(new Node<string>("kolbasz"));

            var result1 = tree.Contains("kolbasz");
            var result2 = tree.Contains("root");

            Assert.AreEqual(true, result1);
            Assert.AreEqual(true, result2);
        }

        [TestMethod]
        public void TestContainsPredicate()
        {
            Func<string, bool> f1 = (string item) => item == "kolbasz";
            Func<string, bool> f2 = (string item) => item == "nyuszi";

            List<string> l = new List<string>() { "nyuszi" };
            Node<string> tree = new Node<string>("root", l);

            tree.AddChild(new Node<string>("kolbasz"));

            var result1 = tree.Contains(f1);
            var result2 = tree.Contains(f2);

            Assert.AreEqual(true, result1);
            Assert.AreEqual(true, result2);
        }
    }
}
