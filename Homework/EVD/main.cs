using System;
using static System.Console;
using static System.Math;
using static System.Random;
public static class main{
public static void Main(){
	eigen();

}

public static void eigen(){
	System.Console.Write("This is the call for the eigenvalue matrix \n");

	matrix Ag = new matrix(4,4);

	/*Generate random symmetric matrix*/
	Random rnd = new Random();
	for (int e=0; e<4; e++){
		Ag[e,e]=rnd.Next(15);
		for(int f=3; f>e; f--){
			Ag[e,f]=rnd.Next(15);
			Ag[f,e]=Ag[e,f];
			}/*END: For f*/

		} /*END: For e*/

	
	
	EVD call = new EVD(Ag);
	/*matrix ap = call.A;*/
	matrix vp = call.V;
	matrix vv = vp*vp.T;
	matrix mul1 = vp.T*Ag*vp;
	matrix mul3 = vp*mul1*vp.T;
	matrix mul2 = vp.T*vp;
		
	Ag.print("This is the A matrix: \n");
	call.V.print("This is the V matrix: \n");
	mul1.print("This should be diagonal: \n");
	vv.print("This should be the identity VVT: \n");
	mul2.print("This should also be the identity VTV: \n");
	mul3.print("And this returns A again: \n");

} /*END: Decom*/



}
