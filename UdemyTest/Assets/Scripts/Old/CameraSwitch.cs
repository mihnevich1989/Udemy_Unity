using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    private Camera mainCameraComponent;
    [SerializeField] private Camera otherCameraComponent;
    [SerializeField] private Score scoreScript;
    public bool isOnMainCamera = true;

    // Start is called before the first frame update
    void Start()
    {
        mainCameraComponent = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            mainCameraComponent.depth = 1;
            otherCameraComponent.depth = 0;
            scoreScript.scoreValue++;
            scoreScript.scoreText.text = "Score: " + scoreScript.scoreValue.ToString();
            isOnMainCamera = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            mainCameraComponent.depth = 0;
            otherCameraComponent.depth = 1;
            scoreScript.scoreValue++;
            scoreScript.scoreText.text = "Score: " + scoreScript.scoreValue.ToString();
            isOnMainCamera = false;
        }

    }
}
