using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    private enum InitialLight
    {
        Blue, Yellow, Red, Purple
    }

    [SerializeField] private InitialLight initialLight = InitialLight.Yellow;
    [SerializeField] private List<Light> _lights;
    [SerializeField] private Material _lightbulbMaterial;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TurnOnInitialLight((int)initialLight));
    }

    private IEnumerator WaitToTurnOnLight(Light light)
    {
        yield return new WaitForSeconds(1);

        for (int i = 0; i < _lights.Count; i++)
        {
            _lights[i].gameObject.SetActive(false);
        }
        _lightbulbMaterial.SetColor("_EmissionColor", light.color);
        light.gameObject.SetActive(true);
    }

    public void AddLightToList(Light light)
    {
        _lights.Add(light);
    }

    public void TurnOnLight(Light light)
    {
        StartCoroutine(WaitToTurnOnLight(light));
    }

    private string TurnOnInitialLight(int lightIndex)
    {
        for (int i = 0; i < _lights.Count; i++)
        {
            _lights[i].gameObject.SetActive(false);
        }
        _lights[lightIndex].gameObject.SetActive(true);
        _lightbulbMaterial.SetColor("_EmissionColor", _lights[lightIndex].color);

        return "Light has been turned on!";
    }

    
}
