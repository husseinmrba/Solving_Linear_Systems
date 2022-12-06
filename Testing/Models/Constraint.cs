namespace Testing.Models
{
    public class Constraint
    {
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double c { get; set; }
        public Constraint()
        {

        }
        public Constraint(double x1, double x2, double c)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.c = c;
        }
    }
}

        
