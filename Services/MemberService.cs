using System.Text.Json;
using Library_Management_System.Menu;
using Library_Management_System.Models;
using Library_Management_System.Utils;
using Spectre.Console;

namespace Library_Management_System.Services;

public class MemberService
{
    public static void addNewMember()
    {
        var member = new Member();

        // Nhập thông tin thành viên
        while (true)
        {
            member.Id = AnsiConsole.Ask<string>("Nhập mã thành viên (ID):");
            if (!IsMemberIdExists(member.Id))
            {
                break; // Nếu ID chưa tồn tại, thoát khỏi vòng lặp
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Mã thành viên đã tồn tại. Vui lòng nhập mã khác.[/]");
            }
        }
        member.Name = AnsiConsole.Ask<string>("Nhập tên thành viên:");
        member.Email = AnsiConsole.Ask<string>("Nhập email:");
        member.PhoneNumber = AnsiConsole.Ask<string>("Nhập số điện thoại:");
        member.Address = AnsiConsole.Ask<string>("Nhập địa chỉ:");
        
        
        string filePath = Path.Combine(uDirectory.Get_Data_Members_Directory(), "Members.json");
        
        uFileInteraction.SaveMemberToFile(member, filePath);

        // Hiển thị thông báo thành công
        MenuUtils.ShowSuccessMessage($"Đã lưu thông tin thành viên '{member.Name}' vào file thành công!");
    }
    
    public static List<Member> LoadAllMembers()
    {
        List<Member> allMembers = new List<Member>();

        string filePath = Path.Combine(uDirectory.Get_Data_Members_Directory(), "Members.json");

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            if (!string.IsNullOrEmpty(json))
            {
                allMembers = JsonSerializer.Deserialize<List<Member>>(json) ?? new List<Member>();
            }
        }

        return allMembers;
    }
    
    public static void DisplayAllMembers()
    {
        var members = LoadAllMembers();
        if (members.Count == 0)
        {
            // AnsiConsole.MarkupLine("[red]Chưa có thành viên nào được thêm vào.[/]");
            MenuUtils.ShowErrorMessage("Chưa có thành viên nào được thêm vào.");
            return;
        }

        
        var table = new Table();
        table.AddColumn("Mã thành viên (ID)");
        table.AddColumn("Tên thành viên");
        table.AddColumn("Email");
        table.AddColumn("Số điện thoại");
        table.AddColumn("Địa chỉ");

        foreach (var member in members)
        {
            table.AddRow(member.Id, member.Name, member.Email, member.PhoneNumber, member.Address);
        }

        AnsiConsole.Write(table);
        AnsiConsole.MarkupLine("[dim]Nhấn Enter để tiếp tục...[/]");
        Console.ReadLine();
    }
    
    public static void EditMember()
    {
        MemberService.DisplayAllMembers();
        var members = LoadAllMembers();
        if (members.Count == 0)
        {
            MenuUtils.ShowErrorMessage("Không có thành viên nào để sửa.");
            return;
        }

        string memberId = AnsiConsole.Ask<string>("Nhập mã thành viên (ID) cần sửa:");
        var member = members.FirstOrDefault(m => m.Id == memberId);
        
        if (member == null)
        {
            MenuUtils.ShowErrorMessage($"Không tìm thấy thành viên với mã ID: {memberId}");
            return;
        }

        // Nhập thông tin mới
        member.Name = AnsiConsole.Ask<string>("Nhập tên thành viên mới:", member.Name);
        member.Email = AnsiConsole.Ask<string>("Nhập email mới:", member.Email);
        member.PhoneNumber = AnsiConsole.Ask<string>("Nhập số điện thoại mới:", member.PhoneNumber);
        member.Address = AnsiConsole.Ask<string>("Nhập địa chỉ mới:", member.Address);

        string filePath = Path.Combine(uDirectory.Get_Data_Members_Directory(), "Members.json");
        
        uFileInteraction.SaveMemberToFile(member, filePath);

        // Hiển thị thông báo thành công
        MenuUtils.ShowSuccessMessage($"Đã cập nhật thông tin thành viên '{member.Name}' thành công!");
    }
    
    public static void DeleteMember()
    {
        MemberService.DisplayAllMembers();
        var members = LoadAllMembers();
        if (members.Count == 0)
        {
            MenuUtils.ShowErrorMessage("Không có thành viên nào để xóa.");
            return;
        }

        string memberId = AnsiConsole.Ask<string>("Nhập mã thành viên (ID) cần xóa:");
        var member = members.FirstOrDefault(m => m.Id == memberId);
        
        if (member == null)
        {
            MenuUtils.ShowErrorMessage($"Không tìm thấy thành viên với mã ID: {memberId}");
            return;
        }

        string trashcanFilePath = Path.Combine(uDirectory.Get_TrashCan_Directory(), "DeletedMembers.json");
        uFileInteraction.SaveMemberToFile(member, trashcanFilePath);
        members.Remove(member);

        string filePath = Path.Combine(uDirectory.Get_Data_Members_Directory(), "Members.json");
        
        // Lưu lại danh sách thành viên đã cập nhật (đã xóa thành viên)
        string updatedJson = System.Text.Json.JsonSerializer.Serialize(members, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, updatedJson);
        

        // Hiển thị thông báo thành công
        MenuUtils.ShowSuccessMessage($"Đã xóa thành viên '{member.Name}' thành công!");
    }
    
    public static bool IsMemberIdExists(string id)
    {
        var members = uFileInteraction.LoadAllMembers();
        return members.Any(m => m.Id == id);
    }
}