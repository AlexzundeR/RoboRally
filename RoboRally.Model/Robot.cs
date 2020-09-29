using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;

namespace RoboRally.Model
{
    public class Robot
    {
        public static readonly Int32 RegistersCount = 5;
        
        private Byte _damage;
        private readonly RobotRegister[] _registers;
        private Int32 _x, _y;
        private bool _isShutedDown;
        private bool _isCrashed;

        public String Name;
        public Byte Lifes;
        public Boolean IsInPowerDown;
        public ActionDirection CurrentDirection;
        public FieldItem CurrentPosition;
        public FieldItem Respawn;
        private string v;

        public Int32 X { get { return _x; } }
        public Int32 Y { get { return _y; } }

        public Robot(string name)
        {
            _registers = new RobotRegister[RegistersCount];
            for (int i = 0; i < RegistersCount; i++)
            {
                _registers[i] = new RobotRegister();
            }
            Lifes = 3;
            Name = name;
        }

        public void DoAction(RobotAction action)
        {
            if (action.ActionType == RobotActionType.Move)
            {
                TurnRobot(CurrentDirection,action.Value);
            }
            if (action.ActionType == RobotActionType.Rotate)
            {
                if (action.Value == 90)
                {
                    switch (CurrentDirection)
                    {
                        case ActionDirection.Up:
                            CurrentDirection = ActionDirection.Left;
                            break;
                        case ActionDirection.Right:
                            CurrentDirection = ActionDirection.Up;
                            break;
                        case ActionDirection.Down:
                            CurrentDirection = ActionDirection.Right;
                            break;
                        case ActionDirection.Left:
                            CurrentDirection = ActionDirection.Down;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                if (action.Value == -90)
                {
                    switch (CurrentDirection)
                    {
                        case ActionDirection.Up:
                            CurrentDirection = ActionDirection.Right;
                            break;
                        case ActionDirection.Right:
                            CurrentDirection = ActionDirection.Down;
                            break;
                        case ActionDirection.Down:
                            CurrentDirection = ActionDirection.Left;
                            break;
                        case ActionDirection.Left:
                            CurrentDirection = ActionDirection.Up;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                if (action.Value == 180)
                {
                    switch (CurrentDirection)
                    {
                        case ActionDirection.Up:
                            CurrentDirection = ActionDirection.Down;
                            break;
                        case ActionDirection.Right:
                            CurrentDirection = ActionDirection.Left;
                            break;
                        case ActionDirection.Down:
                            CurrentDirection = ActionDirection.Up;
                            break;
                        case ActionDirection.Left:
                            CurrentDirection = ActionDirection.Right;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public void TurnRobot(ActionDirection to, int value)
        {
            switch (to)
            {
                case ActionDirection.Up:
                    _y -= value;
                    break;
                case ActionDirection.Right:
                    _x += value;
                    break;
                case ActionDirection.Down:
                    _y += value;
                    break;
                case ActionDirection.Left:
                    _x -= value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetCurrentPosition(Int32 x, Int32 y)
        {
            _x = x;
            _y = y;
        }

        public void DoProgramm(int i)
        {
            DoAction(_registers[i].GetCard().Action);
        }

        public void ClearRegisters()
        {
            for (int i = 0; i < RegistersCount; i++)
            {
                if (!_registers[i].IsBroken())
                {
                    _registers[i].Clear();
                }
            }
        }

        public void PutCardToRegister(Int32 registerIndex, ProgrammCard card)
        {
            var register = _registers[registerIndex];
            register.PutCard(card);
        }

        public ProgrammCard GetCard(int registerIndex)
        {
            return _registers[registerIndex].GetCard();
        }

        public void BreakRegister(int registerIndex)
        {
            _registers[registerIndex].Break();
        }

        public void ShutDown()
        {
            _isShutedDown = true;
        }

        public Boolean IsShutedDown()
        {
            return _isShutedDown;
        }

        public byte GetDamageValue()
        {
            return _damage;
        }

        public void GetDamaged()
        {
            if (!IsShutedDown())
            {
                _damage++;

                if (_damage > 4)
                {
                    if (_damage == 10)
                    {
                        Crash();
                    }
                    else
                    {
                        BreakRegister(9 - _damage);
                    }
                }
            }
        }

        public Byte GetCountOfDamage()
        {
            return _damage;
        }

        public void Crash()
        {
            _isCrashed = true;
            Lifes--;
            if (Lifes == 0)
            {
                Dead();
            }
            else
            {
                _damage = 2;
            }
        }

        public void Dead()
        {
            
        }

        public Boolean IsCrashed()
        {
            return _isCrashed;
        }

        public void RepairNextRegister()
        {
            _registers[9 - _damage].Repair();
        }

        public void Repair()
        {
            if (_damage > 0)
            {
                if (_damage > 4)
                {
                    RepairNextRegister();
                }
                _damage--;
            }
        }
    }
}
