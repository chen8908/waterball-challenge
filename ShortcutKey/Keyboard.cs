using ShortcutKey.Commands;

namespace ShortcutKey;

public class Keyboard
{
    public static readonly IEnumerable<char> Keys =
    [
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
    ];
    public IDictionary<char, IEnumerable<ICommand>> ShortcutKeys = new Dictionary<char, IEnumerable<ICommand>>();
    private IEnumerable<ICommand> _supportedCommands = [];
    private readonly Stack<IEnumerable<ICommand>> _s1 = new();
    private readonly Stack<IEnumerable<ICommand>> _s2 = new();

    public void RegisterCommand(ICommand command)
    {
        _supportedCommands = _supportedCommands.Append(command);
    }

    /// <summary>
    /// 使用者按下快捷鍵事件
    /// </summary>
    /// <param name="key">快捷鍵</param>
    public void KeyDown(char key)
    {
        if (Keys.Contains(key) && ShortcutKeys.TryGetValue(key, out var commands))
        {
            foreach(var command in commands)
                command.Execute();
            _s1.Push(commands);
            _s2.Clear();
        }
    }
    /// <summary>
    /// 設定快捷鍵
    /// </summary>
    /// <param name="key">快捷鍵</param>
    public void SetShortcutKey(char key)
    {
        while(true)
        {
            var commandDict = new Dictionary<int, ICommand>();
            var index = 0;
            foreach(var command in _supportedCommands)
            {
                Console.WriteLine($"({index}){command.GetType().Name}");
                commandDict.Add(index, command);
                index++;
            }
            var result = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(result) || !int.TryParse(result, out var commandIndex) ||
                !commandDict.TryGetValue(commandIndex, out var selectedCommand))
                continue;
            
            ShortcutKeys.Add(key, [selectedCommand]);
            break;
        }
    }
    /// <summary>
    /// 設定巨集快捷鍵
    /// </summary>
    /// <param name="key">快捷鍵</param>
    public void SetShortcutKeyWithMacro(char key)
    {
        while(true)
        {
            var commandDict = new Dictionary<int, ICommand>();
            var index = 0;
            foreach(var command in _supportedCommands)
            {
                Console.WriteLine($"({index}){nameof(command)}");
                commandDict.Add(index, command);
                index++;
            }
            var result = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(result))
                continue;

            var splitedResult = result.Split(' ');
            if (splitedResult is null || splitedResult.Length == 0)
                continue;

            var selectedCommands = Enumerable.Empty<ICommand>();
            foreach(var item in splitedResult)
            {
                if (string.IsNullOrWhiteSpace(result) || !int.TryParse(result, out var commandIndex) || 
                    !commandDict.TryGetValue(commandIndex, out var selectedCommand))
                    continue;

                selectedCommands = selectedCommands.Append(selectedCommand);
            }

            ShortcutKeys.Add(key, selectedCommands);
            break;
        }
    }
    /// <summary>
    /// 清除所有快捷鍵
    /// </summary>
    public void ResetAllShortcutKey()
    {
        ShortcutKeys.Clear();
    }
    /// <summary>
    /// 還原
    /// </summary>
    public void Undo()
    {
        if (_s1.Count == 0)
            return;
        var lastCommands = _s1.Pop();
        if (lastCommands is null)
            return;
        foreach(var item in lastCommands)
            item.Undo();

        _s2.Push(lastCommands);
    }
    /// <summary>
    /// 重做
    /// </summary>
    public void Redo()
    {
        if (_s2.Count == 0)
            return;
        var lastCommands = _s2.Pop();
        if (lastCommands is null)
            return;
        foreach(var item in lastCommands)
            item.Execute();

        _s1.Push(lastCommands);
    }
}
