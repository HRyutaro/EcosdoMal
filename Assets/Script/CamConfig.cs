using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamConfig : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

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
    public float range = 5;

    OutlineObject outlineObject;
    Luz luz;
    Luz2 luz2;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
         transform.position = characterHead.position;
    }
    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.isPause == false)
        {
            ControleCam();
            look();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
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
        
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
    void look()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range),Color.red);

        if(Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if(outlineObject != null)
            {
                if(outlineObject.transform != hit.transform)
                {
                    outlineObject.Deselect();
                }
            }

            outlineObject = hit.transform.GetComponent<OutlineObject>();
            if(outlineObject != null)
            {
                outlineObject.Select();
                Debug.Log(outlineObject.name);
                if(outlineObject.CompareTag("fosforo"))
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        Player.bateriaAtual += 10;
                        Destroy(outlineObject.gameObject);
                    }
                }
                else if (outlineObject.CompareTag("carta1"))
                {
                    Carta1.podePegar = true;
                }
                else if (outlineObject.CompareTag("Luz"))
                {
                    luz = hit.transform.GetComponent<Luz>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        luz.LigaDesliga();
                    }
                }
                else if (outlineObject.CompareTag("Luz2"))
                {
                    luz2 = hit.transform.GetComponent<Luz2>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        luz2.LigaDesliga();
                    }
                }
                else if(outlineObject.CompareTag("Cama"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneManager.LoadScene("Dia2");
                    }
                }
                else if (outlineObject.CompareTag("alavanca"))
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        if(CaixaDeluz.lightout == true)
                        {
                            CaixaDeluz.lightout = false;
                        }
                        else
                        {
                            CaixaDeluz.lightout = true;
                        }
                    }
                }
            }
        }
        else
        {
            if (outlineObject != null)
            {
                outlineObject.Deselect();
                if (outlineObject.CompareTag("carta1"))
                {
                    Carta1.podePegar = false;
                }
            }
            outlineObject = null;
        }

    }
}
