using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreValue;
    public Text scoreText;
    [SerializeField] private CameraSwitch cameraSwith;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + scoreValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cameraSwith.isOnMainCamera)
            {
                scoreValue++;
                scoreText.text = "Score: " + scoreValue.ToString();

                switch (scoreValue)
                {
                    case 10:
                        scoreText.color = Color.green;
                        break;
                    case 20:
                        scoreText.color = Color.yellow;
                        break;
                    default:
                        scoreText.color = Color.red;
                        break;
                }
                //if (scoreValue > 10)
                //{
                //    scoreText.color = Color.yellow;
                //}
            }
            else
            {
                scoreValue--;
                scoreText.text = "Score: " + scoreValue.ToString();
                if (scoreValue < 10)
                {
                    scoreText.color = Color.green;
                }
            }
        }
    }
}
