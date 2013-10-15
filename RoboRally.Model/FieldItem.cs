//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace RoboRally.Model
//{
//    /// <summary>
//    /// Отсчет Х и У начинаю он верхнего
//    /// левого угла карты. Х - горизонталь,
//    /// У -вертикаль
//    /// </summary>
//    public abstract class FieldItem
//    {
//        public FieldItem(Int32 x, Int32 y)
//        {
//            X = x;
//            Y = y;
//        }
//        public Int32 X;
//        public Int32 Y;

//        public Robot Insider;
//    }

//    public class SimpleItem:FieldItem
//    {
//        public SimpleItem(int x, int y) : base(x, y)
//        {
//        }

//        public override string ToString()
//        {
//            if (Insider==null)
//            return " * ";
//            else
//            {
//                var result = "";
//                var arrow = Insider.CurrentDirection == ActionDirection.Up
//                                ? "^"
//                                : Insider.CurrentDirection == ActionDirection.Right
//                                      ? ">"
//                                      : Insider.CurrentDirection == ActionDirection.Down ? "v" : "<";
//                ;
//                result+=" "+arrow+" ";
//                return result;
//            }
//        }
//    }
//    public class DeathItem:FieldItem
//    {
//        public DeathItem() : base(-1, -1)
//        {
//        }

//        public override string ToString()
//        {
//            return "X";
//        }
//    }

//    public class ActionItem:FieldItem
//    {
//        public readonly List<RobotAction> Actions;

//        public ActionItem(int x, int y,List<RobotAction> actions) : base(x, y)
//        {
//            Actions = actions;
//        }
//    }

//}
