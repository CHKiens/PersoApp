using Microsoft.EntityFrameworkCore;
using PersoApp.Interfaces;
using PersoApp.Models;
using System.Linq;

namespace PersoApp.Services {
    public class LocationService : ILocation {

        private PersoAppDBContext _Context;
        public LocationService(PersoAppDBContext context)
        {
            _Context = context;
        }

        public List<Location> GetAllLocations()
        {
            return _Context.Locations.ToList();
        }
        public Location GetLocation(int id) 
        {
            return _Context.Locations.Find(id);
        }
        public void AddLocation(Location location)
        {
            _Context.Locations.Add(location);
            _Context.SaveChanges();
        }
        public void DeleteLocation(int id)
        {
            _Context.Locations.Remove(GetLocation(id));
            _Context.SaveChanges();
        }
        public void UpdateLocation(Location location)
        {
            _Context.Locations.Update(location);
            _Context.SaveChanges();
        }

    }
}
