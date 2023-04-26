using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChanger : MonoBehaviour
{
    private enum InitialLight
    {
        Blue, Yellow, Red, Purple
    }
    [SerializeField] private Color[] _initialColors;
    [SerializeField] private InitialLight initialLight = InitialLight.Yellow;
    [SerializeField] private Light _light;
    [SerializeField] private Material _lightbulbMaterial;
    [SerializeField] private float _interpolationTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(TurnOnInitialLight((int)initialLight));
    }

    public void ChangeLightColor(Color color)
    {
        _light.color = color;
    }

    private IEnumerator WaitToTurnOnLight(Color color)
    {
        float t = 0;
        //yield return new WaitForSeconds(1);
        Color startColor = _light.color;
        while (t < 1)
        {
            Color interpolatedColor = Color.Lerp(startColor, color, t);
            _lightbulbMaterial.SetColor("_EmissionColor", interpolatedColor);
            _light.color = interpolatedColor;
            t += Time.deltaTime / _interpolationTime;
            yield return null;
        }
        
    }

    public void TurnOnLight(Color color)
    {
        StartCoroutine(WaitToTurnOnLight(color));
    }

    private string TurnOnInitialLight(int lightIndex)
    {
        
        _light.color = _initialColors[lightIndex];
        _lightbulbMaterial.SetColor("_EmissionColor", _initialColors[lightIndex]);

        return "Light has been turned on!";
    }

    
}
