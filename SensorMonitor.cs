/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Lop Subject quan ly danh sach observer, doc du lieu cam bien va phat canh bao
public sealed class SensorMonitor
{
    private readonly List<IAlertObserver> observers = new();

    // Danh sach cac observer dang dang ky de kiem tra va hien thi
    public IReadOnlyList<IAlertObserver> RegisteredObservers => observers.AsReadOnly();

    // Dang ky mot observer moi, ngan chan dang ky trung lap
    public bool Attach(IAlertObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        if (!observers.Contains(observer))
        {
            observers.Add(observer);
            return true;
        }

        return false;
    }

    // Huy dang ky mot observer da ton tai
    public bool Detach(IAlertObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);
        return observers.Remove(observer);
    }

    // Kiem tra gia tri cam bien, xac dinh muc do nguy hiem va kich hoat canh bao
    public void CheckSensor(string sensorName, ISensor sensor)
    {
        ArgumentNullException.ThrowIfNull(sensor);

        double value = sensor.ReadValue();

        // Quy uoc muc do: duoi 50 binh thuong, tu 50 den duoi 70 la WARNING, tu 70 tro len la CRITICAL
        string? severity = value switch
        {
            >= 70.0 => "CRITICAL",
            >= 50.0 => "WARNING",
            _ => null
        };

        if (severity is null)
        {
            Console.WriteLine($"CAM BIEN {sensorName}: Gia tri an toan {value:F1} {sensor.GetUnit()} - Khong can phat canh bao");
            return;
        }

        var alertEvent = new AlertEvent(
            sensorName,
            value,
            sensor.GetUnit(),
            severity,
            DateTime.Now);

        Notify(alertEvent);
    }

    // Phat su kien canh bao den tat ca observer tren ban sao ToArray
    private void Notify(AlertEvent alertEvent)
    {
        // Duyet tren ban sao mang ToArray de observer co the huy dang ky ma khong loi vong lap
        foreach (IAlertObserver observer in observers.ToArray())
        {
            try
            {
                observer.Update(alertEvent);
            }
            catch (Exception ex)
            {
                // Co lap ngoai le: mot observer loi khong lam anh huong cac observer khac
                Console.WriteLine($"LOI TAI OBSERVER {observer.ObserverName}: {ex.Message}");
            }
        }
    }
}
