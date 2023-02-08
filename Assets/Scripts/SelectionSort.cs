using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SelectionSort : MonoBehaviour
{
    [SerializeField] private int[] notSortedArray;
    private Button _sortButton;
    private const string SortButtonName = "SelectionSortButton";

    private void Awake()
    {
        var arrayLength = Random.Range(5, 20);
        notSortedArray = new int[arrayLength];
        
        for (var i = 0; i < arrayLength; i++)
        {
            notSortedArray[i] = Random.Range(1, 100);
        }
        
        _sortButton = GameObject.Find(SortButtonName).GetComponent<Button>();
        _sortButton.onClick.AddListener(LogSortArray);
    }

    private void LogSortArray()
    {
        int[] sortedArray = Sort(notSortedArray);

        Debug.Log(string.Join(" ", sortedArray));
    }

    private int[] Sort(int[] array)
    {
        int arrayLength = array.Length;
        int[] innerArray = new int[arrayLength];
        
        Array.Copy(array, innerArray, arrayLength);
        
        for (var i = 0; i < innerArray.Length; i++)
        {
            var minIndex = i;
            
            for (var j = i; j < innerArray.Length; j++)
            {
                if (innerArray[minIndex] > innerArray[j])
                {
                    minIndex = j;
                }
            }

            (innerArray[i], innerArray[minIndex]) = (innerArray[minIndex], innerArray[i]);
        }

        return innerArray;
    }
}
