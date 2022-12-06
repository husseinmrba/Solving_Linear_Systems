//using System.Data;
using Testing.Controllers;
using Testing.Models;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                bool problemStateZ;
                List<Constraint> constraints = new List<Constraint>();
                List<double> resFunZ = new List<double>();
                
                Console.WriteLine("Please enter Z function.");
                ZFun zFun = EnterZFunction();

                Console.WriteLine("Please enter the state of problem(max or min).");
                problemStateZ = EnterStateOfProblemMaxOrMin();

                Console.WriteLine("Please enter the number of constraints.");
                int numberOfConstraints = EnterNumberOfConstraints();

                constraints = EnterConstraint(numberOfConstraints);

                Console.WriteLine();

                List<Point> points = PointController.GeneratePointsOfIntersection(constraints);

                foreach (var point in points)
                {
                    var check = ConstraintController.CheckConstraint(point, constraints, problemStateZ);
                    if (check)
                    {
                        double valueFunZ = ZFunController.ResultZFun(point, zFun);
                        resFunZ.Add(valueFunZ);
                        Console.WriteLine("(" + point.x1.ToString("F1") + "," + point.x2.ToString("F1") + ") ==> z = " + valueFunZ.ToString("F1"));
                    }
                    else
                        Console.WriteLine("(" + point.x1.ToString("F1") + "," + point.x2.ToString("F1") + ") ==> z = ##");
                }

                if (problemStateZ)
                    Console.WriteLine("MaxFunZ = " + ZFunController.MaxFun(resFunZ).ToString("F1"));
                else
                    Console.WriteLine("MinFunZ = " + ZFunController.MinFun(resFunZ).ToString("F1"));
                Console.WriteLine("-------------------------------------------------\n");
            }
        }



        public static ZFun EnterZFunction()
        {
            ZFun zFun = new ZFun();
            string input = Console.ReadLine();
            Double.TryParse(input, out double value);
            zFun.x1 = value;
            input = Console.ReadLine();
            Double.TryParse(input, out value);
            zFun.x2 = value;

            return zFun;
        }

        private static int EnterNumberOfConstraints()
        { 
            flag:
            string input = Console.ReadLine();
            bool IsNumeric = int.TryParse(input, out int numberOfConstraints);
            if (!IsNumeric)
            {
                goto flag;
            }
            return numberOfConstraints;
        }

        private static bool EnterStateOfProblemMaxOrMin()
        {
            bool stateZ = false;
            flag:
            string input = Console.ReadLine();
            if (input == "max")
            {
                stateZ = true;
            }
            else if (input == "min")
            {
                stateZ = false;
            }
            else
            {
                Console.WriteLine("Please choose (max or min): ");
                goto flag;
            }
            return stateZ;
        }

        private static List<Constraint> EnterConstraint(int numberOfConstraints)
        {
            List<Constraint> constraints = new List<Constraint>();
            double[] temp;
            for (int i = 0; i < numberOfConstraints; i++)
            {
                Console.WriteLine($"Please enter constraint of number {i+1}.");
                temp = new double[3];
                for (int j = 0; j < 3; j++)
                {
                    var input = Console.ReadLine();
                    double.TryParse(input, out temp[j]);

                }
                constraints.Add(new Constraint(temp[0], temp[1], temp[2]));
            }
            return constraints;
        }

        

        

    }
}

        
