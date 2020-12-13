using System.ComponentModel.DataAnnotations;

namespace RunPerfomancesWebApp.Models
{
    public class RunPerfomances
    {
        [Required]
        [Range(0, 30, ErrorMessage = "Not correct range for Pace")]
        public double Pace { get; set; }
        [Required]
        [Range(0, 25, ErrorMessage = "Not correct range for Speed")]
        public double Speed { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Not correct range for Distance")]
        public double Distance { get; set; }
        [Required]
        [Range(0, 5000, ErrorMessage = "Not correct range for Time")]
        public double Time { get; set; }
        public double Hours { get; set; }
        public double Minutes { get; set; }

    }
}