using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class ParticipantModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100.")]
        public string Name { get; set; }
    }
}