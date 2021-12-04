using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLook : MonoBehaviour
{
    public float lookSpeed = 100f;
    public Transform character;
    float xRotation = 0f;
    public GameObject cameraGoesHere;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        cameraGoesHere.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        character.Rotate(Vector3.up * mouseX);
    }
}
