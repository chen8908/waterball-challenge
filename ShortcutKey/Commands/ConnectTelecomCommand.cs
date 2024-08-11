using System;

namespace ShortcutKey.Commands;

public class ConnectTelecomCommand(Telecom telecom) : ICommand
{
    public void Execute()
    {
        telecom.Connect();
    }
    public void Undo()
    {
        telecom.Disconnect();
    }
}
