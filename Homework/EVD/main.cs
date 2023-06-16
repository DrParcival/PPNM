using System;
using static System.Console;
using static System.Math;
using static System.Random;
class main{
public static void Main(){
        
        /*System.Console.Write("Constant rmax and varying dr \n");
        fixed_rmax();
	System.Console.Write("Constant dr and varying rmax \n");
        fixed_dr();
	System.Console.Write("Let's compare these with the analytical solution \n");*/
	comparisong();

 

    }

    public static void fixed_rmax(){
        double rmax=20;
	for(double dr = 0.1; dr<=10; dr+=0.1){
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
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

		(matrix d, matrix v)= EVD.cyclic(H);
		System.Console.Write("{0} {1} \n",dr,d[0,0] );
		}/*END: For dr*/
        } /*END: Fixed rmax*/

	public static void fixed_dr(){
        double dr=0.1;
	for(double rmax = 0.3; rmax<=10; rmax+=0.1){
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
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

		(matrix d, matrix v)= EVD.cyclic(H);
		System.Console.Write("{0} {1} \n",rmax,d[0,0] );
		}/*END: For rmax*/
        } /*END: Fixed dr*/
	

	public static void comparisong(){
		double dr=0.3;
		double rmax = 10; 
	
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
		H*=-0.5/dr/dr;
		for(int i=0;i<npoints;i++)H[i,i]+=-1/r[i];

		(matrix d, matrix v)= EVD.cyclic(H);

		matrix norm = v;
		/*Hydrogen energies from Wikipedia*/
		for(int i=0; i< v.size1; i++){
			double E1 = 1/(Math.Sqrt(Math.PI))*Math.Exp(-r[i]);
			double E2 = 1/(4*Math.Sqrt(Math.PI))*(2-r[i])*Math.Exp(r[i]/2);
			System.Console.Write("{0} {1} {2} \n",r[i], E1, E2);
			System.Console.Write("\n");
		}/*END: For i*/

		

		for(int i=0; i< v.size1; i++){
			double V1 = norm[i,0]/r[i];
			double V2 = norm[i,1]/r[i];
			System.Console.Write("{0} {1} {2} \n",r[i], V1, V2);
		}/*END: For i*/


		}/*END: Comparisong*/

    } /*END: main*/

  