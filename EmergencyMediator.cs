/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

namespace CampusSafetyHub;

// Mediator dong vai tro trung tam dieu phoi thiet bi ung pho su co ma khong de chung phu thuoc nhau
public sealed class EmergencyMediator : IEmergencyMediator
{
    private readonly Alarm alarm;
    private readonly DoorController doorController;
    private readonly VentilationController ventilationController;

    public EmergencyMediator(Alarm alarm, DoorController doorController, VentilationController ventilationController)
    {
        this.alarm = alarm ?? throw new ArgumentNullException(nameof(alarm));
        this.doorController = doorController ?? throw new ArgumentNullException(nameof(doorController));
        this.ventilationController = ventilationController ?? throw new ArgumentNullException(nameof(ventilationController));
    }

    public Alarm Alarm => alarm;
    public DoorController DoorController => doorController;
    public VentilationController VentilationController => ventilationController;

    // Tiep nhan cac su kien tu he thong va dieu phoi hanh vi thiet bi tuong ung
    public void Notify(object sender, string emergencyEvent)
    {
        switch (emergencyEvent)
        {
            case "FIRE_DETECTED":
                Console.WriteLine("MEDIATOR: Nhan su kien bao chay FIRE_DETECTED - Bat dau dieu phoi cac thiet bi");
                alarm.Ring();
                doorController.LockAllDoors();
                ventilationController.TurnOff();
                break;

            case "ALL_CLEAR":
            case "RESET":
                Console.WriteLine("MEDIATOR: Nhan tin hieu an toan ALL_CLEAR - Thiet lap lai trang thai binh thuong");
                alarm.Stop();
                doorController.LockAllDoors();
                ventilationController.SetNormal();
                break;

            default:
                Console.WriteLine($"MEDIATOR: Su kien khong ro {emergencyEvent} - Khong thuc hien dieu phoi");
                break;
        }
    }
}
