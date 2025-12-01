const int max = 100;
const int min = 0;
int currentValue = 50;
int counter = 0;

List<Rotation> rotations = [];

try
{
    var lines = File.ReadAllLines("input.txt");

    foreach (var line in lines)
    {
        var direction = line[0];
        var turns = int.Parse(line[1..]);

        rotations.Add(new Rotation { Direction = direction, Turns = turns });
    }
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex);
}

foreach (var rotation in rotations)
{
    Console.WriteLine($"Currently at {currentValue}");
    Console.WriteLine($"Turning {rotation.Direction} {rotation.Turns} turns");

    if (rotation.Direction == 'R')
    {
        for (int i = 0; i < rotation.Turns; i++)
        {
            if (currentValue == max)
            {
                currentValue = min;
            }

            currentValue++;

            if (currentValue == max)
            {
                currentValue = min;
            }
        }
    }
    else if (rotation.Direction == 'L')
    {
        for (int i = 0; i < rotation.Turns; i++)
        {
            if (currentValue == min)
            {
                currentValue = max;
            }

            currentValue--;

            if (currentValue == min && i > 0)
            {
                currentValue = max;
            }
        }
    }

    if (currentValue == min || currentValue == max)
    {
        counter++;
    }
}

Console.WriteLine($"Password is {counter}");

class Rotation
{
    public char Direction { get; set; }
    public int Turns { get; set; }
}