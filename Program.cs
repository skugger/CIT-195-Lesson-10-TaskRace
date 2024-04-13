using System.Threading.Tasks;

namespace CIT_195_Lesson_10_TaskRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Achtung, fertig, los...");
            int t1Location = 0;
            int t2Location = 0;
            int t3Location = 0;
            int t4Location = 0;
            int t5Location = 0;

            //Creating Threads
            Task t1 = Task.Run (() =>
            {
                Thread.CurrentThread.Name = "Racer X";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t1Location);
                }

            });
            Task t2 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Spritle";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t2Location);

                }
            });
            Task t3 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Speed Racer";
                Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t3Location);

                }
            }); 
            Task t4 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Trixie";
                Thread.CurrentThread.Priority = ThreadPriority.Highest;
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t4Location);

                }
            }); 
            Task t5 = Task.Run(() =>
            {
                Thread.CurrentThread.Name = "Pops Racer";
                for (int i = 0; i < 100; i++)
                {
                    if (t1Location < 100 && t2Location < 100 && t3Location < 100 && t4Location < 100 && t5Location < 100)
                        MoveIt(ref t5Location);

                }
            });

            // Executing the methods
            // t1.Start();
            // t2.Start();
            // t3.Start();
            // t4.Start();
            // t5.Start();
            Task.WaitAny(t5);
            Console.WriteLine("Race has ended");
        }
        static void MoveIt(ref int location)
        {
            location++;
            Console.WriteLine($"{Thread.CurrentThread.Name} location={location}");
            if (location >= 100)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} is the winner");
                return;
            }
        }

    }
}
