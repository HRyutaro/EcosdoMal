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

    public AudioSource sound;

    public static bool comVassoura;

    OutlineObject outlineObject;
    Luz luz;
    Luz2 luz2;
    porta porta;
    portaSemInteracao porta2;
    Carta1 carta;
    jornal jornal;
    item item;
    itemChao itemChao;
    MachadoItem machadoItem;
    vassouraItem vassoura;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        comVassoura = false;
    }
    private void LateUpdate()
    {
         transform.position = characterHead.position;
    }

    void Update()
    {
        if(GameController.instance.isPause == false)
        {
            if(Player.parado == false)
            {
                ControleCam();
            }
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
                //Debug.Log(outlineObject.name);
                if(outlineObject.CompareTag("fosforo"))
                {
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        if(inventario.fosforo <= 4)
                        {
                            inventario.fosforo++;
                            Destroy(outlineObject.gameObject);
                        }
                        else
                        {
                            GameController.instance.ShowInformacao("Ja tenho muitos guardados");
                        }
                    }
                }
                else if (outlineObject.CompareTag("carta1"))
                {
                    carta = hit.transform.GetComponent<Carta1>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        carta.togglePegar();
                    }
                }
                else if (outlineObject.CompareTag("jornal"))
                {
                    jornal = hit.transform.GetComponent<jornal>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        jornal.togglePegar();
                    }
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
                    if (Input.GetKeyDown(KeyCode.E) && GameController.instance.task == 4)
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
                else if (outlineObject.CompareTag("Porta"))
                {
                    porta = hit.transform.GetComponent<porta>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        porta.Animacao();
                    }
                }
                else if (outlineObject.CompareTag("Porta2"))
                {
                    porta2 = hit.transform.GetComponent<portaSemInteracao>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        porta2.Animacao();
                        GameController.instance.ShowInformacao("'Hmm... parece Trancado'");
                    }
                }
                else if (outlineObject.CompareTag("Gas"))
                {
                    item = hit.transform.GetComponent<item>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        item.togglePegar();
                    }
                }
                else if (outlineObject.CompareTag("GasChao"))
                {
                    itemChao = hit.transform.GetComponent<itemChao>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        itemChao.toggleColocar();
                    }
                }
                else if (outlineObject.CompareTag("Cano"))
                {
                    if(GameController.instance.task == 3 && Input.GetKey(KeyCode.E) && Cano.giradas <= 499)
                    {
                        Cano.giradas += 1f;
                        hit.transform.Rotate(new Vector3(0, 1, 0));

                    }
                }
                else if (outlineObject.CompareTag("Beer"))
                {
                    if (GameController.instance.task == 4 && Input.GetKey(KeyCode.E))
                    {
                        GameController.days = 3;
                        Player.parado = true;
                        GameController.instance.ShowInformacao("Que dia, precisava dessa bebida, devo estar vendo coisas mas deve ser so cansaço");
                        Invoke("TrocarCena", 4f);
                        if(!sound.isPlaying)
                        {
                            sound.Play();
                        }
                       
                    }
                    else if(Input.GetKey(KeyCode.E))
                    {
                        GameController.instance.ShowInformacao("Deve terminar minhas tarefas antes");
                    }
                }
                else if (outlineObject.CompareTag("roscaPia"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        if(GameController.instance.task == 2)
                        {
                            if(Pia.giros > 499 && Input.GetKeyDown(KeyCode.E))
                            {
                                Pia.tirou = true;
                                outlineObject.Deselect();
                            }
                            else if (Pia.giros <= 499)
                            {
                                Pia.giros += 1;
                                hit.transform.Rotate(new Vector3(0, 1, 0));
                            }
                        }
                        else
                        {
                            GameController.instance.ShowInformacao("Vamos ler o jornal antes de começar as tarefas");
                        }

                    }
                }
                else if (outlineObject.CompareTag("roscaPia1"))
                {
                    if (GameController.instance.task == 2 && Input.GetKey(KeyCode.E))
                    {
                        if (Pia.giros1 > 499 && Input.GetKeyDown(KeyCode.E))
                        {
                            Pia.tirou1 = true;
                            outlineObject.Deselect();
                        }
                        else if (Pia.giros1 <= 499)
                        {
                            Pia.giros1 += 1;
                            hit.transform.Rotate(new Vector3(0, 1, 0));
                        }
                    }
                }
                else if (outlineObject.CompareTag("CanoPia"))
                {
                    if (GameController.instance.task == 2 && Input.GetKey(KeyCode.E))
                    {
                        if(Pia.podeTirar2 == true)
                        {
                            Pia.tirou2 = true;
                            outlineObject.Deselect();
                        }
                    }
                }
                else if (outlineObject.CompareTag("localroscaPiaC"))
                {
                    if (GameController.instance.task == 2 && Input.GetKeyDown(KeyCode.E))
                    {
                        Pia.colocou = true;
                        outlineObject.Deselect();
                    }
                }
                else if (outlineObject.CompareTag("localroscaPiaC1"))
                {
                    if (GameController.instance.task == 2 && Input.GetKeyDown(KeyCode.E))
                    {
                        Pia.colocou1 = true;
                        outlineObject.Deselect();
                    }
                }
                else if (outlineObject.CompareTag("localCanoPiaC"))
                {
                    if (GameController.instance.task == 2 && Input.GetKeyDown(KeyCode.E))
                    {
                        Pia.colocou2 = true;
                        outlineObject.Deselect();
                    }
                }
                else if (outlineObject.CompareTag("roscaPiaC"))
                {
                    if (GameController.instance.task == 2 && Input.GetKey(KeyCode.E))
                    {
                        if (Pia.colocou == true && Pia.girosC <= 499)
                        {
                            Pia.girosC += 1;
                            hit.transform.Rotate(new Vector3(0, 1, 0));
                        }
                    }
                }
                else if (outlineObject.CompareTag("roscaPiaC1"))
                {
                    if (GameController.instance.task == 2 && Input.GetKey(KeyCode.E))
                    {
                        if (Pia.colocou == true && Pia.girosC1 <= 499)
                        {
                            Pia.girosC1 += 1;
                            hit.transform.Rotate(new Vector3(0, 1, 0));
                        }
                    }
                }
                else if (outlineObject.CompareTag("Machado"))
                {
                    machadoItem = hit.transform.GetComponent<MachadoItem>();
                    if (GameController.instance.task == 3 && Input.GetKey(KeyCode.E))
                    {
                        machadoItem.afiar();
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.E))
                        {
                            GameController.instance.ShowInformacao("primeiro devo consertar a pia");
                        }
                    }
                }
                else if(outlineObject.CompareTag("Vassoura"))
                {
                    vassoura = hit.transform.GetComponent<vassouraItem>();
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        vassoura.pegar();
                    }
                }
                else if(outlineObject.CompareTag("sujeira"))
                {
                    if (Input.GetKeyDown(KeyCode.E)&& comVassoura == true)
                    {
                        SujeiraControl.sujeiras += 1;
                        Destroy(outlineObject.gameObject);
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && comVassoura == false)
                    {
                        GameController.instance.ShowInformacao("Preciso do esfregão para limpar isso");
                    }
                }
            }
        }
        else
        {
            if (outlineObject != null)
            {
                outlineObject.Deselect();
            }
            outlineObject = null;
        }

    }

    void TrocarCena()
    {
        SceneManager.LoadScene("Dia3");
    }
}
