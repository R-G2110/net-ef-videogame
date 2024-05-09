using System;
using System.Linq;
using System.Collections.Generic;

namespace net_ef_videogame
{
    public class VideogameManager
    {
        private readonly ApplicationDbContext _dbContext;

        public VideogameManager(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create
        public void AddVideogame(Videogame videogame)
        {
            _dbContext.Videogames.Add(videogame);
            _dbContext.SaveChanges();
        }

        public void AddSoftwareHouse(SoftwareHouse softwareHouse)
        {
            _dbContext.SoftwareHouses.Add(softwareHouse);
            _dbContext.SaveChanges();
        }

        // Read
        public Videogame GetVideogameById(int id)
        {
            return _dbContext.Videogames.FirstOrDefault(v => v.Id == id);
        }
        public List<Videogame> GetVideogameByName(string name)
        {
            return _dbContext.Videogames.Where(v => v.Name == name).ToList();
        }

        public SoftwareHouse GetSoftwareHouseById(int id)
        {
            return _dbContext.SoftwareHouses.FirstOrDefault(s => s.Id == id);
        }
        public List<SoftwareHouse> GetSoftwareHouseByName(string name)
        {
            return _dbContext.SoftwareHouses.Where(s => s.Name == name).ToList();
        }
        public List<Videogame> GetAllVideogames()
        {
            return _dbContext.Videogames.ToList();
        }

        public List<SoftwareHouse> GetAllSoftwareHouses()
        {
            return _dbContext.SoftwareHouses.ToList();
        }

        // Update
        public void UpdateVideogame(Videogame updatedVideogame)
        {
            var existingVideogame = _dbContext.Videogames.Find(updatedVideogame.Id);
            if (existingVideogame != null)
            {
                existingVideogame.Name = updatedVideogame.Name;
                existingVideogame.Overview = updatedVideogame.Overview;
                existingVideogame.ReleaseDate = updatedVideogame.ReleaseDate;
                existingVideogame.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        public void UpdateSoftwareHouse(SoftwareHouse updatedSoftwareHouse)
        {
            var existingSoftwareHouse = _dbContext.SoftwareHouses.Find(updatedSoftwareHouse.Id);
            if (existingSoftwareHouse != null)
            {
                existingSoftwareHouse.Name = updatedSoftwareHouse.Name;
                existingSoftwareHouse.PIva = updatedSoftwareHouse.PIva;
                existingSoftwareHouse.City = updatedSoftwareHouse.City;
                existingSoftwareHouse.Country = updatedSoftwareHouse.Country;
                existingSoftwareHouse.UpdatedAt = DateTime.Now;

                _dbContext.SaveChanges();
            }
        }

        // Delete
        public void DeleteVideogamebyId(int id)
        {
            var videogame = _dbContext.Videogames.Find(id);
            if (videogame != null)
            {
                _dbContext.Videogames.Remove(videogame);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteSoftwareHousebyId(int id)
        {
            var softwareHouse = _dbContext.SoftwareHouses.Find(id);
            if (softwareHouse != null)
            {
                _dbContext.SoftwareHouses.Remove(softwareHouse);
                _dbContext.SaveChanges();
            }
        }
        public void DeleteVideogamebyName(string name)
        {
            var videogame = _dbContext.Videogames.FirstOrDefault(v => v.Name == name);
            if (videogame != null)
            {
                _dbContext.Videogames.Remove(videogame);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteSoftwareHousebyName(string name)
        {
            var softwareHouse = _dbContext.SoftwareHouses.FirstOrDefault(s => s.Name == name);
            if (softwareHouse != null)
            {
                _dbContext.SoftwareHouses.Remove(softwareHouse);
                _dbContext.SaveChanges();
            }
        }

    }
}
