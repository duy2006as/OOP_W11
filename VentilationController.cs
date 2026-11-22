/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Bo dieu khien he thong thong gio va hut khoi phong may
public sealed class VentilationController
{
    public string CurrentMode { get; private set; } = "NORMAL";

    // Bat che do hut khoi cong suat cuc dai
    public void StartMaxExtraction()
    {
        CurrentMode = "MAX_EXTRACTION";
        Console.WriteLine("HE THONG THONG GIO: Kich hoat che do hut khoi cuc dai de lam sach khong khi");
    }

    // Dat che do thong gio tieu chuan
    public void SetNormal()
    {
        CurrentMode = "NORMAL";
        Console.WriteLine("HE THONG THONG GIO: Chuyen ve che do thong gio binh thuong");
    }

    // Tat he thong thong gio
    public void TurnOff()
    {
        CurrentMode = "OFF";
        Console.WriteLine("HE THONG THONG GIO: Da tat hoan toan he thong quat gio");
    }
}
