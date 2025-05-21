using Lesson5.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Data.Repositories
{
    public class PilotRepository
        //בשכבה זו נבצע רק לוגיקה שקשורה למסד התנונים בלבד
    {
        private readonly DataContext _dataContext;
        public PilotRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Pilot> GetPilots()
        {
            return _dataContext.Pilots.ToList();
        }

        public Pilot? GetPilotById(int id)
        {
            return _dataContext.Pilots.FirstOrDefault(f => f.Id == id);
        }

        public void AddPilot(Pilot pilot)
        {
            _dataContext.Pilots.Add(pilot);
            _dataContext.SaveChanges();
        }

        public void RemovePilot(int id)
        {
            var p = GetPilotById(id);
            _dataContext.Remove(p);
            _dataContext.SaveChanges();
        }
        public void UpdatePilot(Pilot pilot)
        {
            _dataContext.Update(pilot);
            _dataContext.SaveChanges();
        }
    }
}
