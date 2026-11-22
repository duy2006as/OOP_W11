/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Hop dong nhan canh bao cho tat ca cac observer
public interface IAlertObserver
{
    // Ten dinh danh cua observer de phan biet va quan ly
    string ObserverName { get; }

    // Phuong thuc tiep nhan su kien canh bao tu SensorMonitor
    void Update(AlertEvent alertEvent);
}
