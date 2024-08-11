using ShortcutKey;
using ShortcutKey.Commands;

Tank tank = new();
Telecom telecom = new();

var keyboard = new Keyboard();
keyboard.RegisterCommand(new MoveTankForwardCommand(tank));
keyboard.RegisterCommand(new MoveTankBackwardCommand(tank));
keyboard.RegisterCommand(new ConnectTelecomCommand(telecom));
keyboard.RegisterCommand(new DisconnectTelecomCommand(telecom));
keyboard.RegisterCommand(new ResetMainControlKeyboard(keyboard));

while(true)
{
    Console.Write("(1) 快捷鍵設置 (2) Undo (3) Redo (字母) 按下按鍵:");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        break;

    if (int.TryParse(input, out var number))
    {
        if (number == 1)
        {
            Console.WriteLine("設置巨集指令 (y/n):");
            var macroResultString = Console.ReadLine();
            var macroResult = macroResultString == "y";
            Console.WriteLine("Key:");
            var keyResult = Console.ReadLine();
            if (!char.TryParse(keyResult, out var key) || !Keyboard.Keys.Contains(key))
                continue;

            Console.WriteLine($"要將哪一道指令設置到快捷鍵 {key} 上:");
            if (macroResult)
                keyboard.SetShortcutKeyWithMacro(key);
            else
                keyboard.SetShortcutKey(key);
        }
        else if (number == 2)
            keyboard.Undo();
        else if (number == 3)
            keyboard.Redo();
    }
    else if(char.TryParse(input, out var key))
    {
        keyboard.KeyDown(key);
    }
}
