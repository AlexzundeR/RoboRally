using System;
using NUnit.Framework;
using RoboRally.Model;

namespace RoboRally.Tests
{
    [TestFixture(Category = "Model", Description = "Tests for Robot")]
    public class RobotTest
    {
        private Robot _robot;

        [SetUp]
        public void SetUp()
        {
            _robot = new Robot("TEST");
        }

        public void PutCardsToRobot(Robot robot)
        {
            robot.PutCardToRegister(0, new ProgrammCard(RobotAction.Move1, 100));
            robot.PutCardToRegister(1, new ProgrammCard(RobotAction.Move2, 100));
            robot.PutCardToRegister(2, new ProgrammCard(RobotAction.RotateRight, 100));
            robot.PutCardToRegister(3, new ProgrammCard(RobotAction.Move3, 100));
            robot.PutCardToRegister(4, new ProgrammCard(RobotAction.RotateLeft, 100));
        }

        [Test]
        public void ProgramTest()
        {
            _robot.SetCurrentPosition(0, 0);
            _robot.CurrentDirection = ActionDirection.Right;
            PutCardsToRobot(_robot);

            for (int i = 0; i < 5; i++)
            {
                _robot.DoProgramm(i);
            }

            Console.WriteLine("X Coord: '{0}', Y Coord: '{1}', Facing: '{2}'", _robot.X, _robot.Y, _robot.CurrentDirection);
            const int coord = 3;
            Assert.AreEqual(coord, _robot.X, string.Format("Robot X coord should be {0}", coord));
            Assert.AreEqual(coord, _robot.Y, string.Format("Robot Y coord should be {0}", coord));
            Assert.AreEqual(ActionDirection.Right, _robot.CurrentDirection, string.Format("Robot facing should be {0}", ActionDirection.Right));


        }

        [Test(Description = "Let us damage the robot")]
        public void DamagingTest()
        {
            for (int i = 0; i < 4; i++)
            {
                _robot.GetDamaged();
            }
            _robot.ClearRegisters();
            Assert.IsNull(_robot.GetCard(4));
            PutCardsToRobot(_robot);
            _robot.GetDamaged();
            Assert.AreEqual(5, _robot.GetDamageValue(), "Damage should be 5");
            _robot.ClearRegisters();
            Assert.IsNotNull(_robot.GetCard(4));

            _robot.PutCardToRegister(0, new ProgrammCard(RobotAction.Move1, 100));
            _robot.PutCardToRegister(1, new ProgrammCard(RobotAction.Move2, 100));
            _robot.PutCardToRegister(2, new ProgrammCard(RobotAction.RotateRight, 100));
            _robot.PutCardToRegister(3, new ProgrammCard(RobotAction.Move3, 100));

            _robot.Repair();
            Assert.AreEqual(4, _robot.GetDamageValue(), "Damage should be 4");
            _robot.ClearRegisters();
            Assert.IsNull(_robot.GetCard(4));

        }

        [Test]
        [Ignore("It's not ready")]
        public void CrashTest()
        {

        }

        private static void DoAndCheckRobotAction(Robot robot, RobotAction action, int expectedX, int expectedY, ActionDirection facing, ActionDirection expectedFacing)
        {
            robot.CurrentDirection = facing;
            robot.DoAction(action);
            Console.WriteLine("Robot Action is '{0}'", action);
            Assert.AreEqual(expectedX, robot.X, string.Format("Robot X coord should be {0}", expectedX));
            Assert.AreEqual(expectedY, robot.Y, string.Format("Robot Y coord should be {0}", expectedY));
            Assert.AreEqual(expectedFacing, robot.CurrentDirection, string.Format("Robot facing should be {0}", expectedFacing));
        }

        [Test]
        public void MovesTest()
        {
            _robot.SetCurrentPosition(0, 0);

            DoAndCheckRobotAction(_robot, RobotAction.Move1, 1, 0, ActionDirection.Right, ActionDirection.Right);

            DoAndCheckRobotAction(_robot, RobotAction.Move2, 1, 2, ActionDirection.Down, ActionDirection.Down);

            DoAndCheckRobotAction(_robot, RobotAction.Move3, 4, 2, ActionDirection.Right, ActionDirection.Right);

            DoAndCheckRobotAction(_robot, RobotAction.BackTurn, 5, 2, ActionDirection.Left, ActionDirection.Left);

            DoAndCheckRobotAction(_robot, RobotAction.RotateLeft, 5, 2, ActionDirection.Left, ActionDirection.Down);

            DoAndCheckRobotAction(_robot, RobotAction.RotateRight, 5, 2, ActionDirection.Down, ActionDirection.Left);

            DoAndCheckRobotAction(_robot, RobotAction.UTurn, 5, 2, ActionDirection.Left, ActionDirection.Right);


        }

    }
}
