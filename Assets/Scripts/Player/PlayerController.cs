using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;
    private InputManager input => DI.di.input;
    private CharacterController controller;
    private Transform cameraTrans;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraTrans = Camera.main.transform;
    }

    private void Start()
    {
#if UNITY_EDITOR
        speed = 100f;
#endif
    }
    private void Update()
    {
        CheckInputAndMovePlayer();
        CheckForwardRay();
    }


    private void CheckForwardRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 10f))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);

        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * 10f, Color.green);
        }
    }

    private void CheckInputAndMovePlayer()
    {
        Vector3 move = new Vector3(input.forward, 0, input.right);
        move.y = 0;
        controller.Move(move * Time.deltaTime * speed);
        if (move != Vector3.zero) transform.forward = move;
    }
}
