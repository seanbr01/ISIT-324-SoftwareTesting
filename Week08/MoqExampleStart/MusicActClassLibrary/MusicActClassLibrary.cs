using System;
using System.Collections.Generic;

namespace MusicActClassLibrary
{
    public interface IRepositoryOMusicActs
    {
        List<MusicAct> GetActs();
        MusicAct FindAct(string name);
    }

    public class RepositoryOMusicActs : IRepositoryOMusicActs
    {
        public List<MusicAct> GetActs()
        {
            // Imagine that this method accesses a database to find 
            // bands to list.  

            throw new NotImplementedException();

            //var listOfActs = new List<MusicAct>();
            //listOfActs.Add(
            //    new MusicAct
            //    {
            //        Name = "No Band",
            //        Genre = "None",
            //        FavoriteSong = "Sounds of Silence",
            //        StraightOutta = "Kent"
            //    });

            //return listOfActs;

            // I know, it's hard, but keep imagining.
        }

        public MusicAct FindAct(string bandToFind)
        {
            // Imagine that this method accesses the database to find a 
            // specific band by name.
            throw new NotImplementedException();

        }
    }

    public class MusicAct
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string FavoriteSong { get; set; }
        public string StraightOutta { get; set; }
    }


    public class MusicActController
    {
        IRepositoryOMusicActs repository;
        public MusicActController(IRepositoryOMusicActs repository)
        {
            this.repository = repository;
        }

        public List<MusicAct> FindByGenre(string genre)
        {
            List<MusicAct> resultSet = new List<MusicAct>();

            var acts = this.repository.GetActs();

            foreach (var act in acts)
            {
                if (act.Genre.ToUpper() == genre.ToUpper())
                {
                    resultSet.Add(act);
                }
            }

            return resultSet;

        }
    }



}
