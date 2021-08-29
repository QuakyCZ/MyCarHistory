using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyCarHistory.Utils.DatabaseEntities {
    [Table("ServiceLog")]
    class ServiceLog {

        /// <summary>
        /// Id of the Service
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// The car that was at service
        /// </summary>
        public Car Car { get; set; }

        /// <summary>
        /// The type of the service
        /// </summary>
        public ServiceType Type { get; set; }

        /// <summary>
        /// The price of the service
        /// </summary>
        public Int64 Price { get; set; }

        /// <summary>
        /// The date of the service
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Details of the service. E.G. Switch wheels.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Checks if other is equal to this.
        /// </summary>
        /// <param name="other">The other ServiceLog</param>
        /// <returns>True if all fields are same.</returns>
        public bool Equals(ServiceLog other) {
            return Id == other.Id && Car == other.Car && Type == other.Type && Price == other.Price && Date == other.Date && Details == other.Details;
        }
    }
}
