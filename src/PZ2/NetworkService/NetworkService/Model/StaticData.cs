using System.Collections.Generic;

namespace NetworkService.Model
{
    public class StaticData
    {
        // Za Undo komandu, Stack u koji smeštamo komande
        public static Stack<ICommandUndo> myICommands = new Stack<ICommandUndo>();
    }
}