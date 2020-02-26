using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using MusicActClassLibrary;

namespace MoqExample
{
    class Driver
    {
        static void Main(string[] args)
        {
            var rep = new RepositoryOMusicActs();
            var musicActController = new MusicActController(rep);

            Write("Enter a genre: ");
            string genre = ReadLine();
            List<MusicAct> result = musicActController.FindByGenre(genre);

            if (result.Count == 0)
            {
                WriteLine($"No bands we care about are in the genre {genre}.");
            }
            else
            {
                WriteLine($"{result.Count} bands are in the {genre} genre:");
                foreach (MusicAct act in result)
                {
                    WriteLine($"{act.Name}, straight outta {act.StraightOutta}");
                }
            }
            ReadKey();

        }
    }
}
