/************************************************
 * Sinh viên: Hoàng Đình Duy
 * Mã sinh viên: 202418887
 ************************************************/

using System;
using CampusSafetyHub;

// Chuong trinh Console thuc hien kiem thu tuong tac cho he thong Campus Safety Hub
class Program
{
    private static readonly SensorMonitor monitor = new();
    private static readonly Alarm alarm = new();
    private static readonly DoorController door = new();
    private static readonly VentilationController ventilation = new();
    private static readonly EmergencyMediator mediator = new(alarm, door, ventilation);

    private static readonly DashboardObserver dashboard = new();
    private static readonly EmailAlertObserver email = new();
    private static readonly AuditLogObserver auditLog = new();
    private static readonly EmergencyBridgeObserver bridge = new(mediator);

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        // Dang ky mac dinh cac observer ban dau
        monitor.Attach(dashboard);
        monitor.Attach(email);
        monitor.Attach(auditLog);
        monitor.Attach(bridge);

        bool running = true;
        while (running)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("================================================================================");
            Console.WriteLine("          HE THONG GIAM SAT AN TOAN PHONG MAY - CAMPUS SAFETY HUB");
            Console.WriteLine("         Sinh vien: Hoang Dinh Duy - Ma sinh vien: 202418887");
            Console.WriteLine("================================================================================");
            Console.ResetColor();

            Console.WriteLine("DANH SACH CHUC NANG KIEM THU:");
            Console.WriteLine("1. Kiem thu Adapter - Chuyen doi cam bien khoi cu");
            Console.WriteLine("2. Kiem thu Observer - Dang ky va huy dang ky nguoi nhan canh bao");
            Console.WriteLine("3. Kiem thu Observer - Kiem tra nguong gia tri va phat canh bao");
            Console.WriteLine("4. Kiem thu Mediator - Dieu phoi thiet bi ung pho khan cap");
            Console.WriteLine("5. Kiem thu Tich hop toan he thong Campus Safety Hub");
            Console.WriteLine("0. Thoat chuong trinh");
            Console.WriteLine("================================================================================");
            Console.Write("Moi ban nhap lua chon tu 0 den 5: ");

