using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Models
{
    public class GymClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)] 
        public TimeSpan Duration { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime EndTime { get { return StartTime + Duration; } }


        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }
    }
}