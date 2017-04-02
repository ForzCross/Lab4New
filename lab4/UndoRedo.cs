using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    class UndoRedo
    {
    }
}
abstract class Command
{
    public abstract void Execute();
    public abstract void UnExecute();
}
class Expert//эксперт вносит название и описание символа
{
    ExpSimvol simvol = new ExpSimvol();
    public void CreateData(string name,string info)
    {
        simvol.info_simvol.Add(name);
        simvol.info_simvol.Add(info);
    }
}
/// <summary>
/// реализация отмены и возврата
/// </summary>
class ConcreteCreateData : Command
{
    Expert expsimvol;
    string name,info;

    public override void Execute()
    {
        expsimvol.CreateData(name, info);
    }
    public override void UnExecute()
    {
        expsimvol.CreateData(name, info);
    }
}
/// <summary>
/// формирует список комаанд которые были произведены экспертом, в дальнейм для отмены и возврата 
/// </summary>
class User
{
    private List<Command> commands = new List<Command>();
    private int current = 0;
    public void Redo(int levels)
    {
        for (int i = 0; i < levels; i++)
            if (current < commands.Count - 1)
                commands[current].Execute();
    }
    public void Undo(int levels)
    {
        for (int i = 0; i < levels; i++)
            if (current > 0)
                commands[--current].UnExecute();
    }
    public void execommand()
    {
        Command com = new ConcreteCreateData();
        com.Execute();
        commands.Add(com);
        current++;
    }
}