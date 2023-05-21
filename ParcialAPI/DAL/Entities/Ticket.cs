using System.ComponentModel.DataAnnotations;

namespace ParcialAPI.DAL.Entities
{
    public class Ticket
    {

        [Required]
        public Guid id { get; set; }

        public DateOnly useDate { get; set; }


        public bool isUsed { get; set; }


        public String entranceGate { get; set; }







    }
}
