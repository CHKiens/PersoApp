using PersoApp.Models;

namespace PersoApp.Interfaces {
    public interface ILocation {
        public List<Location> GetAllLocations();
        public void DeleteLocation(int id);
        public Location GetLocation(int id);
        public void AddLocation(Location location);
        public void UpdateLocation(Location location);
    }
}
