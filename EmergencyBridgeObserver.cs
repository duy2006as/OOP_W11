/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Observer dong vai tro cau noi giua he thong giam sat va Mediator dieu phoi thiet bi
public sealed class EmergencyBridgeObserver : IAlertObserver
{
    private readonly IEmergencyMediator mediator;

    public EmergencyBridgeObserver(IEmergencyMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    public string ObserverName => "EmergencyBridgeObserver";

    public void Update(AlertEvent alertEvent)
    {
        if (alertEvent.Severity == "WARNING")
        {
            Console.WriteLine("CAU NOI KHAN CAP: Phat hien su kien nguy hiem - Chuyen tiep su kien FIRE_DETECTED den Mediator");
            mediator.Notify(this, "FIRE_DETECTED");
        }
    }
}
