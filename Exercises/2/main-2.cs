using System;
using static System.Console;
using static System.Math;
public static class main{

public static bool approx
(double a, double b, double acc=1e-9, double eps=1e-9){
	if(Abs(b-a) < acc) return true;
	else if(Abs(b-a) < Max(Abs(a),Abs(b))*eps) return true;
	else return false;
}

public static void Main(){

	System.Console.Write("These are my epsilon and vector exercises\n");

	int k=1; while(k+1>k) {k++;}
	Write("My max int = {0}\n",k);
	
	int j=1; while(j-1<j) {j--;}
	Write("My max int = {0}\n",j);

	Write("The max is {0}\n", int.MaxValue);
	Write("The min is {0}\n", int.MinValue);

	double x=1; while(1+x!=1){x/=2;} x*=2;
	float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
	Write("We get the double {0} and the float {1}\n",x,y);
	Write("We should get the double {0} and the float {1}\n",System.Math.Pow(2,-52),System.Math.Pow(2,-23));
	
	int n=(int)1e6;
	double epsilon=Pow(2,-52);
	double tiny=epsilon/2;
	double sumA=0,sumB=0;

	sumA+=1; for(int i=0;i<n;i++){sumA+=tiny;}
	for(int i=0;i<n;i++){sumB+=tiny;} sumB+=1;

	WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
	WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
	WriteLine("Epsilon is the smallest double that 1 + epsilon is not 1. That means that half that is always just 1. \n");

	
	Write("{0} and {1} are roughly equal: {2} \n",1.00000000001,1.0,approx(1.00000000001,1.0));
	Write("{0} and {1} are roughly equal: {2} \n",1.0001,1.0,approx(1.0001,1.0));
	

	vec a = new vec(3, 4, 1);
	vec b = new vec(-1, 1, 10);
	
	Write("Vector a is: {0} \n", a);
	Write("Vector b is: {0} \n", b);
	Write("The sum of the vectors is: {0} \n", a+b);
	Write("The difrence of the vectors is: {0} \n", a-b);
	Write("The product of vector a and 3 is: {0} \n", a*3);
	Write("The dot product of the vectors is: {0} \n", a.dot(b));	
}
}
