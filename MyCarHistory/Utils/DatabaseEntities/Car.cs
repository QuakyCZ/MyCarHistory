using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCarHistory.Utils.DatabaseEntities {
    [Table("Car")]
    class Car {
        public Int64 Id { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        public Int64 ManufactureYear { get; set; }

        public List<ServiceLog> serviceLogs { get; set; }

        public bool Equals(Car other) {
            return Id == other.Id && Brand == other.Brand && Model == other.Model && ManufactureYear == other.ManufactureYear;
        }
    }
}
