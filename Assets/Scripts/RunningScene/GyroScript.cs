using UnityEngine;
using System.Collections;

public class GyroScript : MonoBehaviour
{

    Quaternion currentGyro;

    private float previousX = 0;
    public bool isRun = false;

    void Start()
    {
        Input.gyro.enabled = true;

    }

    void Update()
    {

        currentGyro = Input.gyro.attitude;
        this.transform.localRotation =
            Quaternion.Euler(90, 90, 0) * (new Quaternion(-currentGyro.x, -currentGyro.y, currentGyro.z, currentGyro.w));
        
        if(System.Math.Abs(previousX-currentGyro.x) > 50) {
            isRun = true;
        } else {
            isRun = false;
        }
        
        previousX = currentGyro.x;
    }
}
