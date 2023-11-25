﻿namespace XnaGame.Utils
{
    public struct FRectangle
    {
        public FVector2 Location { get; set; }
        public FVector2 Size { get; set; }

        public float Left => Location.X;
        public float Right => Location.X + Size.X;

        public float Top => Location.Y + Size.Y;
        public float Bottom => Location.Y;

        public float X => Location.X;
        public float Y => Location.Y;

        public float Width => Size.X;
        public float Height => Size.Y;

        public FVector2 Center => Location + Size / 2;

        public FRectangle(FVector2 location, FVector2 size)
        {
            Location = location;
            Size = size;
        }

        public FRectangle(float x, float y, float width, float height)
        {
            Location = new FVector2(x, y);
            Size = new FVector2(width, height);
        }

        public bool Contains(FVector2 point) =>
            point.X >= Left &&
            point.Y >= Bottom &&
            point.X <= Right &&
            point.Y <= Top;

        public bool Contains(float x, float y) =>
            x >= Left &&
            y >= Bottom &&
            x <= Right &&
            y <= Top;

        public static FRectangle operator +(FRectangle left, FRectangle right) => new FRectangle(left.Location + right.Location, left.Size);
    }
}