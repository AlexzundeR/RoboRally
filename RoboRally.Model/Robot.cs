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

        public Byte LastLifes;

        private Byte _damage;

        public Boolean IsInPowerDown;

        private readonly RobotRegister[] _registers;

        public FieldDirection CurrentDirection;

        public Double X;
        public Double Y;
        private bool _isShutedDown;
        private bool _isCrashed;

        public Robot()
        {
            _registers = new RobotRegister[RegistersCount];
            for (int i = 0; i < RegistersCount; i++)
            {
                _registers[i] = new RobotRegister();
            }
        }

        public void DoAction(RobotAction action)
        {
            if (action.ActionType == RobotActionType.Move)
            {
                switch (CurrentDirection)
                {
                    case FieldDirection.North:
                        Y -= action.Value;
                        break;
                    case FieldDirection.East:
                        X += action.Value;
                        break;
                    case FieldDirection.South:
                        Y += action.Value;
                        break;
                    case FieldDirection.West:
                        X -= action.Value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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

        public void SetCurrentPosition(Double x, Double y)
        {
            X = x;
            Y = y;
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


        public void GetDamaged()
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

        public Byte GetCountOfDamage()
        {
            return _damage;
        }

        public void Crash()
        {
            _isCrashed = true;
        }


        public Boolean IsCrashed()
        {
            return _isCrashed;
        }

        public void RepairNextRegister()
        {
            _registers[9 - _damage].Repair();
        }
    }
}
