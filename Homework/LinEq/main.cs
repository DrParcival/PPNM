using System;
using static System.Console;
using static System.Math;
public static class main{
public static void Main(){
	decomposition();
	solving();
	invert();

}



public static void decomposition(){
	System.Console.Write("This is the decomposition to Q and R \n");
	matrix a = new matrix("2,3;-1,1;2,1");
	a.print("This is my matrix A \n");
	QRGS factor = new QRGS(a);
	factor.r.print("This is the R matrix");
	factor.q.print("This is the Q matrix");
	matrix prod = factor.q*factor.r;
	prod.print("This should be same as the A");
	matrix iden = factor.q.T*factor.q;
	iden.print("Q transpose times Q is");

} /*END: Decom*/

public static void solving(){
	System.Console.Write("Here we solve x");
	matrix a = new matrix("2,3,4;-1,1,0;2,1,-2");
	vector b = new vector("3,4,-1");
	b.print("This is my vector b");
	QRGS factor = new QRGS(a);
	vector x = factor.solve(b);
	x.print("This is the solution x");
	vector ax = a*x;
	ax.print("This shold be equal to b");


} /*END: Solve*/

public static void invert(){
	System.Console.Write("This is the inverse");
	matrix a = new matrix("2,3,4;-1,1,0;2,1,-2");
	a.print("This is the used matrix");
	QRGS factor = new QRGS(a);
	matrix ia = factor.inverse(a);
	ia.print("This is the inverse");
	matrix p = ia*a;
	p.print("This should be identity");


}


}
