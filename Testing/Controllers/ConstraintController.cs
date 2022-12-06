
using Testing.Models;

namespace Testing.Controllers
{
    internal class ConstraintController
    {

        public static double SlopeLine(Constraint line)
        {
            (Point firstPoint, Point secontPoint) = CoordinatesOfLine(line);
            var m = (secontPoint.x2 - firstPoint.x2) / (secontPoint.x1 - firstPoint.x1);
            return m;
        }

        public static (Point, Point) CoordinatesOfLine(Constraint line)
        {
            double x1 = line.c / line.x1;
            Point point1 = new Point(x1, 0);
            double x2 = line.c / line.x2;
            Point point2 = new Point(0, x2);

            return (point1, point2);
        }


        public static bool CheckConstraint(Point point, List<Constraint> constraints, bool problemStateZ)
        {
            bool check = true;
            foreach (var constraint in constraints)
            {
                if (problemStateZ && (!(((constraint.x1 * point.x1) + (constraint.x2 * point.x2)) <= constraint.c)))
                {
                    check = false;
                    break;
                }
                if ((!problemStateZ) && (!(((constraint.x1 * point.x1) + (constraint.x2 * point.x2)) >= constraint.c)))
                {
                    check = false;
                    break;
                }
            }
            if (check)
                return true;
            else
                return false;
        }

        



    }
}
