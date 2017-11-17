using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.ViewModels
{
    public class ProjectViewModel
    {
        private readonly List<SeatViewModel> _availableSeats;
        

        public ProjectViewModel()
        {
            _availableSeats = new List<SeatViewModel>();
            _availableSeats.Add(new SeatViewModel()
            {
                Id = -1,
                PositionName = "-"
            });
        }

        public int SelectedProjectId { get; set; }
        public int SelectedSeatId { get; set; }
        public int HoursNeed { get; set; }
        public bool IsOpen { get; set; }
        public DateTime Deadline { get; set; }
        public string Location { get; set; }
        public int MinimumSkillLevel { get; set; }

        public List<SeatViewModel> AvailableSeats { get { return _availableSeats; } }
    }
}
