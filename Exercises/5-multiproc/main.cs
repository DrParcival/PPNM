using System;
using System.Threading;
using static System.Console;
using static System.Math;
class main{

public class data { public int a,b; public double sumab; } /*Prepares the data*/

public static void harmonic_sum(object obj){
	data x = (data)obj;
	WriteLine($"thread {Thread.CurrentThread.Name} started: a={x.a} b={x.b}");
	x.sumab=0;
	for(int i=x.a;i<x.b;i++)x.sumab+=1.0/i;
	WriteLine($"thread {Thread.CurrentThread.Name} done: partial sum = {x.sumab}");
	} /*Does the calculations and in the middle writes to let the user see what is happening*/

public static int Main(string[] args){
	data x = new data();
	x.a = 1; x.b = 1001;                 /* prepare data */
	Thread t = new Thread(harmonic_sum); /* prepare a thread */
	t.Name = "my new thread";            /* you can give it a name, if you wish */
	t.Start(x);                          /* run the t-thread with object x as argument to harmonic_sum */
	/* meanwhile do some work in the main thread */
	t.Join();                            /* join the t-thread with the main thread */
	WriteLine($"harmonic sum from {x.a} to {x.b} equals {x.sumab}");
	
	return 0;
	}

}
