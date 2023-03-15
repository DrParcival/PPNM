using System;
using static System.Console;
using static System.Math;
public static class main{

	public static void Main(){
	
		double s = Math.Sqrt(2);
	
		Write("Let's look at some math stuff:\n");
		Write("Squareroot of 2 is: {0} \n",s);
		Write("2 to the power of 1/5:" + Math.Pow(2.0,0.2) + "\n");
		Write("pi to the power of e:" + Math.Pow(Math.PI,Math.E) + "\n");
		Write("e to the power of pi:" + Math.Pow(Math.E,Math.PI) + "\n");

		double g1 = Gamma.gamma(1);
		double g2 = Gamma.gamma(2);
		double g3 = Gamma.gamma(3);
		double g4 = Gamma.gamma(10);

		Write("Then the gamma-function for few values: \n");
		Write("For 1: "  + Round(g1,6,MidpointRounding.AwayFromZero) + "\n");
		Write("For 2: "  + Round(g2,6,MidpointRounding.AwayFromZero) + "\n");
		Write("For 3: "  + Round(g3,6,MidpointRounding.AwayFromZero) + "\n");
		Write("For 10: " + Round(g4,6,MidpointRounding.AwayFromZero) + "\n");
		}
}

