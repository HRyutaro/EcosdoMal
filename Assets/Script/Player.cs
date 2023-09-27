using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;

    [Header("MoviConf")]
    public float forwardSpeed = 5f;
    public float strafeSpeed = 5f;

    float gravity;
    float jumpSpeed;
    float maxJumpHeight = 1.5f;
    float timetoMaxHeight = 0.5f;

    [Header("LanternConf")]
    public Light lanterna;
    public float bateriaMax;
    public float bateriaAtual;
    public float intensidadeLanAtual;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        gravity = (-2 * maxJumpHeight) / (timetoMaxHeight * timetoMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timetoMaxHeight;

        bateriaAtual = bateriaMax;
        intensidadeLanAtual = lanterna.intensity;
    }


    void Update()
    {
        Move();
        Lanterna();
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

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }
        if(vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

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
            intensidadeLanAtual -= 0.05f * Time.deltaTime;

            // Atualiza a intensidade da luz com base na carga da bateria
            lanterna.intensity = intensidadeLanAtual;
        }
        else
        {
            // Desliga a lanterna quando a bateria estiver vazia
            lanterna.enabled = false;
        }
    }

    void ToggleLanterna()
    {
        // Liga ou desliga a lanterna
        lanterna.enabled = !lanterna.enabled;
    }

}
