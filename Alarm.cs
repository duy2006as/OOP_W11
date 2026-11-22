/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Thiet bi chuong bao dong khan cap
public sealed class Alarm
{
    public bool IsActive { get; private set; }

    // Kich hoat chuong bao dong
    public void Ring()
    {
        IsActive = true;
        Console.WriteLine("CHUONG BAO DONG: Da bat coi hu khan cap voi am luong toi da");
    }

    // Tat chuong bao dong
    public void Stop()
    {
        IsActive = false;
        Console.WriteLine("CHUONG BAO DONG: Da tat coi hu ve trang thai nghi");
    }
}
