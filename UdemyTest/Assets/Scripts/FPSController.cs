using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{


    [SerializeField] private Rigidbody rig;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform cameraTransforn;
    [SerializeField] private float mouseSensetivity = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 cameraForwardDir = cameraTransforn.forward;
        cameraForwardDir.y = 0;
        Vector3 cameraRightDir = cameraTransforn.right;
        cameraRightDir.y = 0;
        Vector3 movementDir = cameraForwardDir.normalized * vertical + cameraRightDir.normalized * horizontal;
        movementDir = new Vector3(movementDir.x, rig.velocity.y, movementDir.z);
        rig.velocity = Vector3.ClampMagnitude(movementDir, 1) * speed;

        rig.angularVelocity = Vector3.zero;

        //if (cameraTransforn.rotation.eulerAngles.x - mouseY > 280 || cameraTransforn.rotation.eulerAngles.x - mouseY < 80)
        float newAngleX = cameraTransforn.rotation.eulerAngles.x - mouseY * mouseSensetivity;
        if (newAngleX > 180)
        {
            newAngleX = newAngleX - 360;
        }
        newAngleX = Mathf.Clamp(newAngleX, -80, 80);
        cameraTransforn.rotation = Quaternion.Euler(newAngleX, cameraTransforn.rotation.eulerAngles.y, cameraTransforn.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseX * mouseSensetivity, transform.rotation.eulerAngles.z);
    }
}
