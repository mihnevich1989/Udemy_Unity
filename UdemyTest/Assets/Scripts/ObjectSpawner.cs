using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //[SerializeField] private int _numberToSpawn = 1;
    [SerializeField] private GameObject _objectToSpawn;
    [SerializeField] private int[,] _array;

    [SerializeField] private int[] _basicArray = new int[5] {1, 5, 4, 3, 1};

    private void Start()
    {
        //_array = new int[10,10];
        //for (int i = 0; i < _array.GetLength(0); i++)
        //{
        //    for (int j = 0; j < _array.GetLength(1); j++)
        //    {
        //        _array[i, j] = i * _array.GetLength(0) + j;
        //        Debug.Log(_array[i,j]);
        //    }
        //}
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            /*int currentChildCount = transform.childCount;
            for (int i = currentChildCount; i < currentChildCount + _numberToSpawn; i++)
            {
                GameObject spawnedObject = Instantiate(_objectToSpawn, transform);
                spawnedObject.name = i.ToString();
                spawnedObject.transform.localPosition = new Vector3(0, i, 0);
                spawnedObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 10 * i, 0));
                
            }*/
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            int currentChildCount = transform.childCount;
            // Вариант 1
            /*while (currentChildCount > 0)
            {
                Destroy(transform.GetChild(currentChildCount - 1).gameObject);
                currentChildCount--;
               
            }*/

            // Вариант 2
            /* for (int i = 1; i <= currentChildCount; i++)
             {
                 Destroy(transform.GetChild(currentChildCount - i).gameObject);

             }*/

            // Вариант 3
            /*for (int i = currentChildCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }*/
        }

    }
}
