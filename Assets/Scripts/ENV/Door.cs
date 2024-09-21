using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Quaternion closedRotation;
    private Quaternion openRotation;
    private float speed = 2.0f;
    private bool isOpen = false;

    private void Start()
    {
        closedRotation = transform.rotation; // Save the closed state
        openRotation = Quaternion.Euler(0, 90, 0) * closedRotation; // Define the open state
        ToggleDoor();
    }

    private void ToggleDoor()
    {
        StartCoroutine(RotateDoor());
    }

    private IEnumerator RotateDoor()
    {
        float elapsedTime = 0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = isOpen ? closedRotation : openRotation;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * speed;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }

        transform.rotation = targetRotation;
        isOpen = !isOpen;
    }

}
