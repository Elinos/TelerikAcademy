using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

[TestClass]
public class UnitTestSayHello
{
    [TestMethod]
    public void SayHello()
    {
        string expected = "Hello, Pesho";
        string testString = "Pesho";
        StreamWriter streamWriter = new StreamWriter("test.txt");
        using (streamWriter)
        {
            Console.SetOut(streamWriter);
            Hello.SayHello(testString);
        }
        using (StreamReader streamReader = new StreamReader("test.txt"))
        {
            string actual = streamReader.ReadLine();
            Assert.AreEqual(expected, actual);
        }
    }
}

