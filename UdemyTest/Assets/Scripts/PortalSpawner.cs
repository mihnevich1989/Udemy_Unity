using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{

    [SerializeField] private LightChanger _lightChanger;
    [SerializeField] private Transform _portalParent;
    [SerializeField] private GameObject _lightPrefab;
    [SerializeField] private GameObject _portalPrefab;
    [SerializeField] private float _portalDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Light light = SpawnLight();
            _lightChanger.AddLightToList(light);

            GameObject portalGO = SpawnPortal();

            portalGO.GetComponentInChildren<Portal>().SetLightToTurnOn(light);
            ChangeLightAndPortalToRandomColor(portalGO, light);
        }

    }

    private GameObject SpawnPortal()
    {
        GameObject portalGO = Instantiate(_portalPrefab, _portalParent);
        portalGO.transform.localPosition = Vector3.right * _portalParent.childCount * _portalDistance;
        return portalGO;
    }

    private Light SpawnLight()
    {
        GameObject lightGO = Instantiate(_lightPrefab, _lightChanger.transform);
        lightGO.transform.localPosition = Vector3.zero;
        lightGO.SetActive(false);
        return lightGO.GetComponent<Light>();
    }

    private static void ChangeLightAndPortalToRandomColor(GameObject portalGO, Light light)
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        light.color = randomColor;
        //_lightChanger.lightbulbMaterial.SetColor("_EmissionColor", randomColor);

        List<MeshRenderer> _meshRenderers = new List<MeshRenderer>(portalGO.GetComponentsInChildren<MeshRenderer>());
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material.SetColor("_EmissionColor", randomColor);
        }
    }
}
