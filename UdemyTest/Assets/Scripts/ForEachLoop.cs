using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ForEachLoop : MonoBehaviour
{

    [SerializeField] private List<int> _integerList;
    [SerializeField] private int[] _integerArray = new int[5] { 6, 7, 8, 9, 10 };

    // Start is called before the first frame update
    void Start()
    {
        _integerList = new List<int>(Enumerable.Range(1, 10));
        //_integerList.Add(5);
        //_integerList.AddRange(_integerArray);

        //foreach (int integer in _integerList)
        //{
        //    Debug.Log(integer);
        //}
        //_integerList.Remove(9);
        //_integerList.RemoveAt(1);
        //_integerList.Clear();

        for (int i = _integerList.Count - 1; i >= 0 ; i--)
        {
            Debug.Log(_integerList[i]);
            _integerList.Remove(_integerList[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
