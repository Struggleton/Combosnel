using System.Numerics;

namespace Combosnel
{
    // Create a set of vector2 with directions for each angle.
    public static class Directions
    {
        public static Vector2 angForward = new Vector2(32767, 0);
        public static Vector2 angBackwards = new Vector2(-32768, 0);

        public static Vector2 angUp = new Vector2(0, 32767);
        public static Vector2 angDown = new Vector2(0, -32768);

        public static Vector2 angForwardUp = new Vector2(26214, 26214);
        public static Vector2 angForwardDown = new Vector2(26214, -26214);

        public static Vector2 angBackUp = new Vector2(-26214, 26214);
        public static Vector2 angBackDown = new Vector2(-26214, -26214);

        public static Vector2 angNone = new Vector2(0, 0);
    }


    // Create a set of Vector2 arrays for each SDI angle.
    public static class SDIDirections
    {
        public static Vector2[] angForward = new Vector2[]
        {
            Directions.angForwardUp, Directions.angForward, Directions.angForwardDown
        };

        public static Vector2[] angBackwards = new Vector2[]
        {
            Directions.angBackUp, Directions.angBackwards, Directions.angBackDown
        };

        public static Vector2[] angUp = new Vector2[]
        {
            Directions.angBackUp, Directions.angUp, Directions.angForwardUp
        };

        public static Vector2[] angDown = new Vector2[]
        {
            Directions.angBackDown, Directions.angDown, Directions.angForwardDown
        };

        public static Vector2[] angForwardUp = new Vector2[]
        {
            Directions.angUp, Directions.angForwardUp, Directions.angForward
        };

        public static Vector2[] angForwardDown = new Vector2[]
        {
            Directions.angDown, Directions.angForwardDown, Directions.angForward
        };

        public static Vector2[] angBackUp = new Vector2[]
        {
            Directions.angUp, Directions.angBackUp, Directions.angBackwards
        };

        public static Vector2[] angBackDown = new Vector2[]
        {
            Directions.angDown, Directions.angBackDown, Directions.angBackwards
        };
    }

    public enum Direction
    {
        None, Forward, Backwards,
        Up, Down,
        ForwardAndUp, ForwardAndDown,
        BackandUp, BackandDown
    }
}
