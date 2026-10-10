// What I did to exceed the requirements:
// - I added levels. Every 1000 points you go up one level and get a new title
//   (Beginner, Apprentice, Warrior, Champion and Eternal Hero). When you level up
//   the program shows a message.
// - I made a new type of goal, the Negative Goal, for bad habits. When you record it
//   you lose points instead of win.
// - If you try to record a simple or checklist goal that is already done, the program
//   tells you and doesn't give the points again.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}