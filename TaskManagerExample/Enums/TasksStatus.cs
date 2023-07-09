using System.ComponentModel;

namespace TaskManagerExample.Enums
{
    public enum TasksStatus
    {
        [Description("A Fazer")]
        Todo = 1,
        [Description("Em andamento")]
        Doing = 2,
        [Description("Concluído")]
        Complete = 3
    }
}
