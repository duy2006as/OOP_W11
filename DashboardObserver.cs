/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Observer hien thi thong so truc quan len man hinh trung tam giam sat
public sealed class DashboardObserver : IAlertObserver
{
    public string ObserverName => "DashboardObserver";

    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine($"DASHBOARD: Cam bien {alertEvent.SensorName} ghi nhan {alertEvent.Value:F1} {alertEvent.Unit} - Muc do {alertEvent.Severity}");
    }
}
