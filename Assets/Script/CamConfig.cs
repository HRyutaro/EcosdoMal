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
    public float offsetDistance = 1.0f;

    public AudioSource sound;
    public AudioSource canoRangendo;

    public static bool comVassoura;
    public static bool comArma;

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
    ArmaChao armachao;

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
        Vector3 startOffset = transform.forward * offsetDistance;
        Ray theRay = new Ray(transform.position + startOffset, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position + startOffset, transform.TransformDirection(direction * range),Color.red);

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
                if (outlineObject.CompareTag("fosforo"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (inventario.fosforo <= 4)
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
                else if (outlineObject.CompareTag("Cama"))
                {
                    if (Input.GetKeyDown(KeyCode.E) && GameController.instance.task == 4)
                    {
                        GameController.instance.task = 1;
                        SceneManager.LoadScene("Dia2");
                    }
                }
                else if (outlineObject.CompareTag("alavanca"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (GameController.instance.Dia <= 4)
                        {
                            if (CaixaDeluz.lightout == true)
                            {
                                CaixaDeluz.lightout = false;
                            }
                            else
                            {
                                CaixaDeluz.lightout = true;
                            }
                        }
                        else if (GameController.instance.Dia == 5)
                        {
                            GameController.instance.ShowInformacao("'Esta emperrado, não tem jeito, melhor eu pegar o machado e resolver isso'");
                            task1dia5.tentouAtivar = true;
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
                    if (Input.GetKeyDown(KeyCode.E) && GameController.instance.task == 2)
                    {
                        item.togglePegar();
                    }
                    else if(Input.GetKeyDown(KeyCode.E) && GameController.instance.task != 2)
                    {
                        GameController.instance.ShowInformacao("Primeiro as noticias depois o trabalho");
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

                    if (GameController.instance.task == 3 && Input.GetKey(KeyCode.E) && Cano.giradas <= 499)
                    {
                        Cano.giradas += 1f;
                        hit.transform.Rotate(new Vector3(0, 1, 0));
                        if (!canoRangendo.isPlaying)
                        {
                            canoRangendo.Play();
                        }
                    }
                    else
                    {
                        if (canoRangendo.isPlaying)
                        {
                            canoRangendo.Stop();
                        }
                    }
                }
                else if (outlineObject.CompareTag("Beer"))
                {
                    if (GameController.instance.task == GameController.instance.tarefas.Length && Input.GetKey(KeyCode.E) && GameController.instance.Dia != 5)
                    {
                        Player.parado = true;
                        GameController.instance.task = 1;
                        if (GameController.days == 2)
                        {
                            GameController.instance.ShowInformacao("Que dia, precisava dessa bebida, devo estar vendo coisas, mas deve ser so cansaço");
                            Invoke("TrocarCena", 5f);
                        }
                        else if (GameController.days == 3)
                        {
                            GameController.instance.ShowInformacao("Estou comecando a alucinar, preciso beber pra relaxar");
                            Invoke("TrocarCena2", 4f);
                        }
                        else if (GameController.days == 4)
                        {
                            GameController.instance.ShowInformacao("Alucinação, alucinação e tudo alucinação, se acalma");
                            Invoke("TrocarCena3", 4f);
                        }
                        
                        if (!sound.isPlaying)
                        {
                            sound.Play();
                        }

                    }
                }
                else if (outlineObject.CompareTag("roscaPia"))
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (GameController.instance.task == 2)
                        {
                            if (Pia.giros > 499 && Input.GetKeyDown(KeyCode.E))
                            {
                                Pia.tirou = true;
                                outlineObject.Deselect();
                            }
                            else if (Pia.giros <= 499)
                            {
                                Pia.giros += 1;
                                hit.transform.Rotate(new Vector3(0, 1, 0));
                                if (!canoRangendo.isPlaying)
                                {
                                    canoRangendo.Play();
                                }
                            }
                        }
                        else
                        {
                            GameController.instance.ShowInformacao("Vamos ler o jornal antes de começar as tarefas");
                        }
                    }
                    else
                    {
                        if (canoRangendo.isPlaying)
                        {
                            canoRangendo.Stop();
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
                            if (!canoRangendo.isPlaying)
                            {
                                canoRangendo.Play();
                            }
                        }
                    }
                    else
                    {
                        if (canoRangendo.isPlaying)
                        {
                            canoRangendo.Stop();
                        }
                    }
                }
                else if (outlineObject.CompareTag("CanoPia"))
                {
                    if (GameController.instance.task == 2 && Input.GetKey(KeyCode.E))
                    {
                        if (Pia.podeTirar2 == true)
                        {
                            Pia.tirou2 = true;
                            outlineObject.Deselect();
                        }
                        else
                        {
                            GameController.instance.ShowInformacao("Tire as outras partes primeiro");
                        }
                    }
                    else if(GameController.instance.task != 2 && Input.GetKey(KeyCode.E))
                    {
                        GameController.instance.ShowInformacao("Vamos ler o jornal antes de começar as tarefas");
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
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (GameController.instance.Dia == 5 && GameController.instance.task == 2)
                        {
                            MachadoDia55.pegou = true;
                        }
                        else if (GameController.instance.Dia == 5 && GameController.instance.task <= 1)
                        {
                            GameController.instance.ShowInformacao("Primeiro devo ligar as luzes");
                        }
                        else if (GameController.instance.task == 3 && GameController.instance.Dia <= 4)
                        {
                            machadoItem.afiar();
                        }
                        else if (GameController.instance.task != 3 && GameController.instance.Dia <= 4)
                        {
                            GameController.instance.ShowInformacao("primeiro devo consertar a pia");
                        }
                    }
                }
                else if (outlineObject.CompareTag("Vassoura"))
                {
                    vassoura = hit.transform.GetComponent<vassouraItem>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        vassoura.pegar();
                    }
                }
                else if (outlineObject.CompareTag("sujeira"))
                {
                    if (Input.GetKeyDown(KeyCode.E) && comVassoura == true)
                    {
                        SujeiraControl.sujeiras += 1;
                        Destroy(outlineObject.gameObject);
                    }
                    else if (Input.GetKeyDown(KeyCode.E) && comVassoura == false)
                    {
                        GameController.instance.ShowInformacao("Preciso do esfregão para limpar isso");
                    }
                }
                else if (outlineObject.CompareTag("Arma"))
                {
                    armachao = hit.transform.GetComponent<ArmaChao>();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        armachao.pegar();
                    }
                }
                else if (outlineObject.CompareTag("Labirinto"))
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (GameController.instance.task == 4)
                        {
                            SceneManager.LoadScene("Labirinto");
                        }
                        else if (GameController.instance.task == 1)
                        {
                            GameController.instance.ShowInformacao("Ligar a luz primeiro depois ir por jardim");
                        }
                        else if (GameController.instance.task == 2)
                        {
                            GameController.instance.ShowInformacao("Preciso pegar o machado");
                        }
                        else if (GameController.instance.task == 3)
                        {
                            GameController.instance.ShowInformacao("AcABaR COm EsSAS AluCinAÇõEs");
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
                canoRangendo.Stop();
            }
            outlineObject = null;
        }

    }

    void TrocarCena()
    {
        Player.parado = false;
        SceneManager.LoadScene("Dia3");
    }

    void TrocarCena2()
    {
        Player.parado = false;
        SceneManager.LoadScene("Dia4");
    }
    void TrocarCena3()
    {
        Player.parado = false;
        SceneManager.LoadScene("Dia5");
    }
}
