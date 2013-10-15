using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Model
{
    public class ProgrammCard
    {
        public ProgrammCard(RobotAction action, Int32 priority)
        {
            Action = action;
            Priority = priority;
        }

        public readonly RobotAction Action;

        public readonly Int32 Priority;
    }
}
