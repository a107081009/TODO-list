//用List儲存代辦事項，List可以動態調整

var todos = new List<string>();

Console.WriteLine("您好!");

//bool判斷是否輸入E或e來結束這個選項的迴圈
bool shallExit = false;
while (!shallExit)
{
    Console.WriteLine();
    Console.WriteLine("請問您想要做什麼呢?");
    Console.WriteLine("按[A]來看所有代辦事項");
    Console.WriteLine("按[B]來增加代辦事項");
    Console.WriteLine("按[C]來刪除一項代辦事項");
    Console.WriteLine("按[D]結束應用程式");

    var userChoice = Console.ReadLine();

    //switch判斷輸入選項是否為選項中的字元
    switch (userChoice)
    {
        case "D":
        case "d":
            shallExit = true;
            Console.WriteLine();
            Console.WriteLine("結束");
            break;
        case "A":
        case "a":
            SeeAllTodos();
            break;
        case "B":
        case "b":
            AddTodo();
            break;
        case "C":
        case "c":
            RemoveTodo();
            break;
        default:
            Console.WriteLine();
            Console.WriteLine("無此選項，請重新輸入");
            break;
    }
}
Console.ReadKey();

//用方法體判別目前列表中有什麼代辦事項並逐一列出
void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        showNoTodosMessage();
        return;
    }
    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }

}


//用方法體將代辦事項資料判斷是否為空的或是是否為重複
void AddTodo()
{
    string description;
    do
    {
        Console.WriteLine();
        Console.WriteLine("輸入代辦事項");
        description = Console.ReadLine();
    }
    while (!IsDescriptionValid(description));

    todos.Add(description);
}

bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine();
        Console.WriteLine("輸入的代辦事項不可為空白");
        return false;
    }
    if (todos.Contains(description))
    {
        Console.WriteLine();
        Console.WriteLine("輸入的代辦事項不可重複");
        return false;
    }
    return true;
}

// 用方法體刪除不要的代辦事項
void RemoveTodo()
{
    if (todos.Count == 0)
    {
        showNoTodosMessage();
        return;
    }

    int index;
    do
    {
        Console.WriteLine();
        Console.WriteLine("選擇一項您想刪除的代辦事項");
        SeeAllTodos();
    } while (!TryReadIndex(out index));

    RemoveTodoAtIndex(index - 1);
}

void RemoveTodoAtIndex(int index)
{
    var todoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine();
    Console.WriteLine("刪除代辦事項： " + todoToBeRemoved);
}

bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine();
        Console.WriteLine("輸入的選項不可為空白");
        return false;
    }
    if (int.TryParse(userInput, out index) &&
        index >= 1 &&
        index <= todos.Count)
    {
        return true;
    }
    Console.WriteLine();
    Console.WriteLine("輸入的選項無效");
    return false;
}


static void showNoTodosMessage()
{
    Console.WriteLine();
    Console.WriteLine("尚未有任一項代辦事項加入");
}