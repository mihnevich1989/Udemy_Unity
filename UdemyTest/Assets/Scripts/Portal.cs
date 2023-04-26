using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    ///Когда мы входим в триггер
    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player enter the Trigger!");
    }*/

    ///Когда мы выходим из триггер
    /*private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player out of portal!");
    }*/

    private Color _lightColor;
    [SerializeField] private LightChanger _lightChanger;

    private void Awake()
    {
        _lightChanger = FindObjectOfType<LightChanger>();
    }

    public void SetLightColor(Color color)
    {
        _lightColor = color;
    }

    ///Когда мы находимся в триггер
    private void OnTriggerEnter(Collider other)
    {
        ///other.name.Equals("Player")
        ///other.tag.Equals("Player")
        ///other.GetComponent<FPSController>() != null
        ///other.gameObject.layer == LayerMask.NameToLayer("Player")
        if (other.GetComponent<FPSController>() != null)
        {
            _lightChanger.TurnOnLight(_lightColor);
        }
    }

    
}
