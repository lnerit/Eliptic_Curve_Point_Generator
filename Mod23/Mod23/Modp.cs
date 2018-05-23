using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mod23
{
    class Modp
    {

        //declare the constants and variables
      
        public static long p=23;
        public static string GenerateEllipticPoint(int x,int constanta,int constantb)
        {
            string points = "ELLIPTIC-CURVE POINTS FOR MOD "+p.ToString()+" WITH X = "+x.ToString()+" |-->[ y^2=" + (Math.Pow(x, 3) + (constanta * x) + constantb).ToString() + " ]\r\n";
            points += "---------------------------------------------------------------------------------------------\r\n";
            long boundary = (4 * constanta * constanta * constanta) + (27 * constantb * constantb);
            if (boundary == 0)
            {
               // MessageBox.Show("ERROR...THE BOUNDRY CONDITION MUST NOT BE ZERO(0)", "",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return "ERROR...THE BOUNDRY CONDITION MUST NOT BE ZERO(0)";
            }

           double result = Math.Pow(x, 3) + (constanta * x) + constantb;
            
            bool isSquare = Math.Sqrt(result) % 1 == 0; //Chech if the result values is perfect square number
            if (isSquare)
            {
                string x1="("+x+","+Math.Sqrt(result).ToString()+")"; //Point 1 (eg. x=1, y^2=4, Point 1: (1,2)
                string p2= "(" + x + "," + (-Math.Sqrt(result)).ToString() + ")"; //Point 2
                //for the second point x2, we need to compute the positive equivalence base on the value p.
                double positiveEquivalence = (-Math.Sqrt(result)) + p;
                string x2 =  "(" + x + "," + positiveEquivalence + ")";
                points +="POINT 1:--> "+x1 + "\r\nPOINT 2:--> "+ p2+" | <=> Postive Equivalence: "+ x2 + "\r\n\r\n"; 
            }else //When the value of y squared (y^2) is not a perfect square number, this section will be executed
            {
                
                List<long> lx = ModpNumber((long)result, p, 10000); //Invoke this method by determining the upper bound of MODp numbers
                if (lx.Count > 0)
                {
                    int i = 1;
                    foreach(int n in lx)
                    {
                        points += "POINT "+i.ToString()+": (" + x + "," + n.ToString() + ")\r\n";
                        i++;
                    }
                    points+="\r\n\r\n";
                }
                else
                {
                    points += "NO POINT(S) FOUND FOR X VALUE: "+x.ToString() + "\r\n\r\n"; ;
                }
            }
            return points;
        }

        /**
         * This method is used for Generating numbers based on ySquared (from equation y^2=x^3+ax+b)
         * and the Mod p value.
         * The values generated will be up to the upperBound.
         * From these values, we then take the square root of those perfect square numbers
         * whose square root values lie between 0 and p
         * **/
        static List<long> ModpNumber(long ySquared,long p,long upperBoud)
        {
            List<long> inList = new List<long>();
            long x = ySquared%p; //Divide the y-squared value by the mod p  to get the reminder
            long y = x + p; //We generate a number from the mod p and the remainder which will be used to 
                             // determine the square root of a perfect square number between 0 and the mod p.
                             //This value is then stored into the list for a given x-value
            if (upperBoud > 0)
            {
                while (y < upperBoud)
                {

                    if (y%p==x && (Math.Sqrt(y)%1==0) && (Math.Sqrt(y)<=p && Math.Sqrt(y) >= 0))
                    {
                        inList.Add((int)Math.Sqrt(y));
                    }
                     y+= p;
                }
            }
            return inList;
        }
        /**
         * This function checks if a number is Prime or not
         * Returns true if the number p is prime and false otherwise.
         * */
        public static bool IsPrime(int p)
        {
            if (p == 1) return false;
            if (p == 2) return true;
            if (p % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(p));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (p % i == 0) return false;
            }
            return true;
        }
    }

}
