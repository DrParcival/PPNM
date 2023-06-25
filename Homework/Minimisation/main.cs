using System;
using static System.Console;
using static System.Math;
public static class main{
public static void Main(){

	System.Console.Write("Let's find the minimum for Rosenbrocks function: \n");
	Func<vector,double> r = delegate(vector x){return (1-x[0])*(1-x[0])+100*(x[1]-x[0]*x[0])*(x[1]-x[0]*x[0]);};
	vector s1 = new vector(1,2);
	var (sol1,iters) = qnewton(r, s1);
	System.Console.Write("The min is at ({0},{1}) with {2} steps \n",sol1[0],sol1[1],iters);
	System.Console.Write("Based Wikipedia the minimum is at (1,1) \n");

	Func<vector,double> h = delegate(vector x){return (x[0]*x[0]+x[1]-11)*(x[0]*x[0]+x[1]-11)+(x[0]+x[1]*x[1]-7)*(x[0]+x[1]*x[1]-7);};
	vector s2 = new vector(3,1.9);
	vector s3 = new vector(-3,3);
	vector s4 = new vector(-3.5,-3);
	vector s5 = new vector(3.5,-2);
	var (sol2,iters2) = qnewton(h, s2);
	var (sol3,iters3) = qnewton(h, s3);
	var (sol4,iters4) = qnewton(h, s4);
	var (sol5,iters5) = qnewton(h, s5);	

	System.Console.Write("End then the min for Himmelblau is at ({0},{1}) with {2} steps \n",sol2[0],sol2[1],iters2); /*First*/
	System.Console.Write("End then the min for Himmelblau is at ({0},{1}) with {2} steps \n",sol3[0],sol3[1],iters3); /*Second*/
	System.Console.Write("End then the min for Himmelblau is at ({0},{1}) with {2} steps \n",sol4[0],sol4[1],iters4); /*Third*/
	System.Console.Write("End then the min for Himmelblau is at ({0},{1}) with {2} steps \n",sol5[0],sol5[1],iters5); /* Fourth*/
	System.Console.Write("Based Wikipedia the global minimums are at (3,2), (-2.8,3.1), (-3.8, -3.3) and (3.6, -1.8)  \n");


}

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

}
