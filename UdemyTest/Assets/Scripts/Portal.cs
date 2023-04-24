using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    ///����� �� ������ � �������
    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player enter the Trigger!");
    }*/

    ///����� �� ������� �� �������
    /*private void OnTriggerExit(Collider other)
    {
        Debug.Log("Player out of portal!");
    }*/

    private Light _lightToTurnOn;
    [SerializeField] private LightChanger _lightChanger;

    private void Awake()
    {
        _lightChanger = FindObjectOfType<LightChanger>();
    }

    public void SetLightToTurnOn(Light light)
    {
        _lightToTurnOn = light;
    }

    ///����� �� ��������� � �������
    private void OnTriggerEnter(Collider other)
    {
        ///other.name.Equals("Player")
        ///other.tag.Equals("Player")
        ///other.GetComponent<FPSController>() != null
        ///other.gameObject.layer == LayerMask.NameToLayer("Player")
        if (other.GetComponent<FPSController>() != null)
        {
            _lightChanger.TurnOnLight(_lightToTurnOn);
        }
    }

    
}
