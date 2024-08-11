using System;

namespace ShortcutKey.Commands;

public class DisconnectTelecomCommand(Telecom telecom) : ICommand
{
    public void Execute()
    {
        telecom.Disconnect();
    }
    public void Undo()
    {
        telecom.Connect();
    }
}

