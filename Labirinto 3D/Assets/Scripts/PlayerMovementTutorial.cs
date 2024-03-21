using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f; // Velocidade de movimento padrão
    public float sprintSpeed = 8f; // Velocidade de movimento quando correndo
    public float groundDrag = 6f; // Arrasto no chão para desacelerar o jogador
    public float airMultiplier = 0.4f; // Fator de multiplicação para movimento no ar

    [Header("Ground Check")]
    public float playerHeight = 1.8f; // Altura do jogador
    public LayerMask whatIsGround; // Máscara de camada para verificar se o jogador está no chão

    [Header("References")]
    public Transform orientation; // Referência para a direção do jogador

    private Rigidbody rb; // Referência para o componente Rigidbody
    private bool grounded; // Flag para verificar se o jogador está no chão

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // Verifica se o jogador está no chão
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        // Entrada do jogador
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Move o jogador
        if (grounded)
        {
            rb.drag = groundDrag; // Aplica o arrasto no chão

            // Define a velocidade de movimento de acordo com a entrada do jogador
            float speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
            rb.velocity = moveDirection.normalized * speed;
        }
        else
        {
            rb.drag = 0; // Remove o arrasto se o jogador estiver no ar

            // Adiciona força para movimento no ar
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier);
        }
    }
}

