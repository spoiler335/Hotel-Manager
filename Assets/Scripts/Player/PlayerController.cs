using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private InputManager input => DI.di.input;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float rotationSpeed = 5f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CheckAndKeepPlayerOnGround();
        CheckInputAndMovePlayer();
        CheckAndJump();
        BringPlayerOnToGround();
        ControllPlayerRotation();
    }

    private void BringPlayerOnToGround()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void CheckAndKeepPlayerOnGround()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0) playerVelocity.y = 0f;
    }

    private void ControllPlayerRotation()
    {
        
    }

    private void CheckAndJump()
    {
        
    }

    private void CheckInputAndMovePlayer()
    {
        Vector3 move = new Vector3(input.forward, 0, input.right);
        move.y = 0;
        controller.Move(move * Time.deltaTime * speed);
        if (move != Vector3.zero) transform.forward = move;
    }
}
