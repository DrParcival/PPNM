using System;
using static System.Math;

public class QRGS{
	public matrix q,r;

public QRGS(matrix a){
	q=a.copy();
	int p=a.size2;
	r=new matrix(p,p);
	
	for(int i=0; i<p; i++){
		r[i,i]=q[i].norm();
		q[i]/=r[i,i];
		for(int j=i+1; j<p; j++){
			r[i,j]=q[i].dot(q[j]);
			q[j]-=q[i]*r[i,j];
		}/*END: For j*/

	}/*END: For i*/



} /*END: QRGS*/


/*52*/
public vector solve(vector sb){
	int m = r.size1;
	matrix sqt = q.T;
	vector x = sqt*sb;

	if (sqt.size2 != sb.size){
		System.Console.Write("The dimensions of the transpose matrix Q and vector b don't match!\n");
		return x;
		} /*END: If*/
	/*Then the backsubstitution*/
	for (int i=m-1;i>=0;i--){
		double sum = 0;
		for(int j=i+1;j<m;j++){
			sum += r[i,j]*x[j];
                  } /*END: For j*/

		x[i]=(x[i]-sum)/r[i,i];
		} /*END: For i*/

	
	return x;
} /*END: Solve*/

public matrix inverse(matrix a){
	int n = a.size1;
	matrix ina = new matrix(n,n);
	for (int i=0; i<n; i++){
		vector ei = matrix.id(n)[i];
		ina[i]=solve(ei);

		}/*END: For i*/
	return ina;

} /*END: Inverse*/


} /*END: class*/

