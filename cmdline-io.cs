using System;
using static System.Console;
using static System.Math;
class main{
	public static int Main(string[] args){
	WriteLine("Let's print the numbers and their sine and cosine");
	foreach(string arg in args){
		string[] words=arg.Split(':');
		if(words[0]=="-numbers"){
			var numbers=words[1].Split(',');
			foreach(var number in numbers){
				double x = double.Parse(number);
				WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
			}
		}

	return 0;
	}//Main
}//main
