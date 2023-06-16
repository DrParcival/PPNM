using System;
using static System.Console;
using static System.Math;

public class EVD{


public static void timesJ(matrix A, int p, int q, double theta){
	double c=Math.Cos(theta),s=Math.Sin(theta);
	for(int i=0;i<A.size1;i++){
		double aip=A[i,p],aiq=A[i,q];
		A[i,p]=c*aip-s*aiq;
		A[i,q]=s*aip+c*aiq;
		} /*END: If i*/
	} /*END: Times J*/

public static void Jtimes(matrix A, int p, int q, double theta){
	double c=Math.Cos(theta),s=Math.Sin(theta);
	for(int j=0;j<A.size1;j++){
		double apj=A[p,j],aqj=A[q,j];
		A[p,j]= c*apj+s*aqj;
		A[q,j]=-s*apj+c*aqj;
		} /*END: If j*/
	} /*END: J times*/

public static (matrix,matrix) cyclic(matrix A){
	int n = A.size1;
	matrix d = A.copy();
	matrix v = matrix.id(n);
	bool changed;
	do{
		changed = false;
		for(int p=0;p<n-1;p++){
			for(int q=p+1;q<n;q++){
				double apq=d[p,q], app=d[p,p], aqq=d[q,q];
				double theta=0.5*Math.Atan2(2*apq,aqq-app);
				double c=Math.Cos(theta),s=Math.Sin(theta);
				double new_app=c*c*app-2*s*c*apq+s*s*aqq;
				double new_aqq=s*s*app+2*s*c*apq+c*c*aqq;
				if(new_app!=app || new_aqq!=aqq){
					changed=true;
					timesJ(d,p,q, theta); // A←A*J 
					Jtimes(d,p,q,-theta); // A←JT*A 
					timesJ(v,p,q, theta); // V←V*J
						} /*END: If*/
					} /*END: For q*/
				}/*END: For p*/
		
		}while(changed);
		return (d,v);
		} /*END: Cyclic*/
	


}/*END: class*/