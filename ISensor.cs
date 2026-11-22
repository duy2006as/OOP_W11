/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Giao dien chuan ISensor cho tat ca cac loai cam bien trong he thong
public interface ISensor
{
    // Doc gia tri hien tai cua cam bien da duoc chuan hoa
    double ReadValue();

    // Lay don vi do luong cua cam bien
    string GetUnit();
}
