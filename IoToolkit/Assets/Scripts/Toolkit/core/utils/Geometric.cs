public class Geometrics {

    public static readonly float UP = 0;
    public static readonly float RIGHT = 90;
    public static readonly float DOWN = 180;
    public static readonly float LEFT = 270;


    public static float PercentualDistance(float objectDistance, float maxDistance){
        float deltaDistance = objectDistance / maxDistance;
        return deltaDistance * 100;
    }
    public static bool IsUp(float rotation) {
        return rotation > LEFT || rotation < RIGHT;
    }

    public static bool IsDown(float rotation) {
        return rotation > RIGHT && rotation < LEFT;
    }

    public static bool IsLeft(float rotation) {
        return rotation > UP && rotation < DOWN;
    }

    public static bool IsRight(float rotation) {
        return rotation < DOWN;
    }

    public static float CalculateXAxis(float rotation) {

        
        // Normalize rotation values
        if(rotation > 270) {
            rotation -= 90;
        }

        if(rotation < 90) {
            rotation += 90;
        }

        rotation -= 90;

        // calculate percentage (0->180)
        float percent = (rotation/180) * 2 -1;
        return percent;
    }

    public static float CalculateYAxis(float rotation) {

        rotation = rotation < 180 ? rotation : rotation - 180; 
        float percent = (rotation/180) * 2 -1;
        return percent;

    }

}