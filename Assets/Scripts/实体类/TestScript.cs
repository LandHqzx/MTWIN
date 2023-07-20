using UnityEngine;

public class TestScript : MonoBehaviour
{
    private ItemGeneratorManager itemGenerator; // 对应的ItemGenerator脚本

    void Start()
    {
        Debug.Log("start");
        itemGenerator = GetComponent<ItemGeneratorManager>();

        // 获取静态生产任务数据
        var productionTasks = ProductionTaskManager.StaticData.GetStaticProductionTasks();

        // 在控制台输出静态生产任务数据
        foreach (var task in productionTasks)
        {
            Debug.Log($"Task ID: {task.taskId}, Part Name: {task.partName}, Quantity: {task.quantity}, Production Time: {task.productionTime}, Production Internal: {task.productionInterval}");

            // 根据任务信息调用GenerateItem方法生成对应的零件
            StartCoroutine(itemGenerator.GenerateItem(task.partName, task.quantity, task.productionTime, task.productionInterval)); 
        }
    }
}
