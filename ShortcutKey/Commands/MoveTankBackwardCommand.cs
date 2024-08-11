using System;

namespace ShortcutKey.Commands;

public class MoveTankBackwardCommand(Tank tank) : ICommand
{
    public void Execute()
    {
        tank.MoveBackward();
    }
    public void Undo()
    {
        tank.MoveForward();
    }
}

