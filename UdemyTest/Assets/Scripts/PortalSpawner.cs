using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{

    [SerializeField] private LightChanger _lightChanger;
    [SerializeField] private Transform _portalParent;
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
            GameObject portalGO = SpawnPortal();
            ChangeLightAndPortalToRandomColor(portalGO);
        }

    }

    private GameObject SpawnPortal()
    {
        GameObject portalGO = Instantiate(_portalPrefab, _portalParent);
        portalGO.transform.localPosition = Vector3.right * _portalParent.childCount * _portalDistance;
        return portalGO;
    }

    private void ChangeLightAndPortalToRandomColor(GameObject portalGO)
    {
        Color randomColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //_lightChanger.ChangeLightColor(randomColor);
        portalGO.GetComponentInChildren<Portal>().SetLightColor(randomColor);
        List<MeshRenderer> _meshRenderers = new List<MeshRenderer>(portalGO.GetComponentsInChildren<MeshRenderer>());
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material.SetColor("_EmissionColor", randomColor);
        }
    }
}
