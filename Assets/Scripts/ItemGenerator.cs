using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject itemPrefab; // 要生成的物品预制体

    [SerializeField]
    private int quantity = 1; // 要生成的总数量

    [SerializeField]
    private float generationInterval = 1f; // 生成物品的时间间隔

    private int generatedCount = 0; // 已生成的数量
    private float timer; // 计时器

    void Update()
    {
        if (generatedCount >= quantity)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= generationInterval)
        {
            timer = 0f;
            generatedCount++;

            GameObject newItem = Instantiate(itemPrefab, transform.position, Quaternion.identity);
            newItem.SetActive(true); // 设置新生成的物品为显示状态
        }
    }
}
