
using System;
using System.Threading;
using System.Data;

public class BoundedBuffer
{
    // Complete this class
    private int ReadData;
    public BoundedBuffer(){}

}

class MyProducer
{
    private Random rand = new Random(1);
    private BoundedBuffer boundedBuffer;
    private int totalIters;

    public MyProducer(BoundedBuffer boundedBuffer, int iterations)
    {
        this.boundedBuffer = boundedBuffer;
        totalIters = iterations;
    }

    public Thread CreateProducerThread()
    {
        return new Thread(new ThreadStart(this.calculate));
    }
    private void calculate()
    {
        int iters = 0;
        do
        {
            iters += 1;
            Thread.Sleep(rand.Next(2000));
            //boundedBuffer.WriteData(iters * 4);
            iters = iters * 4;
        } while (iters < totalIters);
    }
}

class MyConsumer
{
    private Random rand = new Random(2);
    private BoundedBuffer boundedBuffer;
    private int totalIters;


    public MyConsumer(BoundedBuffer boundedBuffer, int iterations)
    {
        this.boundedBuffer = boundedBuffer;
        totalIters = iterations;
    }

    public Thread CreateConsumerThread()
    {
        return new Thread(new ThreadStart(this.printValues));
    }

    private void printValues()
    {
        int iters = 0;
        double pi=1;
        do
        {
            Thread.Sleep(rand.Next(2000));
            //boundedBuffer.ReadData(out pi);
            pi += pi;
            System.Console.WriteLine("Value {0} is: {1}", iters, pi.ToString());
            iters++;
        } while (iters < totalIters);
        System.Console.WriteLine("Done");
    }
}

class MainClass
{
    static void Main(string[] args)
    {
        BoundedBuffer boundedBuffer = new BoundedBuffer();

        MyProducer prod = new MyProducer(boundedBuffer, 20);
        Thread producerThread = prod.CreateProducerThread();

        MyConsumer cons = new MyConsumer(boundedBuffer, 20);
        Thread consumerThread = cons.CreateConsumerThread();

        producerThread.Start();
        consumerThread.Start();

        Console.ReadLine();
    }
}


