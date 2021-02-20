using ReportManager.BLL.Interfaces;
using ReportManager.BLL.Services;
using ReportManager.UL.Controllers.Interfaces;

namespace ReportManager.UL.Controllers
{
    public class TimerController : ITimerController
    {
        private ITimerService _service;

        public TimerController(ITimerService service)
            => _service = service;
        
        public void NextDay()
            => _service.NextDay();

        public void NextWeek()
            => _service.NextMonth();
    }
}