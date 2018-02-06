using System;
using System.Collections.Generic;
using System.Text;

namespace CandyMarket
{
    public class User
    {
        readonly DatabaseContext _db;

        public string Name { get; set; }

        public User(string name, DatabaseContext db)
        {
            Name = name;
            _db = db;
        }

        public void AddCandy(CandyType typeOfCandy, int howMany)
        {
            _db.SaveNewCandy(Name, typeOfCandy, howMany);
        }

        public void GiveCandy(CandyType type, string receiver)
        {
            _db.RemoveNewCandy(Name, type, 1);
            _db.SaveNewCandy(receiver, type, 1);
        }
    }
}
