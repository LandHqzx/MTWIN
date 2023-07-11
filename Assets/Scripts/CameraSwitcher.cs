using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera godCamera;

    public FirstPersonMovement MovementScript;  // 角色移动脚本
    public Jump JumpScript;  // 角色跳跃脚本
    public Crouch CrouchScript;  // 角色下蹲脚本

    void Start()
    {
        // 初始化时启用第一人称摄像头，禁用上帝视角摄像头
        firstPersonCamera.enabled = true;
        godCamera.enabled = false;
    }

    void Update()
    {
        // 按下"P"键切换摄像头
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleCamera();
        }
    }

    void ToggleCamera()
    {
        // 切换摄像头的启用状态
        firstPersonCamera.enabled = !firstPersonCamera.enabled;
        godCamera.enabled = !godCamera.enabled;
        MovementScript.enabled = !MovementScript.enabled;
        JumpScript.enabled = !JumpScript.enabled;
        CrouchScript.enabled = !CrouchScript.enabled;   
    }
}
