﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Notification.Core.Entities
{
    internal class Notification
    {
        public Guid Id { get; set; }
        public string? Recipient { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; }
        public DateTime? SentAt { get; set; }
    }
}
