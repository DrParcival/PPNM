using System;
using static System.Console;
using static System.Math;
public static class main{
public static void Main(){

double[] x = new double[20];
double[] y = new double[20];

for(int i=0; i<20; i++){
	x[i] = i/2.0;
	y[i] = Math.Pow(x[i]-1,3);
	} /*END: For i*/

System.Console.Write("The exact integral [0,5] is 63,75 by Wolfram Alpha and the approximate value is {0} \n", linterpInteg(x,y,5));

for(double j=0; j<5; j+=0.1){
	System.Console.Write("{0}  {1}  {2} \n", j, linterp(x,y,j), linterpInteg(x,y,j));
	} /*END: For j*/

}

public static double linterp(double[] x, double[] y, double z){
        int i=binsearch(x,z);
        double dx=x[i+1]-x[i]; if(!(dx>0)) throw new Exception("uups...");
        double dy=y[i+1]-y[i];
        return y[i]+dy/dx*(z-x[i]);
        } /*END: Linear*/

public static int binsearch(double[] x, double z)
	{/* locates the interval for z by bisection */ 
	if(!(x[0]<=z && z<=x[x.Length-1])) throw new Exception("binsearch: bad z");
	int i=0, j=x.Length-1;
	while(j-i>1){
		int mid=(i+j)/2;
		if(z>x[mid]) i=mid; else j=mid;
		}
	return i;
	}

/*Then the intergration function to a given point z*/
public static double linterpInteg(double[] x, double[] y, double z){
	double s = 0;
	int b = binsearch(x, z);
	for(int i=0; i<b; i++){
		double dx = x[i+1]-x[i];
		double dy = y[i+1]-y[i];
		double pi = dy/dx;
		s += y[i]*dx+(pi*dx*dx)/2.0;
		} /*END: For i*/
	double pz = (y[b+1]-y[b])/(x[b+1]-x[b]);
	s += y[b]*(z-x[b])+pz*((z-x[b])*(z-x[b]))/2.0;
	
	return s;
	}/*END; Spline*/

}
