using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private static string name = "StartPanel";
    private static string path = "Panel/StartPanel";
    public static readonly UIType uIType = new UIType(path,name);

    public StartPanel() : base(uIType)
    {

    }



    public override void OnStart()//在UIManager中，当当前Panel被Push后OnStart会自动执行。
    {
        base.OnStart();
        UIMethods.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "switchview").onClick.AddListener(CameraSwitcher.instance.ToggleCamera);

    }



    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        Debug.Log("StartPanel back");
        base.OnDisable();
    }

    public override void OnDestory()
    {
        base.OnDestory();
    }
}
