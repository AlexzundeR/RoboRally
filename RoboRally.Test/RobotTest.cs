using System.Diagnostics;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboRally.Model;

namespace RoboRally.Test
{
    [TestClass]
    public class RobotTest
    {
        private Robot _robot;

        [TestInitialize]
        public void Init()
        {
            _robot = new Robot();
        }

        [TestMethod]
        public void ProgramTest()
        {
            _robot.SetCurrentPosition(0, 0);
            _robot.CurrentDirection = FieldDirection.East;
            _robot.PutCardToRegister(0,new ProgrammCard(RobotAction.Move1,100));
            _robot.PutCardToRegister(1, new ProgrammCard(RobotAction.Move2, 100));
            _robot.PutCardToRegister(2, new ProgrammCard(RobotAction.RotateRight, 100));
            _robot.PutCardToRegister(3, new ProgrammCard(RobotAction.Move3, 100));
            _robot.PutCardToRegister(4, new ProgrammCard(RobotAction.RotateLeft, 100));
            
            for (int i = 0; i < 5; i++)
            {
                _robot.DoProgramm(i);
            }

            Debug.WriteLine("{0} {1} {2} ",_robot.X,_robot.Y,_robot.CurrentDirection);
            Assert.AreEqual(_robot.X, 3);
            Assert.AreEqual(_robot.Y, 3);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.East);

            _robot.BreakRegister(1);
            _robot.ClearRegisters();
            Assert.IsNotNull(_robot.GetCard(1));
            Assert.IsNull(_robot.GetCard(3));



        }
         
        [TestMethod]
        public void MovesTest()
        {
            _robot.SetCurrentPosition(0, 0);
            _robot.CurrentDirection = FieldDirection.East;
            _robot.DoAction(RobotAction.Move1);
            Assert.AreEqual(_robot.X, 1);
            Assert.AreEqual(_robot.Y, 0);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.East);

            _robot.CurrentDirection = FieldDirection.South;
            _robot.DoAction(RobotAction.Move2);
            Assert.AreEqual(_robot.X, 1);
            Assert.AreEqual(_robot.Y, 2);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.South);

            _robot.CurrentDirection = FieldDirection.East;
            _robot.DoAction(RobotAction.Move3);
            Assert.AreEqual(_robot.X, 4);
            Assert.AreEqual(_robot.Y, 2);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.East);

            _robot.CurrentDirection = FieldDirection.West;
            _robot.DoAction(RobotAction.BackTurn);
            Assert.AreEqual(_robot.X, 5);
            Assert.AreEqual(_robot.Y, 2);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.West);

            _robot.DoAction(RobotAction.RotateLeft);
            Assert.AreEqual(_robot.X, 5);
            Assert.AreEqual(_robot.Y, 2);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.South);

            _robot.DoAction(RobotAction.RotateRight);
            Assert.AreEqual(_robot.X, 5);
            Assert.AreEqual(_robot.Y, 2);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.West);
            
            _robot.DoAction(RobotAction.UTurn);
            Assert.AreEqual(_robot.X, 5);
            Assert.AreEqual(_robot.Y, 2);
            Assert.AreEqual(_robot.CurrentDirection, FieldDirection.East);

        }

    }
}
