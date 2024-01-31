using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class TaskManager
{
    public class Task
    {
        public string TaskName { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }

    private static List<Task> tasks = new List<Task>();

    public static void AddTask()
    {
        var itemTask = new Task();
        Console.WriteLine("Tên nhiệm vụ ");
        itemTask.TaskName = Console.ReadLine();
        Console.WriteLine("Độ ưu tiên ");
        itemTask.Priority = int.Parse(Console.ReadLine());
        Console.WriteLine("Mô tả ");
        itemTask.Description = Console.ReadLine();
        Console.WriteLine("Trạng thái ");
        itemTask.Status = Console.ReadLine();
        tasks.Add(itemTask);
    }
    public static void DeleteTask()
    {
        DisplayAllTasks();
        Console.WriteLine("Chọn nhiệm vụ muốn xóa: ");
        int position = int.Parse(Console.ReadLine());
        if (position >= 0 && position < tasks.Count)
        {
            tasks.RemoveAt(position);
            Console.WriteLine("Đã xóa nhiệm vụ");
        }
        else
        {
            Console.WriteLine("Không hợp lệ");
        }
    }
    public static void UpdateTaskStatus()
    {
        DisplayAllTasks();
        Console.WriteLine("Chọn nhiệm vụ muốn cập nhật (theo tên): ");
        var taskName = Console.ReadLine();     
        Console.WriteLine("Trạng thái");
        var newStatus = Console.ReadLine();
        Task task = tasks.Find(t => t.TaskName == taskName);
        if (task != null)
        {
            task.Status = newStatus;
            Console.WriteLine("Đã cập nhật trạng thái.");
        }
        else
        {
            Console.WriteLine("Không hợp lệ");
        }
    }
    public static List<Task> SearchTasks()
    {
        Console.WriteLine("Nhập tên nhiệm vụ muốn tìm hoặc mức độ ưu tiên ");
        var keyword = Console.ReadLine();

        List<Task> searchResults = tasks.FindAll(t => t.TaskName.Contains(keyword) || t.Priority.ToString().Contains(keyword));

        if (searchResults.Count > 0)
        {
            Console.WriteLine($"Kết quả tìm kiếm cho '{keyword}':");
            foreach (var result in searchResults)
            {
                Console.WriteLine($"Task: {result.TaskName}, Priority: {result.Priority}, Status: {result.Status}");
            }
        }
        else
        {
            Console.WriteLine($"Không tìm thấy nhiệm vụ có tên chứa '{keyword}'.");
        }

        return searchResults;
    }
    public static void DisplayTasksByPriority()
    {
        var sortedTasks = tasks.OrderByDescending(t => t.Priority);
        foreach (var task in sortedTasks)
        {
            Console.WriteLine($"Task: {task.TaskName}, Priority: {task.Priority}, Status: {task.Status}");
        }
    }

    public static void DisplayAllTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.TaskName}, Priority: {task.Priority}, Description: {task.Description}, Status: {task.Status}");
        }
    }
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("Chọn lệnh muốn thực thi");
            Console.WriteLine("1: Thêm nhiệm vụ mới");
            Console.WriteLine("2: Xóa nhiệm vụ");
            Console.WriteLine("3: Cập nhật nhiệm vụ");
            Console.WriteLine("4: Tìm kiếm theo tên hoặc độ ưu tiên");
            Console.WriteLine("5: Sắp xếp độ ưu tiên giảm dần");
            Console.WriteLine("6: Hiển thị danh sách nhiệm vụ");
            Console.WriteLine("0: Exit");
            var n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    DeleteTask();
                    break;
                case 3:
                    UpdateTaskStatus();
                    break;
                case 4:
                   SearchTasks();
                    break;
                case 5:
                    DisplayTasksByPriority();
                    break;
                case 6:
                    DisplayAllTasks();
                    break;
                case 0:
                    Console.WriteLine("Thoát khỏi ứng dụng.");
                    return;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    break;
            }
        }
    }
}