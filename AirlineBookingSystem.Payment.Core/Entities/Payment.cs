using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Payment.Core.Entities
{
    internal class Payment
    {
        public Guid Id { get; set; }
        public Guid? BookingId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
