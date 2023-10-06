using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    [Header("MoviConf")]
    public Animator anim;
    public float forwardSpeed = 5f;
    public float strafeSpeed = 5f;
    public static bool parado;

    public float gravity;
    float jumpSpeed;
    float maxJumpHeight = 1.5f;
    float timetoMaxHeight = 0.5f;

    [Header("LanternConf")]
    public GameObject lanternaObjeto;
    public Light lanterna;
    public float bateriaMax;
    public static float bateriaAtual;
    public Slider imagemBateria;

    [Header("Caderno")]
    public GameObject caderno;
    bool cadernoNaMao;
    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timetoMaxHeight * timetoMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timetoMaxHeight;

        bateriaAtual = bateriaMax;
    }


    void Update()
    {
        if(parado == false)
        {
            Move();
            Lanterna();
            ToggleCaderno();
        }
    }

    void animacao()
    {
        if(Input.GetButton("Vertical"))
        {
            anim.SetFloat("isWalk", 1);
        }
        else
        {
            anim.SetFloat("isWalk", 0);
        }
    }

    void Move()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;

        vertical += gravity * Time.deltaTime * Vector3.up;
        if(controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        //if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        //{
        //    vertical = jumpSpeed  * Vector3.up;
        //}
        //if(vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        //{
        //    vertical = Vector3.zero;
        //}

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            forwardSpeed = 10f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            forwardSpeed = 5f;
        }
    }
    void Lanterna()
    {
        // Verifica se a lanterna está ligada
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleLanterna();
            
        }

        // Verifica se a lanterna está ligada e a bateria não está vazia
        if (lanterna.enabled && bateriaAtual > 0)
        {
            // Reduz a bateria com o tempo (ajuste o valor como desejado)
            bateriaAtual -= Time.deltaTime;

            // Atualiza a intensidade da luz com base na carga da bateria
            if(bateriaAtual >= bateriaMax/2)
            {
                lanterna.intensity = 2;
            }
            else if(bateriaAtual <= bateriaMax/2)
            {
                lanterna.intensity = 1;
            }
            else if(bateriaAtual <= 7.5f)
            {
                lanterna.intensity = 0.5f;
            }
        }
        else
        {
            // Desliga a lanterna quando a bateria estiver vazia
            lanterna.enabled = false;
            lanternaObjeto.SetActive(false);
        }

        imagemBateria.value = bateriaAtual;
    }

    void ToggleLanterna()
    {
        // Liga ou desliga a lanterna
        lanterna.enabled = !lanterna.enabled;
        if(lanterna.enabled == true)
        {
            lanternaObjeto.SetActive(true);
        }
        else
        {
            lanternaObjeto.SetActive(false);
        }
    }

    void ToggleCaderno()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            cadernoNaMao = !cadernoNaMao;
        }
        if(cadernoNaMao == true)
        {
            caderno.SetActive(true);
        }
        else
        {
            caderno.SetActive(false);
        }

    }
}
