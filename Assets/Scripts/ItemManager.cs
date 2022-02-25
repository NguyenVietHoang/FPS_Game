using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> prefabList;
    [SerializeField]
    private List<Transform> spawnPosList;

    private Dictionary<int, Item> itemInstantiated;

    // Start is called before the first frame update
    void Start()
    {
        itemInstantiated = new Dictionary<int, Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if(prefabList != null && spawnPosList != null)
        {
            for (int i = 0; i < spawnPosList.Count; i++)
            {
                //This position does not have item yet
                if (!itemInstantiated.ContainsKey(i))
                {
                    SpawnRandomItem(spawnPosList[i], i);
                }
            }
        }        
    }

    /// <summary>
    /// Spawn an Item on the field
    /// </summary>
    /// <param name="spawnPos">Position where we sapwn the obj</param>
    /// <param name="itemId">The position Id</param>
    public void SpawnRandomItem(Transform spawnPos, int itemId)
    {
        ItemData randomItem = prefabList[Random.Range(0, prefabList.Count)];
        GameObject tmpObj = Instantiate(randomItem.Model, spawnPos, false);

        //Add the Item Script to the obj
        Item tmpItem = tmpObj.GetComponent<Item>();
        tmpItem.SetData(itemId);
        tmpItem.OnDestroyTime += DestroyItem;

        //Add this new Object to manager's list
        itemInstantiated.Add(itemId, tmpItem);
    }

    public void DestroyItem(int itemKey)
    {
        StartCoroutine(OnDelayDestroy(itemKey));
    }

    float delayTime = 2.0f;
    IEnumerator OnDelayDestroy(int itemKey)
    {
        if (itemInstantiated.ContainsKey(itemKey))
        {
            yield return new WaitForSeconds(delayTime);

            Destroy(itemInstantiated[itemKey].gameObject);
            itemInstantiated.Remove(itemKey);
        }
    }
}
