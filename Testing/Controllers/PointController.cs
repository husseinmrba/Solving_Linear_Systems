
using Testing.Models;

namespace Testing.Controllers
{
    internal class PointController
    {
        public static List<Point> GeneratePointsOfIntersection(List<Constraint> connstraints)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < (connstraints.Count - 1); i++)
            {
                var firstLine = connstraints[i];
                for (int j = i + 1; j < connstraints.Count; j++)
                {
                    var secondLine = connstraints[j];
                    Point point;
                    if (ConstraintController.SlopeLine(firstLine) != ConstraintController.SlopeLine(secondLine))
                    {
                        point = IntersectionPoint(firstLine, secondLine);
                        points.Add(point);

                    }
                }
            }
            return points;
        }

        public static Point IntersectionPoint(Constraint firstLine, Constraint secondLine)
        {
            Point point = new Point();
            point.x2 = (((secondLine.x1 * firstLine.c) - (firstLine.x1 * secondLine.c))
                                                       /
                       ((secondLine.x1 * firstLine.x2) - (firstLine.x1 * secondLine.x2)));

            point.x1 = ((firstLine.c - (firstLine.x2 * point.x2)) / firstLine.x1);

            return point;
        }
    }
}
