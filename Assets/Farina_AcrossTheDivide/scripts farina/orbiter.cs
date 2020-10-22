using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbiter : MonoBehaviour
{

    public Transform TargetLookAt;    //target to which camera will look always
    public float Distance = 20f;         //distance of camera from target

    public float DistanceSmooth = 0.05f;    //smoothing factor for camera movement
    public float X_Smooth = 0.05f;
    public float Y_Smooth = 0.1f;
    public float height = 35f;
    private float rotX = 0f;

    public float speed = 2f;
    private float desiredDistance = 0f; //desired distance of camera from target
    private float velDistance = 0f;
    private Vector3 desiredPosition = Vector3.zero;
    private float velX = 0f;
    private float velY = 0f;
    private float velZ = 0f;
    private Vector3 position = Vector3.zero;


    void LateUpdate()
    {
        if (TargetLookAt == null)
            return;
        AngleCalc();
        CalculateDesiredPosition();
        UpdatePosition();
    }


    void AngleCalc()
    {

        rotX += Time.deltaTime * speed;

    }

    void CalculateDesiredPosition()
    {
        desiredPosition = CalculatePosition(height, rotX, Distance);
    }

    Vector3 CalculatePosition(float rotationX, float rotationY, float distance)
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        return TargetLookAt.position + rotation * direction;
    }

    void UpdatePosition()
    {
        var posX = Mathf.SmoothDamp(position.x, desiredPosition.x, ref velX, X_Smooth);
        var posY = Mathf.SmoothDamp(position.y, desiredPosition.y, ref velY, Y_Smooth);
        var posZ = Mathf.SmoothDamp(position.z, desiredPosition.z, ref velZ, X_Smooth);

        position = new Vector3(posX, posY, posZ);
        transform.position = position;
        transform.LookAt(TargetLookAt);
    }

}
