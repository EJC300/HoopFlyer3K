using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuasarMath 
{
    /*
     * A bunch of reusable math functions to use in my unity games
     * 
     * 
     */

    //SmoothDamp

    public static Vector3 SmoothDamp(Vector3 start,Vector3 end,float deltaTime,float speed)
    {
        float x = Mathf.Lerp(start.x, end.x, 1 - Mathf.Exp(-speed * deltaTime));
        float y = Mathf.Lerp(start.y, end.y, 1 - Mathf.Exp(-speed * deltaTime));
        float z = Mathf.Lerp(start.z, end.z, 1 - Mathf.Exp(-speed * deltaTime));
        return new Vector3(x,y,z);
    }

    public static Vector2 SmoothDamp(Vector2 start, Vector2 end, float deltaTime, float speed)
    {
        float x = Mathf.Lerp(start.x, end.x, 1 - Mathf.Exp(-speed * deltaTime));
        float y = Mathf.Lerp(start.y, end.y, 1 - Mathf.Exp(-speed * deltaTime));

        return new Vector2(x, y);
    }

    public static Quaternion SmoothDamp(Quaternion start,Quaternion end, float deltaTime, float speed)
    {
        float x = Mathf.Lerp(start.x, end.x, 1 - Mathf.Exp(-speed * deltaTime));
        float y = Mathf.Lerp(start.y, end.y, 1 - Mathf.Exp(-speed * deltaTime));
        float z = Mathf.Lerp(start.z, end.z, 1 - Mathf.Exp(-speed * deltaTime));
        float w = Mathf.Lerp(start.w, end.w, 1 - Mathf.Exp(-speed * deltaTime));

        return new Quaternion(x, y, z, w);
    }

    public static float SmoothDamp(float start,float end, float deltaTime, float speed)
    {
        float value = Mathf.Lerp(start,end, 1 - Mathf.Exp(-speed * deltaTime));
        return value;
    }

    //Spherical Interpolation Look At Method

    public static Quaternion SlerpLookAt( Quaternion currentRotation,Vector3 start,Vector3 target,float speed,float deltaTime)
    {
        Vector3 heading = target - start;
        Quaternion lookAt = Quaternion.LookRotation(heading);
        Quaternion newRotation = Quaternion.RotateTowards(currentRotation,lookAt, speed * deltaTime);
        Quaternion smoothedRotation = Quaternion.Slerp(currentRotation,newRotation,speed * deltaTime);
        return smoothedRotation;
    }
    //Clamps the Rotation using euler angles
    public static Quaternion ClampRotation(Quaternion currentRotation,float minX,float maxX,float minY,float maxY,float minZ,float maxZ)
    {
        currentRotation.x /= currentRotation.w;
        currentRotation.y /= currentRotation.w;
        currentRotation.z /= currentRotation.w;
        currentRotation.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(currentRotation.x);
        angleX = Mathf.Clamp(angleX, minX, maxX);
        float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan(currentRotation.y);
        angleY = Mathf.Clamp(angleY, minY, maxY);
        float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan(currentRotation.z);
        angleZ = Mathf.Clamp(angleZ, minZ, maxZ);
        currentRotation.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
        currentRotation.y = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleY);
        currentRotation.z = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleZ);
        return currentRotation;
    }
    //Same Basic commonly used movement methods
    public static void MoveLocalBasic(Transform transform,Vector3 direction,float speed,float deltaTime)
    {
        transform.Translate(direction * speed * deltaTime,Space.Self);
    }

    public static void RotateLocalBasic(Transform transform,Vector3 orientation,float speed,float deltaTime)
    {
        transform.Rotate(orientation * speed * deltaTime,Space.Self);
    }
    //Easing Functions 

    public static float SineEaseIn(float t,float b,float c,float d) 
    {
     
    
        return -c * (float)Mathf.Cos(t / d * (Mathf.PI / 2)) + c + b;
    }
    public static float SineEaseOut(float t, float b, float c, float d)
    {


        return c * (float)Mathf.Cos(t / d * Mathf.PI/2) + b;
    }
    public static float QuadEaseIn(float t,float b,float c,float d)
    {
       
        return c*(t/=d)*t + b;
       
    }
    public static float QuadEaseOut(float t, float b, float c, float d)
    {

        return -c * (t /= d) * (t-2) + b;

    }


    //Some Basic Generic Game Specific Functions such as tracking a target RigidBody or non physics target

    public static Vector3 GetLead(Vector3 position,ref Vector3 velocity,ref Vector3 targetPosition,float minPredictionTime)
    {
        float predictionTime = Mathf.Lerp(0, minPredictionTime, (targetPosition - position).magnitude / 100);
        Vector3 lead = targetPosition + velocity * predictionTime;

        return lead;
    }

    //Some Basic Trig Math Functions such as finding a point a triangle

    public static bool CheckIfBehind(Vector3 target,Vector3 position)
    {
        Vector3 heading = target - position;
        float dot = Vector3.Dot(heading, Vector3.forward);
        return dot < 0;
    }
    public static bool CheckifInFront(Vector3 target, Vector3 position)
    {
        Vector3 heading = target - position;
        float dot = Vector3.Dot(heading, Vector3.forward);
        return dot > 0;
    }

    public static bool CheckifLeft(Vector3 target, Vector3 position)
    {
        Vector3 heading = target - position;
        float dot = Vector3.Dot(heading, Vector3.right);
        return dot < 0;
    }

    public static bool CheckifRight(Vector3 target, Vector3 position)
    {
        Vector3 heading = target - position;
        float dot = Vector3.Dot(heading, Vector3.left);
        return dot < 0;
    }
    public static bool CheckifAbove(Vector3 target, Vector3 position)
    {
        Vector3 heading = target - position;
        float dot = Vector3.Dot(heading, Vector3.up);
        return dot > 0;
    }
    public static bool CheckifBelow(Vector3 target, Vector3 position)
    {
        Vector3 heading = target - position;
        float dot = Vector3.Dot(heading, Vector3.up);
        return dot < 0;
    }

    public static float TransformVelocityToAxis(Vector3 axis,ref Vector3 velocity)
    {
        return Vector3.Dot(velocity, axis);
    }
}
