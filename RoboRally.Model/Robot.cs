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
        public String Name;

        public Byte Lifes;

        private Byte _damage;

        public Boolean IsInPowerDown;

        private readonly RobotRegister[] _registers;

        public FieldDirection CurrentDirection { get;  set; }

        private Int32 _x, _y;
        public Int32 X { get { return _x; } }
        public Int32 Y { get { return _y; } }
        private bool _isShutedDown;
        private bool _isCrashed;

        public Robot()
        {
            _registers = new RobotRegister[RegistersCount];
            for (int i = 0; i < RegistersCount; i++)
            {
                _registers[i] = new RobotRegister();
            }
            Lifes = 3;
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
                        case FieldDirection.North:
                            CurrentDirection = FieldDirection.West;
                            break;
                        case FieldDirection.East:
                            CurrentDirection = FieldDirection.North;
                            break;
                        case FieldDirection.South:
                            CurrentDirection = FieldDirection.East;
                            break;
                        case FieldDirection.West:
                            CurrentDirection = FieldDirection.South;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                if (action.Value == -90)
                {
                    switch (CurrentDirection)
                    {
                        case FieldDirection.North:
                            CurrentDirection = FieldDirection.East;
                            break;
                        case FieldDirection.East:
                            CurrentDirection = FieldDirection.South;
                            break;
                        case FieldDirection.South:
                            CurrentDirection = FieldDirection.West;
                            break;
                        case FieldDirection.West:
                            CurrentDirection = FieldDirection.North;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                if (action.Value == 180)
                {
                    switch (CurrentDirection)
                    {
                        case FieldDirection.North:
                            CurrentDirection = FieldDirection.South;
                            break;
                        case FieldDirection.East:
                            CurrentDirection = FieldDirection.West;
                            break;
                        case FieldDirection.South:
                            CurrentDirection = FieldDirection.North;
                            break;
                        case FieldDirection.West:
                            CurrentDirection = FieldDirection.East;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public void TurnRobot(FieldDirection to, int value)
        {
            switch (to)
            {
                case FieldDirection.North:
                    _y -= value;
                    break;
                case FieldDirection.East:
                    _x += value;
                    break;
                case FieldDirection.South:
                    _y += value;
                    break;
                case FieldDirection.West:
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
                if (!_registers[i].IsBreaked())
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
