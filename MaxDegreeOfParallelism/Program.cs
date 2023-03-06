using System.Diagnostics;

var locker = new Object();
int count = 0;
var countFinished = 0;
var loopNumber = 1000;
var stopwatch = Stopwatch.StartNew();
Console.WriteLine("Environment.ProcessorCount: " + Environment.ProcessorCount);

Parallel.For
    (0
     , loopNumber
     , new ParallelOptions { MaxDegreeOfParallelism = 20 }
     , (i) =>
           {
               Interlocked.Increment(ref count);
               lock (locker)
               {
                   Console.WriteLine($"Number of active threads: {count}, Elapsed Time: {stopwatch.Elapsed} finished: {((decimal)countFinished/(decimal)loopNumber):P}");
                   Thread.Sleep(10);
               }
               Interlocked.Decrement(ref count);
               Interlocked.Increment(ref countFinished);
           }
    );
