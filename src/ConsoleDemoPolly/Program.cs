using System.Runtime.Serialization;
using Polly;

var retryPolicy = Policy.Handle<MyException>().Retry(3);

int executionCount = 0;
retryPolicy.Execute(() =>
{
    Console.WriteLine("\r\n===\r\nTry Polly in command line");
    if (executionCount < 3)
    {
        Console.WriteLine("Next I will throw an exception");
        executionCount++;
        throw new MyException($"This is the {executionCount} time(s) exception");
    }
    Console.WriteLine("Oh Yes! We Passed!!!");
});

public class MyException : Exception
{
    public MyException(string message) : base(message)
    {
    }
}