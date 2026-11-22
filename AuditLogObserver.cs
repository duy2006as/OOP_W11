/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Observer ghi nhat ky an toan he thong de phuc vu kiem toan va tra cuu lich su
public sealed class AuditLogObserver : IAlertObserver
{
    private readonly List<AlertEvent> logRecords = new();

    public string ObserverName => "AuditLogObserver";

    public IReadOnlyList<AlertEvent> LogRecords => logRecords.AsReadOnly();

    public void Update(AlertEvent alertEvent)
    {
        logRecords.Add(alertEvent);
        Console.WriteLine($"NHAT KY AUDIT: Luu tru su kien muc {alertEvent.Severity} tu {alertEvent.SensorName} luc {alertEvent.OccurredAt:HH:mm:ss}");
    }
}
