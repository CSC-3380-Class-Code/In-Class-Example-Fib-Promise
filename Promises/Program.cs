namespace Promises;

using System.Threading.Tasks;
using System;
class Program{
	public static void Main(){
		int num = 40;

		var watch = System.Diagnostics.Stopwatch.StartNew();
		Console.WriteLine(fib(num));
		watch.Stop();
        Console.WriteLine("Time elapsed {0}ms\n", watch.ElapsedMilliseconds);

		watch = System.Diagnostics.Stopwatch.StartNew();
		Console.WriteLine(fibPromise(num));
		watch.Stop();
        Console.WriteLine("Time elapsed {0}ms\n", watch.ElapsedMilliseconds);
	}

	public static int fib(int n){
		if(n < 2)
			return 1;

		return fib(n-1) + fib(n-2);
	}

	public static int fibPromise(int n){
		if(n < 2)
			return 1;

		return fib(n-1) + Task<int>.Run(()=>fib(n-2)).Result;
	}
}
