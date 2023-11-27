using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public static class BrickUtils
{
    public const float THICKNESS = 0.3f;
    public static Quaternion ROTATION = Quaternion.Euler(-90, 0, -180);
}

public static class LineUtils
{
    public static Quaternion ROTATION = Quaternion.Euler(-90, 0, -180);
}

public static class ChestUtils
{
    public static Quaternion ROTATION = Quaternion.Euler(-90, 0, -180);
    public static Vector3 OFFSET = new Vector3(0, 0, 0.5f);
}

public static class GameAnim
{
    public static class Duration
    {
        public const float IDLE = 1.1f;
        public const float JUMP = 0.17f;
        public const float CHEER = 6.14f;
    }
}

public static class VectorUtils
{
    public static bool CheckAproximate(Vector3 A, Vector3 B)
    {
        Vector3 result = A - B;
        return result.magnitude < 0.01f;
    }
    public static readonly Vector3[] DirectionVectors =
    {
        Vector3.zero,
        Vector3.forward,
        Vector3.back,
        Vector3.right,
        Vector3.left
    };
    public static Vector3 DirectionVectorOf(Direction direction)
    {
        return DirectionVectors[(int)direction];
    }

}

public static class LevelUtils
{
    public const float MAX_LEVEL = 3;
}

public static class CoinUtils
{
    public const int COIN_PER_LEVEL = 50;
    public const int COIN_PER_ADS = 300;
}
    
    

    
