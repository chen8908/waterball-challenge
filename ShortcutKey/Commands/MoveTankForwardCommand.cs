using System;

namespace ShortcutKey.Commands;

public class MoveTankForwardCommand(Tank tank) : ICommand
{
    public void Execute()
    {
        tank.MoveForward();
    }
    public void Undo()
    {
        tank.MoveBackward();
    }
}
