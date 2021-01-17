using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVSanitiser
{
    public class CityData
    {
        private string _name;
        private string _state;

        public CityData(string name, string state)
        {
            Name = name;
            State = state;
        }

        public string Name { get => _name; set => _name = value; }
        public string State { get => _state; set => _state = value; }
    }
}
