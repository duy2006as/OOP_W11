/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Adapter chuyen doi giao dien va thang do cua LegacySmokeDetector sang ISensor
public sealed class SmokeSensorAdapter : ISensor
{
    private readonly LegacySmokeDetector legacy;

    public SmokeSensorAdapter(LegacySmokeDetector legacy)
    {
        this.legacy = legacy ?? throw new ArgumentNullException(nameof(legacy));
    }

    // Doc gia tri sau khi chuyen doi tu 0 den 1000 sang phan tram tu 0 den 100
    public double ReadValue()
    {
        return legacy.GetSmokeLevel() / 100.0;
    }

    public string GetUnit() => "% smoke";

    public LegacySmokeDetector Legacy => legacy;
}
