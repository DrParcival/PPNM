using System;
using static System.Console;
using static System.Math;

public class QRGS{
    public matrix Q,R;

    public QRGS(matrix a){
        Q=a.copy();
        int m = a.size2;
        //WriteLine($"m={m}");
        R = new matrix(m,m);
        for(int i=0;i<m;i++){
            R[i,i] = Q[i].norm();
            Q[i]/=R[i,i];
            for(int j=i+1;j<m;j++){
                R[i,j]=Q[i].dot(Q[j]);
                Q[j]-=Q[i]*R[i,j];
            }
        }
    }




    public vector solve(vector b){
        matrix Q_t = Q.transpose();
        vector x = Q_t*b;
        backsub(R, x);
        return x;
    } 

    public void backsub(matrix U, vector c){
        for(int i=c.size-1; i>=0; i--){
            double sum = 0;
            for(int k=i+1;k<c.size; k++){
                sum+= U[i,k]*c[k];
            }
            c[i] = (c[i]-sum)/U[i,i];
        }
    }


}