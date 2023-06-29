using System;
using static System.Console;
using static System.Math;
public static class main{
public static void Main(){

System.Console.Write("Try with an interesting function g(x) \n");
Func<double,double> g = (x) => Cos(5*x-1)*Exp(-x*x);
int sample=25;
vector xs = new vector(sample);
vector ys = new vector(sample);
double a=-1;
double b=1;

for(int i=0; i<sample; i++){
	double xi = a+(b-a)*i/(sample-1);
	double yi = g(xi);
	xs[i] = xi;
	ys[i] = yi;
	System.Console.Write("{0}   {1} \n", xi, yi);
	}/*END: For i*/
int iterations = 10;
var network = new ann(iterations);
network.train(xs,ys);

System.Console.Write("Try to see if the solution is any good \n");
for(int i=0; i<100; i++){
	double xi = -1+i*2.0/99;
	double realy = g(xi);
	double prey = network.response(xi);
	System.Console.Write("{0}   {1}   {2}  \n", xi, realy, prey);
	}/*END: For i*/

} /*END: Main*/

public class ann{
	int n;
	Func<double,double> f = x => x*Exp(-x*x);
	vector p;

	public ann(int n){
		this.n = n;
		this.p = new vector (3*n);
		}/*END: Constructor*/
	public ann(vector p){
		this.n =p.size/3;
		this.p = p;
		} /*END: Constructor*/

	public double response(double x){
      		double res = 0;
		for(int i=0; i<n; i++){
			double ai = p[3*i];
			double bi = p[3*i+1];
			double wi = p[3*i+2];

			res += f((x-ai)/bi)*wi;
			}/*END: For i*/
		return res;
     	} /*END: Response*/

	public vector train(vector x, vector y){
      		for(int i=0; i<n; i++){
			p[i]=1.0;
			p[i+n]=1.0;
			p[i+2*n]=x[0]+(x[x.size-1]-x[0])*i/(n-1);
			}; /*END: For i*/

		Func<vector,double> cost = (a) => { 
			ann ann1 = new ann(a);
			double sum = 0;
			double n = x.size;
			for(int i=0; i<n; i++){
				double pre = ann1.response(x[i]);
				double real = y[i];
				sum += Pow(pre-real,2);
				} /*END: For i*/
			return sum/x.size;
			};
		var(ptrain, steps) = qnewton(cost, p);
		p=ptrain;
		return p;
   		} /*END: Train*/
} /*END: Ann*/

/*Copied straight from my minimasitation main*/
public static (vector,int) qnewton(Func<vector,double> f, vector start, double acc = 0.1){
	int iter = 0;
	int n = start.size;
	matrix H = matrix.id(n);

	vector grads = update(f, start);
	vector s = new vector(n);
	vector u = new vector(n);
	vector y = new vector(n);
	matrix B = new matrix(n,n);

	while(grads.norm()>acc){
		vector deltas = -H*grads;
		double lambda = 1.0;
		while(true){
			s = lambda*deltas;
			if(f(start+s)<f(start)){
				vector new_grad = grads;
				start = start+s;
				grads = update(f,start);
				y = new_grad;
				u = s-H*y;
				double uy = u.dot(y);
				if(Abs(uy)>1e-6){
					B = matrix.outer(u,u)/uy;
					H = H+B;
					}; /*END: If*/
				break;
				} /*END: If*/
				lambda = lambda/2;
				if(lambda<1.0/Math.Pow(2,10)){
					start = start + s;
					grads = update(f,start);
					H = matrix.id(n);
					break;
					}/*END: If*/
			} /*END: While*/
			iter++;
		} /*END: While*/
		return (start, iter);
	
	}/*END; Qnewton*/
public static vector update(Func<vector,double> f, vector s){
	
	double delta = Math.Pow(2,-25); /*Choose a small delta*/
	int n = s.size;

	vector gradient = new vector(n);

	double fx = f(s);
	for(int i=0; i<n; i++){
		double dx;
		double xi = s[i];
		if(Math.Abs(xi)<Math.Sqrt(delta)){dx=delta;}
		else{dx=Math.Abs(xi)*delta;};

		s[i] = xi+dx;
		gradient[i] = (f(s)-fx)/dx;
		s[i] = xi;
		}/*END: For i*/

	return gradient;
} /*END: Update*/



}
