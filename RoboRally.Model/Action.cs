using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Model
{
    public enum RobotActionType
    {
        Move,
        Rotate
    }

    public sealed class RobotAction
    {
        public static RobotAction Move1 = new RobotAction(RobotActionType.Move, 1);
        public static RobotAction Move2 = new RobotAction(RobotActionType.Move, 2);
        public static RobotAction Move3 = new RobotAction(RobotActionType.Move, 3);
        public static RobotAction BackTurn = new RobotAction(RobotActionType.Move, -1);
        public static RobotAction RotateLeft = new RobotAction(RobotActionType.Rotate, 90);
        public static RobotAction RotateRight = new RobotAction(RobotActionType.Rotate, -90);
        public static RobotAction UTurn = new RobotAction(RobotActionType.Rotate, 180);

        public RobotAction(RobotActionType actionType, Int32 value)
        {
            ActionType = actionType;
            Value = value;
        }

        public RobotActionType ActionType;

        public Int32 Value;
    }
}
