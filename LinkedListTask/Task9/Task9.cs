namespace Lab3.LinkedListTask.Task10;

public class Task9
{
    public static CustomLinkedList<int> Run()
    {
        var filePath = "/Users/slava/Documents/Образование/ЧелГУ/Курс 2/ААС/Lab3/LinkedListTask/Task9/input.txt";
        var lines = File.ReadAllLines(filePath);

        var listL = new CustomLinkedList<int>();
        var listE = new CustomLinkedList<int>();
        
        foreach (var numStr in lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries))
            listL.AddLast(int.Parse(numStr));
        foreach (var numStr in lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries))
            listE.AddLast(int.Parse(numStr));
        
        Console.WriteLine("Список L до объединения:");
        listL.Print();

        Console.WriteLine("Список E:");
        listE.Print();
        
        listL.AppendList(listE);

        Console.WriteLine("После объединения:");
        listL.Print();
        return listL;
    }
}