            string? choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    TestAdapterPattern();
                    DungManHinh();
                    break;
                case "2":
                    TestObserverRegistration();
                    DungManHinh();
                    break;
                case "3":
                    TestObserverThresholds();
                    DungManHinh();
                    break;
                case "4":
                    TestMediatorCoordination();
                    DungManHinh();
                    break;
                case "5":
                    TestEndToEndIntegration();
                    DungManHinh();
                    break;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cam on ban da su dung chuong trinh. Tam biet.");
                    Console.ResetColor();
                    running = false;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lua chon khong hop le, vui long chi nhap so tu 0 den 5.");
                    Console.ResetColor();
                    DungManHinh();
                    break;
            }
        }
    }

    // Kiem thu Adapter Pattern: Nguoi dung tu nhap muc khoi 0 den 1000
    private static void TestAdapterPattern()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- KIEM THU 1: ADAPTER PATTERN - CHUYEN DOI CAM BIEN KHOI CU ---");
        Console.ResetColor();
        Console.WriteLine("Ban dang kiem tra lop SmokeSensorAdapter thuc thi ISensor.");
        Console.WriteLine("Thiet bi cu LegacySmokeDetector co thang do tu 0 den 1000.");
        Console.WriteLine("Giao dien chuan ISensor yeu cau tra ve phan tram tu 0 den 100 kem don vi % smoke.");
        Console.WriteLine();

        Console.Write("Moi ban tu nhap muc khoi goc cua thiet bi cu, tu 0 den 1000: ");
        string? input = Console.ReadLine();
        if (!int.TryParse(input, out int rawSmoke))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Du lieu nhap khong phai so nguyen hop le, su dung gia tri mac dinh la 735.");
            Console.ResetColor();
            rawSmoke = 735;
        }

        var legacy = new LegacySmokeDetector(rawSmoke);
        ISensor adapter = new SmokeSensorAdapter(legacy);

        Console.WriteLine();
        Console.WriteLine($"Gia tri doc truc tiep tu thiet bi cu: {legacy.GetSmokeLevel()}");
        Console.WriteLine($"Mo ta cua thiet bi cu: {legacy.GetDescription()}");
        Console.WriteLine($"Gia tri doc qua Adapter: {adapter.ReadValue():F2}");
        Console.WriteLine($"Don vi tra ve boi Adapter: {adapter.GetUnit()}");
    }

    // Kiem thu Observer Pattern: Quan ly danh sach Dang ky va Huy dang ky
    private static void TestObserverRegistration()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- KIEM THU 2: OBSERVER PATTERN - DANG KY VA HUY NGUOI NHAN ---");
        Console.ResetColor();
        Console.WriteLine("Hien thi danh sach cac Observer hien tai:");
        HienThiDanhSachObserver();

        Console.WriteLine();
        Console.WriteLine("Chon thao tac:");
        Console.WriteLine("1. Thu them DashboardObserver");
        Console.WriteLine("2. Thu them EmailAlertObserver");
        Console.WriteLine("3. Thu them AuditLogObserver");
        Console.WriteLine("4. Thu them EmergencyBridgeObserver");
        Console.WriteLine("5. Thu huy DashboardObserver");
        Console.WriteLine("6. Thu huy EmailAlertObserver");
        Console.WriteLine("7. Thu huy AuditLogObserver");
        Console.WriteLine("8. Thu huy EmergencyBridgeObserver");
        Console.Write("Moi ban nhap thao tac tu 1 den 8: ");

        string? subChoice = Console.ReadLine()?.Trim();
        Console.WriteLine();

        switch (subChoice)
        {
            case "1":
                XuLyDangKy(dashboard);
                break;
            case "2":
                XuLyDangKy(email);
                break;
            case "3":
                XuLyDangKy(auditLog);
                break;
            case "4":
                XuLyDangKy(bridge);
                break;
            case "5":
                XuLyHuy(dashboard);
                break;
            case "6":
                XuLyHuy(email);
                break;
            case "7":
                XuLyHuy(auditLog);
                break;
            case "8":
                XuLyHuy(bridge);
                break;
            default:
                Console.WriteLine("Thao tac khong hop le.");
                break;
        }

        Console.WriteLine();
        Console.WriteLine("Danh sach Observer sau thao tac:");
        HienThiDanhSachObserver();
    }

    private static void XuLyDangKy(IAlertObserver obs)
    {
        bool result = monitor.Attach(obs);
        if (result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Dang ky thanh cong observer: {obs.ObserverName}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Tu choi dang ky trung lap: Observer {obs.ObserverName} da ton tai trong he thong.");
            Console.ResetColor();
        }
    }

    private static void XuLyHuy(IAlertObserver obs)
    {
        bool result = monitor.Detach(obs);
        if (result)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Da huy thanh cong observer: {obs.ObserverName}");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Observer {obs.ObserverName} chua tung duoc dang ky, khong the huy.");
            Console.ResetColor();
        }
    }

    private static void HienThiDanhSachObserver()
    {
        if (monitor.RegisteredObservers.Count == 0)
        {
            Console.WriteLine("Hien khong co Observer nao trong danh sach.");
            return;
        }

        int index = 1;
        foreach (var obs in monitor.RegisteredObservers)
        {
            Console.WriteLine($"{index}. {obs.ObserverName}");
            index++;
        }
    }

    // Kiem thu Observer: Kiem tra nguong va phat su kien AlertEvent
    private static void TestObserverThresholds()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- KIEM THU 3: OBSERVER PATTERN - KIEM TRA NGUONG VA PHAT CANH BAO ---");
        Console.ResetColor();
        Console.WriteLine("Quy uoc nguong canh bao theo thiet ke:");
        Console.WriteLine("- Duoi 50 phan tram: Binh thuong, khong phat canh bao.");
        Console.WriteLine("- Tu 50 den duoi 70 phan tram: WARNING.");
        Console.WriteLine("- Tu 70 phan tram tro len: CRITICAL.");
        Console.WriteLine();

        Console.Write("Moi ban nhap ten cam bien, vi du KhuVucMayChu_A: ");
        string sensorName = Console.ReadLine()?.Trim() ?? "KhuVucMayChu_A";
        if (string.IsNullOrWhiteSpace(sensorName)) sensorName = "KhuVucMayChu_A";

        Console.WriteLine("Chon cach kiem tra gia tri:");
        Console.WriteLine("1. Nhap gia tri truc tiep qua cam bien chuan ISensor, phan tram 0 den 100");
        Console.WriteLine("2. Nhap gia tri thiet bi cu qua Adapter, thang do 0 den 1000");
        Console.Write("Moi ban chon 1 hoac 2: ");
        string? mode = Console.ReadLine()?.Trim();
        Console.WriteLine();

        if (mode == "1")
        {
            Console.Write("Moi ban nhap gia tri phan tram khoi, vi du 35 hoac 58 hoac 82: ");
            if (!double.TryParse(Console.ReadLine(), out double directVal)) directVal = 60.0;

            ISensor customSensor = new MockDirectSensor(directVal, "% smoke");
            Console.WriteLine($"Dang kiem tra cam bien {sensorName} voi gia tri {directVal:F1}%...");
            Console.WriteLine();
            monitor.CheckSensor(sensorName, customSensor);
        }
        else
        {
            Console.Write("Moi ban nhap muc khoi thiet bi cu tu 0 den 1000, vi du 300 hoac 600 hoac 850: ");
            if (!int.TryParse(Console.ReadLine(), out int rawVal)) rawVal = 850;

            var leg = new LegacySmokeDetector(rawVal);
            var adp = new SmokeSensorAdapter(leg);
            Console.WriteLine($"Dang kiem tra cam bien {sensorName} doc qua Adapter voi gia tri goc {rawVal}...");
            Console.WriteLine();
            monitor.CheckSensor(sensorName, adp);
        }
    }

    // Kiem thu Mediator: Dieu phoi cac thiet bi ung pho
    private static void TestMediatorCoordination()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- KIEM THU 4: MEDIATOR PATTERN - DIEU PHOI THIET BI UNG PHO ---");
        Console.ResetColor();
        Console.WriteLine("Mediator dieu phoi 3 thiet bi: Chuong bao dong, Bo dieu khien cua, Bo thong gio.");
        Console.WriteLine();
        HienThiTrangThaiThietBi();

        Console.WriteLine();
        Console.WriteLine("Moi ban chon su kien can gui den Mediator:");
        Console.WriteLine("1. Gui su kien bao chay FIRE_DETECTED");
        Console.WriteLine("2. Gui su kien an toan ALL_CLEAR");
        Console.Write("Moi ban chon 1 hoac 2: ");

        string? evtChoice = Console.ReadLine()?.Trim();
        Console.WriteLine();

        if (evtChoice == "1")
        {
            Console.WriteLine("Dang gui su kien FIRE_DETECTED toi EmergencyMediator...");
            mediator.Notify(typeof(Program), "FIRE_DETECTED");
        }
        else if (evtChoice == "2")
        {
            Console.WriteLine("Dang gui su kien ALL_CLEAR toi EmergencyMediator...");
            mediator.Notify(typeof(Program), "ALL_CLEAR");
        }
        else
        {
            Console.WriteLine("Lua chon su kien khong hop le.");
        }

        Console.WriteLine();
        Console.WriteLine("Trang thai cac thiet bi sau khi Mediator dieu phoi:");
        HienThiTrangThaiThietBi();
    }

    // Kiem thu Tich hop toan he thong
    private static void TestEndToEndIntegration()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- KIEM THU 5: TICH HOP TOAN HE THONG CAMPUS SAFETY HUB ---");
        Console.ResetColor();
        Console.WriteLine("Luong hoat dong: LegacySensor -> Adapter -> SensorMonitor -> Observers -> Bridge -> Mediator -> Thiet bi");
        Console.WriteLine();

        Console.Write("Moi ban nhap vi tri phong may can giam sat, vi du ServerRoom_01: ");
        string room = Console.ReadLine()?.Trim() ?? "ServerRoom_01";
        if (string.IsNullOrWhiteSpace(room)) room = "ServerRoom_01";

        Console.Write("Moi ban tu nhap muc khoi do duoc tu thiet bi cu, tu 0 den 1000: ");
        if (!int.TryParse(Console.ReadLine(), out int smokeInput)) smokeInput = 800;

        Console.WriteLine();
        Console.WriteLine($"Bat dau luong giam sat cho phong {room} voi muc khoi goc {smokeInput}...");
        Console.WriteLine("Trang thai thiet bi truoc xu ly:");
        HienThiTrangThaiThietBi();
        Console.WriteLine();

        var legacy = new LegacySmokeDetector(smokeInput);
        var adapter = new SmokeSensorAdapter(legacy);

        // Kich hoat quy trinh kiem tra
        monitor.CheckSensor(room, adapter);

        Console.WriteLine();
        Console.WriteLine("Trang thai thiet bi sau khi xu ly toan bo luong:");
        HienThiTrangThaiThietBi();
    }

    // Hien thi trang thai 3 thiet bi
    private static void HienThiTrangThaiThietBi()
    {
        string alarmStatus = alarm.IsActive ? "Dang hu coi khan cap" : "Dang tat";
        string doorStatus = door.AreDoorsUnlocked ? "Tat ca cac cua dang mo khoa" : "Tat ca cac cua dang khoa chot";
        string ventStatus = ventilation.CurrentMode switch
        {
            "MAX_EXTRACTION" => "Hut khoi cong suat cuc dai",
            "NORMAL" => "Thong gio tieu chuan binh thuong",
            "OFF" => "Quat gio dang tat hoan toan",
            _ => ventilation.CurrentMode
        };

        Console.WriteLine($"1. Chuong bao: {alarmStatus}");
        Console.WriteLine($"2. He thong cua: {doorStatus}");
        Console.WriteLine($"3. He thong thong gio: {ventStatus}");
    }

    private static void DungManHinh()
    {
        Console.WriteLine();
        Console.Write("Nhan phim Enter de tiep tuc...");
        Console.ReadLine();
    }

    // Lop mo phong cam bien truyen gia tri truc tiep cho muc dich kiem thu
    private sealed class MockDirectSensor : ISensor
    {
        private readonly double value;
        private readonly string unit;

        public MockDirectSensor(double value, string unit)
        {
            this.value = value;
            this.unit = unit;
        }

        public double ReadValue() => value;
        public string GetUnit() => unit;
    }
}
