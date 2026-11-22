/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Observer mo phong gui thu dien tu khan cap den can bo quan ly
public sealed class EmailAlertObserver : IAlertObserver
{
    private readonly string recipientEmail;

    public EmailAlertObserver(string recipientEmail = "admin@campus.edu.vn")
    {
        this.recipientEmail = recipientEmail;
    }

    public string ObserverName => "EmailAlertObserver";

    public void Update(AlertEvent alertEvent)
    {
        Console.WriteLine($"EMAIL CANH BAO: Gui thu dien tu den {recipientEmail} - Phat hien muc {alertEvent.Severity} tai {alertEvent.SensorName} voi gia tri {alertEvent.Value:F1} {alertEvent.Unit}");
    }
}
