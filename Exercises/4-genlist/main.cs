using System;
using static System.Console;
using static System.Math;
public static class main{
public static void Main(){
	Write("Here I'm testing out lists \n");

	genlist<double> mylist = new genlist<double>();

	mylist.add(1.0);
	mylist.add(2.0);
	mylist.add(3.0);
	mylist.add(5.0);

	Func<double,double> f;
	f = Cos;

	for(int i=0; i<mylist.size; i++) {
		Write("Value: " + mylist[i] + " and Cosine: " + f(i) + "\n");
	}


	Write("So far so good B)\n");

	var list = new genlist<double[]>();
	char[] delimiters = {' ','\t'};
	var options = StringSplitOptions.RemoveEmptyEntries;
	for(string line = ReadLine(); line!=null; line = ReadLine()){
		var words = line.Split(delimiters,options);
		int n = words.Length;
		var numbers = new double[n];
		for(int i=0;i<n;i++) numbers[i] = double.Parse(words[i]);
		list.add(numbers);
		}
	for(int i=0;i<list.size;i++){
		var numbers = list[i];
		foreach(var number in numbers)Write($"{number : 0.00e+00;-0.00e+00} ");
		WriteLine();
		} /'Have to remember to break input with ctrl + D'/
	
	
}
}
