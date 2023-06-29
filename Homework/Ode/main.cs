using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
public static class main{
public static void Main(){

System.Console.Write("Test 12 step with u'=-u \n");
double h = 0.1;
Func<double,vector,vector> f = delegate(double t, vector y){
	return new vector (y[1],-y[0]);
	};

vector y0 = new vector("1,0");
for(double i=0; i<=10;i+=h){
	vector sol = driver(f, i-h, y0, i);
	System.Console.Write($"{i}   {sol[0]}   {sol[1]} \n");
	
	y0 = sol;
	} /*END: For i*/

System.Console.Write("\n Test 12 step with scipy \n");
/*Tried with the same constants  as in the scipy manual*/

double b = 0.25;
double c = 5;
Func<double,vector,vector> g = delegate(double t, vector y){
	return new vector (y[1],-y[1]*b-c*Sin(y[0]));
	};
double[] start = new double [] {PI-0.1, 0.0};
vector y1 = new vector(start);
for(double i=0; i<=10;i+=h){
	vector sol = driver(g, i-h, y1, i);
	System.Console.Write($"{i}   {sol[0]}   {sol[1]} \n");
	
	y1 = sol;
	} /*END: For i*/


}

public static (vector,vector) rkstep12(Func<double,vector,vector> f, double x, vector y, double h){
	vector k0 = f(x,y);
	vector k1 = f(x+h/2,y+k0*(h/2));
	vector yh = y+k1*h;
	vector er = (k1-k0)*h;
	return (yh,er);
	} /*END: Rkstep*/

public static vector driver(Func<double,vector,vector> f, double a, vector ya, double b, double h=0.01, double acc=0.01, double eps=0.01){
	if(a>b) throw new ArgumentException("driver: a>b");
	double x=a; vector y=ya;
	/*var xlist=new List<double>(); xlist.Add(x);
	var ylist=new List<vector>(); ylist.Add(y);*/
	do{
        	if(x>=b) return y;
        	if(x+h>b) h=b-x;
        	var (yh,erv) = rkstep12(f,x,y,h);
        	double tol = Max(acc,eps*yh.norm())*Sqrt(h/(b-a));
        	double err = erv.norm();
        	if(err<=tol){ // accept step
			x+=h; y=yh;
		}
		h *= Min( Pow(tol/err,0.25)*0.95 , 2); // reajust stepsize
       		}while(true);
}/*END: Driver*/

}
