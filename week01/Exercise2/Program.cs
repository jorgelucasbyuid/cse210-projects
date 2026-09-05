Console.Write("What is your grade percentage? ");
string answer = Console.ReadLine();
int percent = int.Parse(answer);

if (percent >= 90)
{
    Console.WriteLine("A");
}
else if (percent >= 80)
{
    Console.WriteLine("B");
}
else if (percent >= 70)
{
    Console.WriteLine("C");
}
else if (percent >= 60)
{
    Console.WriteLine("D");
}
else
{
    Console.WriteLine("F");
}
