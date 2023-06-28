using System;
using static System.Console;
using static System.Math;
public static class main{
public static void Main(){

/*I'm worked with fixed lenght but it could be updated for arbitrary lenght*/
double[] x = new double[20];
double[] y = new double[20];
double[] p = new double[20];

for(int i=0; i<20; i++){
	x[i] = i/2.0;
	y[i] = Math.Pow(x[i]-1,3);
	} /*END: For i, Creating the tabulated points*/

/*Let's get the p at point i*/
for(int i=1; i<19; i++){
	double b1 = (y[i]-y[i-1])/(x[i]-x[i-1]);
	double b2 = ((y[i+1]-y[i])/(x[i+1]-x[i])-b1)/(x[i+1]-x[i-1]);
	p[i] = b1 +b2*(x[i]-x[i-1]);
	} /*END: For i*/
p[0] = p[1];
p[19] = p[18];


System.Console.Write("Here is the data x(i), y(i) and p(i): \n");
for(int i=0; i<20; i++){
	System.Console.Write("{0}, {1}, {2} \n",x[i], y[i], p[i]);
	}


System.Console.Write("x, approximated y, approximated derivative \n");
for(double j=0; j<5; j+=0.1){
	System.Console.Write("{0}  {1}  {2}   \n", j, cube(x,y,p,j), derivative(x,p,j));
	} /*END: For j*/

} /*END: Main*/

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



public static double cube(double[] x, double[] y, double[] p, double z){
	int i=binsearch(x,z);
	
	/*Factors from interpolation Eq. (32)*/
	double b = p[i]; 
	double c = (3*((y[i+1]-y[i])/(x[i+1]-x[i]))-2*p[i]-p[i+1])/(x[i+1]-x[i]);
	double d = (p[i]+p[i+1]-2*((y[i+1]-y[i])/(x[i+1]-x[i])))/(Pow(x[i+1]-x[i],2));
	double sol = y[i]+b*(z-x[i])+c*(z-x[i])*(z-x[i])+d*Pow(z-x[i],3);

	return sol;

	} /*END: Cube*/

public static double derivative(double[] x, double[] p, double z){
	/*Assuming that p[] is close enough to derivative so y[]=p[]*/

	double[] dp = new double[20];

	for(int i=1; i<19; i++){
	double b1 = (p[i]-p[i-1])/(x[i]-x[i-1]);
	double b2 = ((p[i+1]-p[i])/(x[i+1]-x[i])-b1)/(x[i+1]-x[i-1]);
	dp[i] = b1 +b2*(x[i]-x[i-1]);
	} /*END: For i*/

	dp[0] = dp[1];
	dp[19] = dp[18];

	double fit = cube(x, p, dp, z);
	return fit;

	} /*END: Derivative */

public static double integrate(double[] x, double[] y, double[] p, double z){
	/*As the spline is just a polynomial function it should still give some useful results when intergrated*/

	int i=binsearch(x,z);
	
	double b = p[i]; 
	double c = (3*((y[i+1]-y[i])/(x[i+1]-x[i]))-2*p[i]-p[i+1])/(x[i+1]-x[i]);
	double d = (p[i]+p[i+1]-2*((y[i+1]-y[i])/(x[i+1]-x[i])))/(Pow(x[i+1]-x[i],2));

	double sol = y[i]*(z-x[i])+(b/2)*Pow((z-x[i]),2)+(c/3)*Pow((z-x[i]),3)+(d/4)*Pow((z-x[i]),4);
	return sol;

	} /*END: Integrate*/

}
