using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace az204_funcapp;

public class TimerLoggerFunction
{
    private readonly ILogger<TimerLoggerFunction> _logger;

    public TimerLoggerFunction(ILogger<TimerLoggerFunction> logger)
    {
        _logger = logger;
    }

    [Function(nameof(TimerLoggerFunction))]
    public void Run([TimerTrigger("0 * */5 * * *")] TimerInfo timerInfo)
    {
        _logger.LogInformation("Timer trigger executed at: {TimeUtc}", DateTime.UtcNow);

        if (timerInfo.ScheduleStatus is not null)
        {
            _logger.LogInformation("Next occurrence: {Next}", timerInfo.ScheduleStatus.Next);
        }
    }
}
