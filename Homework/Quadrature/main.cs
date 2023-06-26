using System;
using static System.Console;
using static System.Math;
using static System.Double;
public static class main{
public static void Main(){

	System.Console.Write("Let's test the integrator in different cases \n");

	Func<double,double> f1=x => Sqrt(x);
	Func<double,double> f2=x => 1/Sqrt(x);
	Func<double,double> f3=x => 4*Sqrt(1-Pow(x,2));
	Func<double,double> f4=x => Log(x)/Sqrt(x);
	
	test(f1, 0.0, 1.0, 2.0/3.0);
	test(f2, 0.0, 1.0, 2.0);
	test(f3, 0.0, 1.0, PI);
	test(f4, 0.0, 1.0, -4.0);

	System.Console.Write("Error function \n");
	data();
	

}

static double integrate(Func<double,double> f, double a, double b, double delta=0.001, double eps=0.001, double f2 = NaN, double f3 = NaN){
double h=b-a;
if(IsNaN(f2)){ f2=f(a+2*h/6); f3=f(a+4*h/6); } // first call, no points to reuse
double f1=f(a+h/6), f4=f(a+5*h/6);
double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
double err = Abs(Q-q);
if (err <= delta+Abs(eps)) return Q;
else return integrate(f,a,(a+b)/2,delta/Sqrt(2),eps,f1,f2)+
            integrate(f,(a+b)/2,b,delta/Sqrt(2),eps,f3,f4);
	} /*END: Integrate*/

public static double error(double x){
	if(x > 1.0){
		Func<double,double> erf = t => Exp(-Pow(x+(1-t)/t, 2))/t/t;
		return 1.0-2.0/Sqrt(PI)*integrate(erf, 0.0, 1.0);
		}
	if(Abs(x) <= 1.0){
		Func<double,double> erf = y => Exp(-Pow(y, 2));
		return 2/Sqrt(PI)*integrate(erf, 0.0, x);
		}
	else return -error(-x);

	} /*END: Error*/

public static bool acc(double calc, double sol){
	double delta = 0.003;
	double eps = 0.002;

	if(Abs(calc-sol) > delta) {return false;}
	if(Abs(calc-sol)/sol > eps) {return false;}
	else return true;
	} /*END: Accuracy*/

public static void test(Func<double,double> f, double a, double b, double sol){
	double inte = integrate(f,a,b);
	System.Console.Write("The approximate solution is {0} where as the real one is {1} from {2} to {3} \n", inte, sol, a,b);
	System.Console.Write("Is this within the accuracy? : {0} \n", acc(inte, sol));
	} /*END: Test*/

public static void data(){
	for(double i = -3; i<= 3; i+=1.0/32.0){
		double erf = error(i);
		System.Console.Write("{0}	{1} \n", i, erf);
		} /*END: For i*/

	} /*END: Data*/




}
