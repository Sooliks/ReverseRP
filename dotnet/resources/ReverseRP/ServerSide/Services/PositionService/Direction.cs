using RAGE;
using System;
using GTANetworkAPI;

namespace ServerSide.Services.PositionService
{
    public class Direction
    {
        public static Vector3 GetDirection(Vector3 position, Vector3 rotation, float distance = 10.3f)
        {
            Vector3 lengthVector = Multiply(RotateToDirection(rotation), distance);
            Vector3 posLookAt = Add(position, lengthVector);
            return posLookAt;
        }
        private static Vector3 Multiply(Vector3 vector, float x)
        {
            Vector3 result = new Vector3(vector.X, vector.Y, vector.Z);
            result.X *= x;
            result.Y *= x;
            result.Z *= x;
            return result;
        }
        private static Vector3 Add(Vector3 vectorA, Vector3 vectorB)
        {
            Vector3 result = new Vector3(vectorA.X, vectorA.Y, vectorA.Z);
            result.X += vectorB.X;
            result.Y += vectorB.Y;
            result.Z += vectorB.Z;
            return result;
        }
        private static Vector3 RotateToDirection(Vector3 rot)
        {
            float radiansZ = rot.Z * 0.0174532924f;
            float radiansX = rot.X * 0.0174532924f;
            float num = MathF.Abs((float)MathF.Cos((float)radiansX));
            Vector3 dir = new Vector3();
            dir.X = (float)((float)((float)(-(float)MathF.Sin((float)radiansZ))) * (float)num);
            dir.Y = (float)((float)((float)MathF.Cos((float)radiansZ)) * (float)num);
            dir.Z = (float)MathF.Sin((float)radiansX);
            return dir;
        }
    }
}