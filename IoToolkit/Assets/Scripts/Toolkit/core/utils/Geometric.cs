using UnityEngine;
using System;

public class Geometrics {

    public static readonly float UP = 0;
    public static readonly float LEFT = 90;
    public static readonly float DOWN = 180;
    public static readonly float RIGHT = 270;

    public static float PercentualDistance(float objectDistance, float maxDistance){
        float deltaDistance = objectDistance / maxDistance;
        return deltaDistance * 100;
    }
    public static bool IsUp(float rotation) {
        return rotation < LEFT || rotation > RIGHT;
    }

    public static bool IsDown(float rotation) {
        return !IsUp(rotation) && rotation != 90 && rotation != 270;
    }

    public static bool IsRight(float rotation) {
        return rotation > DOWN;
    }
    
    public static bool IsLeft(float rotation) {
        return !IsRight(rotation) && rotation != 0 && rotation != 180;
    }

    /**
    * Get the rotation of a game object in positive degrees
    * @param gameObject The game object to get the rotation from
    * @return The rotation of the game object in positive degrees
    */
    public static float GetLocalRotation(GameObject gameObject) {
        return gameObject.transform.localRotation.eulerAngles.z;
    }

    public static Vector2 CalculateAxis(float rotation) {

        float x = 0;
        float y = 0;

        if(IsUp(rotation)) {
            y = 1;
        } else if(IsDown(rotation)) {
            y = -1;
        }

        if(IsRight(rotation)) {
            x = 1;
        } else if(IsLeft(rotation)) {
            x = -1;
        }


            return new Vector2(x,y);
        }


    private static bool IsInMargin(float value, float target, float margin) {
        return value < target + margin || value > target - margin;
    }

}