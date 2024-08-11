using System;

namespace ShortcutKey.Commands;

public class ResetMainControlKeyboard(Keyboard keyboard) : ICommand
{
    private IDictionary<char, IEnumerable<ICommand>> _tempShortcutKey = new Dictionary<char, IEnumerable<ICommand>>();
    public void Execute()
    {
        _tempShortcutKey = keyboard.ShortcutKeys;
        keyboard.ResetAllShortcutKey();
        Console.WriteLine("控制台快捷鍵清空");
    }
    public void Undo()
    {
        keyboard.ShortcutKeys = _tempShortcutKey;
        Console.WriteLine("控制台快捷鍵還原");
    }
}