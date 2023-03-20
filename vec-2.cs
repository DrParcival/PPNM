using static System.Console;
using static System.Math;
public class vec{
	public double x,y,z;
	public vec (double x,double y,double z)
		{ this.x=x; this.y=y; this.z=z; }
	public vec (){ x=y=z=0; }
	public void print(string s){Write(s);WriteLine($"{x} {y} {z}");}

	public static vec operator+(vec u,vec v){ /* u+v */
		return new vec(u.x+v.x,u.y+v.y,u.z+v.z);
			}

	public static vec operator-(vec u,vec v){ /* u-v */
		return new vec(u.x-v.x,u.y-v.y,u.z-v.z);
			}

	public static vec operator-(vec v){ /* -v */
		return new vec(-v.x,-v.y,-v.z);
			}

	public static vec operator*(vec u,double c){ /* u*c */
		return new vec(u.x*c,u.y*c,u.z*c);
	}

	public static vec operator*(double c,vec u){ /* c,*u */
		return u*c;
	}

	public static double operator% (vec u,vec v){ /* u%v => dot product */
		return u.x*v.x+u.y*v.y+u.z*v.z;
	}

	public double dot (vec other){ return this%other; }

	static bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
		if(Abs(a-b)<acc)return true;
		if(Abs(a-b)<(Abs(a)+Abs(b))*eps)return true;
		return false;
	}
	public bool approx(vec other){
                if(!approx(this.x,other.x))return false;
                if(!approx(this.y,other.y))return false;
                if(!approx(this.z,other.z))return false;
                return true;
        }
        public static bool approx(vec u, vec v) => u.approx(v);
	
	public override string ToString(){ return $"{x} {y} {z}"; }
}
