using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Model
{
    public class RobotRegister
    {
        private ProgrammCard _card;
        private Boolean _isBreaked;

        public void PutCard(ProgrammCard card)
        {
            if (_isBreaked)
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
            _isBreaked = true;
        }

        public Boolean IsBreaked()
        {
            return _isBreaked;
        }

        public void Clear()
        {
            if (_isBreaked)
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
            _isBreaked = false;
            _card = null;
        }
    }
}
