using Microsoft.EntityFrameworkCore;
using PersoApp.Interfaces;
using PersoApp.Models;

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
    }
}
