using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace task.Models
{
    [MetadataType(typeof(TaskValidation))]
    public partial class Task
    {
       

    }
    public sealed class TaskValidation
    {
        [Required]
        
        public string name { get; set; }
        public string description { get; set; }

        [Required(ErrorMessage = "Enter the issued date.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dateCreated { get; set; }
        [Required(ErrorMessage = "Enter the issued date.")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> dateUpdated { get; set; }
    }
}