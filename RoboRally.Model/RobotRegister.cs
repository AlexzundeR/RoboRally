using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Model
{
    public class RobotRegister
    {
        private ProgrammCard _card;
        private Boolean _isBroken;

        public void PutCard(ProgrammCard card)
        {
            if (_isBroken)
            {
                throw new InvalidOperationException("Нельзя заполнить заклинивший регистр");
            }

            if (_card!=null)
            {
                throw new InvalidOperationException("Нельзя заполнить заполненный регистр");
            }
            _card = card;
        }

        public ProgrammCard GetCard()
        {
            return _card;
        }

        public void Break()
        {
            _isBroken = true;
        }

        public Boolean IsBroken()
        {
            return _isBroken;
        }

        public void Clear()
        {
            if (_isBroken)
            {
                throw new InvalidOperationException("Нельзя очистить заклинивший регистр");
            }
            _card = null;
        }

        public bool HasCard()
        {
            return _card != null;
        }

        public void Repair()
        {
            _isBroken = false;
            _card = null;
        }
    }
}
