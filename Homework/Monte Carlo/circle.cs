using System;
using static System.Console;
using static System.Math;
using static System.Random;
public static class main{
public static void Main(){

Func<vector, double> a = r => r[0];
vector init = new vector(0,0);
vector fin = new vector(1,2*PI);

for(int i=10; i<1e8; i*=10){
	var area = plainmc(a, init, fin, i);
	System.Console.Write("{0}  {1}   {2} \n", i, area.Item1, area.Item2);
	} /*END: For i*/

}

public static (double,double) plainmc(Func<vector,double> f, vector a, vector b, int N){
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
