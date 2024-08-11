using System;

namespace ShortcutKey;

public interface ICommand
{
    void Execute();
    void Undo();
}
