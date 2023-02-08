using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LinearSearch : MonoBehaviour
{
    [SerializeField] 
    private int searchItem;
    [SerializeField]
    private int[] searchArray;
    private Button _searchButton;
    private const string SearchButtonName = "LinearSearchButton";


    private void Awake()
    {
        var arrayLength = Random.Range(10, 100);
        searchArray = new int[arrayLength];
        searchItem = Random.Range(1, 100);
        _searchButton = GameObject.Find(SearchButtonName).GetComponent<Button>();
        _searchButton.onClick.AddListener(LogSearchResult);

        for (var i = 0; i < arrayLength; i++)
        {
            searchArray[i] = Random.Range(1, 100);
        }
    }

    private int Search()
    {
        var result = -1;

        for (var i = 0; i < searchArray.Length; i++)
        {
            var arrayItem = searchArray[i];
            
            if (searchItem == arrayItem)
            {
                result = i;
            }
        }

        return result;
    }
    
    private void LogSearchResult()
    {
        var index = Search();
        
        if (index >= 0)
        {
            Debug.Log($"Элемент {searchItem} находится на позиции {index}");
        }
        else
        {
            Debug.Log($"Элемент {searchItem} отсутствует в массиве");
        }
    }
}
