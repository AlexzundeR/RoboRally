using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboRally.Model
{
    public class Field
    {
        private static FieldItem _deathItem = new DeathItem();

        public readonly int Width;
        public readonly int Height;

        public Field(Int32 width, Int32 height)
        {
            Width = width;
            Height = height;
            _map = new FieldItem[width, height];
            StartPoints = new FieldItem[8];
        }

        public readonly FieldItem[] StartPoints;

        private readonly FieldItem[,] _map;

        public FieldItem this[Int32 x, Int32 y]
        {
            get
            {
                /* return the specified index here */
                if (x < 0 || y < 0 || x >= Width || y >= Height)
                    return _deathItem;
                return _map[x, y];
            }
            set
            {
                /* set the specified index to value here */
                _map[x, y] = value;
            }
        }

        public static Field Load(int width, int height)
        {
            var field = new Field(width, height);
            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    field[i, j] = new SimpleItem(i, j);
                }
            }

            for (int i = 0; i < field.StartPoints.Length; i++)
            {
                field.StartPoints[i] = field[i * 2 + 1, 2];
            }

            return field;
        }
    }
}
