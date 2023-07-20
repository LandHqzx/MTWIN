using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGeneratorManager : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, GameObject> itemPrefabDict; // 预制体字典，用于存储零件名称与预制体的映射关系
    [SerializeField]
    public GameObject fan;
    //必须在Awake中初始化，否则在Start中被调用时还未初始化，会报错
    void Awake()
    {
        BuildItemPrefabDict(); // 构建预制体字典
    }

    private void BuildItemPrefabDict()
    {
        itemPrefabDict = new Dictionary<string, GameObject>();
        
        /*
        if ( GameObject.FindGameObjectsWithTag("fan")[0])
        {
            Debug.Log("Successfully found 'fan' game object.");
        }
        else
        {
            Debug.LogError("Failed to find 'fan' game object.");
        }
        */
        // 添加预制体映射关系
        itemPrefabDict.Add("fan", fan);
        
        // 添加更多映射关系...
    }

    public IEnumerator GenerateItem(string partName, int quantity, string productionTime,float productionInterval)
    {
        if (!itemPrefabDict.ContainsKey(partName))
        {
            Debug.LogError($"No prefab found for part name: {partName}");
            yield break; // 终止协程并立即退出
        }

        GameObject itemPrefab = itemPrefabDict[partName];

        for (int i = 0; i < quantity; i++)
        {
            GameObject newItem = Instantiate(itemPrefab, itemPrefab.transform.position, Quaternion.identity);
            newItem.SetActive(true); // 设置新生成的物品为显示状态

            // 在这里根据需要对生成的零件进行其他操作
            // 可以使用传入的partName和productionTime等信息

            yield return new WaitForSeconds(productionInterval);
        }
    }
  
}
