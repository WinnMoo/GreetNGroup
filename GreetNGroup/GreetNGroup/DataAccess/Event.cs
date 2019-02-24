﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreetNGroup.DataAccess
{
    [Table("Event")]
    public class Event
    {
        public Event() {}
        public Event(string userId, string eventId, DateTime startDate, string eventName)
        {
            UserId = userId;
            EventId = eventId;
            StartDate = startDate;
            EventName = eventName;
        }

        [Required, ForeignKey("User")]
        public virtual string UserId { get; set; }
        public User User { get; set; }

        [Key]
        public string EventId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public string EventName { get; set; }
    }
}