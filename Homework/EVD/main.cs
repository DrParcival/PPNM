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



	double rmax = 10;
	double dr = 0.3;
	int npoints = (int)(rmax/dr)-1;
	vector r = new vector(npoints);
	for(int i=0;i<npoints;i++)r[i]=dr*(i+1);
	matrix H = new matrix(npoints,npoints);
	for(int i=0;i<npoints-1;i++){
	   H[i,i]  =-2;
	   H[i,i+1]= 1;
	   H[i+1,i]= 1;
	  }
	H[npoints-1,npoints-1]=-2;
	for(int j=0;j<H.size2;j++)
	for(int i=0;i<H.size1;i++)
		H[i,j]*=-0.5/dr/dr;
	for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

	
	
	(matrix d, matrix v)= EVD.cyclic(Ag);
	d.print("This should be diagonal \n");
	v.print("This is the eigenvectors \n");
	Ag.print("And this is our original matrix \n");
	
			

} /*END: Decom*/



}