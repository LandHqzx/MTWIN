using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SaveSystemTutorial;
public class Json : MonoBehaviour
{
    private void Start()
    {
        Save();
    }
    public int taskId=1;
    public string partName="fan";
    public int quantity;
    public string productionTime;
    [System.Serializable] class ProductionTask
    {
        public int taskId;
        public string partName;
        public int quantity;
        public string productionTime;
        public float productionInterval = 5.0f; // 生产时间间隔
    }

    const string PLAYER_DATA_KEY = "PlayerData";
    const string PLAYER_DATA_FILE_NAME = "PlayerData.sav";

    public void Save()
    {
        // SaveByPlayerPrefs();
        SaveByJson();
    }

    public void Load()
    {
        // LoadFromPlayerPrefs();
        LoadFromJson();
    }


    #region JSON

    void SaveByJson()
    {
        SaveSystem.SaveByJson(PLAYER_DATA_FILE_NAME, SavingData());
        // SaveSystem.SaveByJson($"{System.DateTime.Now:yyyy.dd.M HH-mm-ss}.sav", SavingData());
    }

    void LoadFromJson()
    {
        var saveData = SaveSystem.LoadFromJson<ProductionTask>(PLAYER_DATA_FILE_NAME);

        LoadData(saveData);
    }

    #endregion

    #region Help Functions

    ProductionTask SavingData()
    {
        var saveData = new ProductionTask();

        saveData.partName = partName;
        saveData.quantity = quantity;
        saveData.taskId= taskId;
        saveData.productionTime = productionTime;

        return saveData;
    }

    void LoadData(ProductionTask saveData)
    {
        partName = saveData.partName;
        quantity = saveData.quantity;
        taskId= saveData.taskId;
    }
    #endregion
}
