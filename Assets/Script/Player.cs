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

    public static bool comItem;

    [Header("MoviConf")]
    public Animator anim;
    public float forwardSpeed = 5f;
    public float atualforwardSpeed;
    public float strafeSpeed = 5f;
    public float atualstrafeSpeed;
    public static bool parado;
    bool agachado;
    bool isRunnig;
    public AudioSource walkSound;
    public AudioSource runSound;

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

        atualforwardSpeed = forwardSpeed;
        atualstrafeSpeed = strafeSpeed;

        bateriaAtual = bateriaMax;
    }


    void Update()
    {
        if(parado == false)
        {
            Move();
            Agachar();
            animacao();
            Lanterna();

            if (comItem == false)
            {
                ToggleCaderno();
            }
            else
            {
                caderno.SetActive(false);
            }
        }
    }

    void animacao()
    {
        if(Input.GetButton("Vertical"))
        {
            anim.SetFloat("isWalk", 1);
            if (!walkSound.isPlaying && agachado == false && isRunnig == false)
            {
                walkSound.Play();
                runSound.Stop();
            }
            else if(!runSound.isPlaying  && isRunnig == true )
            {
                walkSound.Stop();
                runSound.Play();
            }
        }
        else
        {
            anim.SetFloat("isWalk", 0);
            walkSound.Stop();
            runSound.Stop();
        }
    }

    void Move()
    {
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * atualforwardSpeed * transform.forward;
        strafe = strafeInput * atualstrafeSpeed * transform.right;

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
        if (Input.GetKeyDown(KeyCode.LeftShift)&& agachado == false)
        {
            atualforwardSpeed = 2 * forwardSpeed;
            atualstrafeSpeed = 2 * strafeSpeed;
            isRunnig = true;
            anim.speed = 1.5f;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)&& agachado == false)
        {
            atualforwardSpeed = forwardSpeed;
            atualstrafeSpeed =  strafeSpeed;
            isRunnig = false;
            anim.speed = 0.5f;
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

            if(bateriaAtual >= 7.5f)
            {
                lanterna.intensity = 2;
            }
            else if(bateriaAtual <= 7.5f)
            {
                lanterna.intensity = 1;
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
        if(Input.GetKeyDown(KeyCode.Tab))
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

    void Agachar()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            agachado = true;
            anim.SetBool("agachado", true);
            atualforwardSpeed = 2.5f;
            atualstrafeSpeed = 2.5f;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            agachado = false;
            anim.SetBool("agachado", false);
            atualforwardSpeed = forwardSpeed;
            atualstrafeSpeed = strafeSpeed;
        }
    }
}
