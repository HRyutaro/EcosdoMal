using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamConfig : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterBody2;
    public Transform characterHead;
    public Transform characterHead2;

    public float sensitivityX = 0.5f;
    public float sensitivityY = 0.5f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    public float smoothCoefx = 0.005f;
    public float smoothCoefy = 0.005f;

    public static bool trocarCam = true;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        if(trocarCam == true)
        {
            transform.position = characterHead.position;
        }
        else if(trocarCam == false)
        {
            transform.position = characterHead2.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ControleCam();
    }
    void ControleCam()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") *sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
        smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

        rotationX += smoothRotx;
        rotationY += smoothRoty;

        rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);
        characterBody2.localEulerAngles = new Vector3(0, rotationX, 0);
        
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

}
