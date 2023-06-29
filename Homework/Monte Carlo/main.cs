using System;
using static System.Console;
using static System.Math;
using static System.Random;
public static class main{
public static void Main(){

System.Console.Write("Area of the unit cirle: \n");
Func<vector, double> a = r => r[0];
vector init = new vector(0,0);
vector fin = new vector(1,2*PI);
int n = 1000000;
var area = plainmc(a, init, fin, n);
System.Console.Write("The area is {0} with an error {1}. The accurate result is {2} \n", area.Item1, area.Item2, PI);

System.Console.Write("\n");
System.Console.Write("Area of a singular integral \n");
Func<vector, double> b = xyz => Pow(1/PI,3)*1/(1-Cos(xyz[0])*Cos(xyz[1])*Cos(xyz[2]));
vector initb = new vector(0,0,0);
vector finb = new vector(PI,PI,PI);
var areab = plainmc(b, initb, finb, n);
System.Console.Write("The area is {0} with an error {1}. The accurate result is 1.3932039296856768591842462603255 \n", areab.Item1, areab.Item2);

System.Console.Write("\n");
System.Console.Write("Check if the error decreases as it should \n");

double prev = 0;
for(int i=10; i<1e8; i*=10){
	var error = plainmc(a, init, fin, i);
	if(prev/error.Item2 < Sqrt(i)) {System.Console.Write("True \n");}
	else System.Console.Write("False \n");
	} /*END: For i*/

}

static (double,double) plainmc(Func<vector,double> f, vector a, vector b, int N){
        int dim=a.size; 
	double V=1; 
	for(int i=0; i<dim; i++)V*=b[i]-a[i];
        double sum=0, sum2=0;
	var x = new vector(dim);
	var rnd=new Random();
        for(int i=0; i<N; i++){
                for(int k=0; k<dim; k++)x[k]=a[k]+rnd.NextDouble()*(b[k]-a[k]);
                double fx=f(x); sum+=fx; sum2+=fx*fx;
                }
        double mean=sum/N, sigma=Sqrt(sum2/N-mean*mean);
        var result=(mean*V,sigma*V/Sqrt(N));
        return result;
	} /*END: Plainmc */


}
