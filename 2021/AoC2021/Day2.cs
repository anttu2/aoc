namespace AoC2021;
public class Day2
{
    public abstract class CalculationStrategyBase
    {
        protected int Depth { get; set; }
        protected int Horizontal { get; set; }
        public int Result => Depth * Horizontal;

        protected internal abstract void Forward(int distance);
        protected internal abstract void Up(int distance);
        protected internal abstract void Down(int distance);
    }

    public class Part1Strategy : CalculationStrategyBase
    {
        protected internal override void Forward(int distance)
        {
            Horizontal += distance;
        }

        protected internal override void Up(int distance)
        {
            Depth -= distance;
        }

        protected internal override void Down(int distance)
        {
            Depth += distance;
        }
    }
    
    public class Part2Strategy : CalculationStrategyBase
    {
        private int Aim { get; set; }

        protected internal override void Forward(int distance)
        {
            Horizontal += distance;
            Depth += distance * Aim;
        }

        protected internal override void Up(int distance)
        {
            Aim -= distance;
        }

        protected internal override void Down(int distance)
        {
            Aim += distance;
        }
    }

    public void RunInputOnStrategy(string[] testInput, CalculationStrategyBase strategy)
    {
        foreach (var movement in testInput)
        {
            var parts = movement.Split(" ");
            var direction = parts.First();
            var distance = Convert.ToInt32(parts.Last());

            switch (direction)
            {
                case "forward":
                     strategy.Forward(distance);
                    break;
                case "up":
                    strategy.Up(distance);
                    break;
                case "down":
                    strategy.Down(distance);
                    break;
                default:
                    throw new ArgumentException($"Unknown direction {direction}");
            }
        }
    }
}
