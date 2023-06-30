using System;
using static System.Console;
using static System.Math;
public static class main{
public static void Main(){

System.Console.Write("Finding the root in paraboloid \n");
Func<vector, vector> f1 = xn => new vector(xn[0]*xn[0]-4);
vector x1 = new vector(1.0);
vector x2 = new vector(-0.5);
var root1 = newton(f1, x1);
var root2 = newton(f1, x2);
System.Console.Write("Looking for the root of x^2-4 \n");
System.Console.Write("My method gives {0} and {1} when they should be 2 and -2 \n",root1[0],root2[0]);

System.Console.Write("\n");
System.Console.Write("Finding the root(s) of Rosenbrock's valley function\n");
Func<vector, vector> f2 = xy => new vector(2*(200*Pow(xy[0],3)-200*xy[0]*xy[1]+xy[0]-1),200*(xy[1]-xy[0]*xy[0]));
vector x3 = new vector(0.5,-1.1);
vector x4 = new vector(1.5,1.1);
var root3 = newton(f2, x3);
var root4 = newton(f2, x4);
System.Console.Write("Looking for the root of Rosenbrock's valley function \n");
System.Console.Write("My method gives {0} and {1} when it should be (1,1) according to Wikipedia \n",root3[0],root4[0]);

}
static vector newton(Func<vector,vector> f, vector x, double eps=1e-2){
	int n = x.size;
	matrix J = new matrix(n,n);
	vector fx = f(x);
	int maxstep = 100;
	
	do{
		for(int i=0; i<n; i++){
			double del = Abs(x[i])*Pow(2,-26);
			for(int j=0; j<n; j++){
				vector xj = x.copy();
				xj[j] += del;
				J[i,j] = (f(xj)[i]-f(x)[i])/del;
				}/*END: For j*/
			}/*END: For i*/
		QRGS linear = new QRGS(J);
		vector dx = linear.solve(-fx);
		double lambda = 1;
		
		while((f(x+lambda*dx)).norm()>(1-lambda/2)*(f(x)).norm() && lambda >= 1/1024){			lambda=lambda/2;
			} /*END: While*/
		x += lambda*dx;
		fx = f(x);
		maxstep--;
		if((f(x)).norm() <= eps && maxstep <= 0){
			break;
			} /*END: If*/
		} while(true);
	return x;
	}/*END: Newton*/

}
