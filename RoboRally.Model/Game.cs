using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Model
{
    public delegate void EmptyEvent();
    //public class Game
    //{
    //    private readonly int _robotsCount;
    //    public Field Field;

    //    public Game(Int32 robotsCount)
    //    {
    //        _robotsCount = robotsCount;
    //        _robots = new Robot[_robotsCount];
    //        for (int i = 0; i < _robotsCount; i++)
    //        {
    //            var newRobot = new Robot();
    //            _robots[i] = newRobot;
    //        }
    //    }

    //    private Robot[] _robots;

    //    public void DoTurn()
    //    {
    //        for (_currentPhaseNumber = 0; _currentPhaseNumber < 5; _currentPhaseNumber++)
    //        {
    //            DoPhase();
    //        }
    //    }

    //    private void DoPhase()
    //    {
    //        var sortedRobots = _robots.OrderBy(e => e.ProgramList[_currentPhaseNumber].Priority);
    //        foreach (var robot in sortedRobots)
    //        {
    //            DoCurrentAction(robot);
    //        }

    //        Repaint();
    //        _currentPhaseNumber++;

    //        Console.ReadLine();
    //    }

    //    private readonly Random _generator = new Random();

    //    public void GetProgramCards()
    //    {
    //        foreach (var robot in _robots)
    //        {
    //            for (int i = 0; i < 5; i++)
    //            {
    //                var newCard = new ProgramCard();
    //                newCard.Priority = _generator.Next(850);
    //                switch (_generator.Next(7))
    //                {
    //                    case 0:
    //                        newCard.Action = RobotAction.Move1; break;
    //                    case 1:
    //                        newCard.Action = RobotAction.Move2; break;
    //                    case 2:
    //                        newCard.Action = RobotAction.Move3; break;
    //                    case 3:
    //                        newCard.Action = RobotAction.BackTurn; break;
    //                    case 4:
    //                        newCard.Action = RobotAction.RotateLeft; break;
    //                    case 5:
    //                        newCard.Action = RobotAction.RotateRight; break;
    //                    case 6:
    //                        newCard.Action = RobotAction.UTurn; break;
    //                }
    //                robot.ProgramList[i] = newCard;
    //            }
    //        }
    //    }

    //    public void LoadMap(Int32 width, Int32 height)
    //    {
    //        Field = Field.Load(width, height);

    //        for (int i = 0; i < _robotsCount; i++)
    //        {
    //            _robots[i].CurrentPosition = Field.StartPoints[i];
    //            _robots[i].CurrentPosition.Insider = _robots[i];
    //            _robots[i].Respawn = Field.StartPoints[i];
    //        }
    //    }

    //    public void Repaint()
    //    {
    //        for (int y = 0; y < Field.Height; y++)
    //        {
    //            for (int x = 0; x < Field.Width; x++)
    //            {
    //                Console.Write(Field[x, y]);
    //            }
    //            Console.WriteLine();
    //        }
    //    }

    //    public event EmptyEvent PhaseEnded;

    //    public void InvokePhaseEnded()
    //    {
    //        EmptyEvent handler = PhaseEnded;
    //        if (handler != null) handler();
    //    }


    //    private Int32 _currentPhaseNumber;

    //    private void DoCurrentAction(Robot robot)
    //    {
    //        DoRobotAction(robot, robot.ProgramList[_currentPhaseNumber].Action, robot.CurrentDirection);
    //    }

    //    private void DoRobotAction(Robot robot, RobotAction action, ActionDirection direction)
    //    {
    //        if (action.ActionType == RobotActionType.Move)
    //        {
    //            FieldItem currentPosition = robot.CurrentPosition;
    //            for (int i = 0; i < action.Value; i++)
    //            {
    //                currentPosition.Insider = null;
    //                switch (direction)
    //                {
    //                    case ActionDirection.Up:
    //                        currentPosition = Field[currentPosition.X, currentPosition.Y - 1]; break;
    //                    case ActionDirection.Right:
    //                        currentPosition = Field[currentPosition.X + 1, currentPosition.Y]; break;
    //                    case ActionDirection.Left:
    //                        currentPosition = Field[currentPosition.X - 1, currentPosition.Y]; break;
    //                    case ActionDirection.Down:
    //                        currentPosition = Field[currentPosition.X, currentPosition.Y + 1]; break;
    //                }
    //                if (currentPosition.Insider!=null)
    //                {
                        
    //                    DoRobotAction(currentPosition.Insider,RobotAction.Move1,direction);
    //                }

    //                if (!(currentPosition is DeathItem))
    //                {
    //                    robot.CurrentPosition = currentPosition;
    //                    currentPosition.Insider = robot;
    //                }
    //                else
    //                {
    //                    robot.LastLifes--;
    //                    robot.CurrentPosition = robot.Respawn;
    //                    robot.Respawn.Insider = robot;
    //                    break;
    //                }
    //            }
    //        }
    //        else if (action.ActionType == RobotActionType.Rotate)
    //        {
    //            ActionDirection nextDirection = direction;
    //            int turnCount = action.Value == -90 ? 3 : action.Value == 90 ? 1 : 2;

    //            for (int i = 0; i < turnCount; i++)
    //            {
    //                if (nextDirection == ActionDirection.Up)
    //                {
    //                    nextDirection = ActionDirection.Right;
    //                }
    //                else if (nextDirection == ActionDirection.Right)
    //                {
    //                    nextDirection = ActionDirection.Down;
    //                }
    //                else if (nextDirection == ActionDirection.Down)
    //                {
    //                    nextDirection = ActionDirection.Left;
    //                }
    //                else if (nextDirection == ActionDirection.Left)
    //                {
    //                    nextDirection = ActionDirection.Up;
    //                }
    //            }

    //            robot.CurrentDirection = nextDirection;
    //        }
    //    }
    //}
}
