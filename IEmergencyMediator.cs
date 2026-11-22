/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Hop dong dieu phoi giua cac thiet bi ung pho su co khong phu thuoc truc tiep nhau
public interface IEmergencyMediator
{
    // Nhan thong bao su kien tu nguon phat va dieu phoi cac thiet bi lien quan
    void Notify(object sender, string emergencyEvent);
}
