/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Bo dieu khien he thong cua ra vao va cua thoat hiem phong may
public sealed class DoorController
{
    public bool AreDoorsUnlocked { get; private set; }

    // Mo khoa tat ca cac cua thoat hiem phuc vu so tan
    public void UnlockAllDoors()
    {
        AreDoorsUnlocked = true;
        Console.WriteLine("DIEU KHIEN CUA: Da mo khoa toan bo cua phong thoat hiem cho nguoi so tan");
    }

    // Khoa tat ca cac cua
    public void LockAllDoors()
    {
        AreDoorsUnlocked = false;
        Console.WriteLine("DIEU KHIEN CUA: Da dong va khoa chot an toan cac cua");
    }
}
