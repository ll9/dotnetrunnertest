using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NsSqliteServer.Models
{
    public class Lichtpunkt
    {
        [Key]
        public string Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Ort { get; set; }
        public string Straße { get; set; }
    }
}
