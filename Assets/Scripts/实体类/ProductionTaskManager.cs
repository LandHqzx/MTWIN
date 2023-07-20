using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProductionTask
{
    public string taskId;
    public string partName;
    public int quantity;
    public string productionTime;
    public float productionInterval=5.0f; // 生产时间间隔

    public ProductionTask(string taskId, string partName, int quantity, string productionTime)
    {
        this.taskId = taskId;
        this.partName = partName;
        this.quantity = quantity;
        this.productionTime = productionTime;
    }
}

public class ProductionTaskManager : MonoBehaviour
{
    // 其他脚本的功能...

    // StaticData类
    public static class StaticData
    {
        public static List<ProductionTask> GetStaticProductionTasks()
        {
            List<ProductionTask> tasks = new List<ProductionTask>();

            // 添加硬编码的静态数据
            tasks.Add(new ProductionTask("1", "fan", 10, "2023-07-14 09:00"));
            // 添加更多任务...

            return tasks;
        }
    }

    // 其他脚本的功能...
}
