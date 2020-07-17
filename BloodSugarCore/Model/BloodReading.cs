using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BloodSugarCore.Model
{
    public class BloodReading
    {
        [Key]
        public int ReadingID { get; set; }

        public string ReadingDate { get; set; }
        public string ReadingTime { get; set; }
        public decimal ReadingValue { get; set; }
    }
}
