using System.Collections;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f; // 物体的移动速度

    [SerializeField]
    private Transform[] waypoints; // 路点数组

    private int currentWaypointIndex = 0; // 当前路点的索引
    private bool isRotating = false; // 是否正在旋转

    void Update()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogWarning("路点列表为空，请添加至少一个路点。");
            return;
        }

        // 如果正在旋转，不执行移动逻辑
        if (isRotating)
        {
            return;
        }

        // 继续直行
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // 检测到路点的碰撞
        if (waypoints[currentWaypointIndex] == other.transform)
        {
            //Debug.Log("碰撞了！！！");
            // 停止前进，开始旋转
            isRotating = true;
            StartCoroutine(RotateToNextWaypoint());
        }
    }

    IEnumerator RotateToNextWaypoint()
    {
        // 下一个路点的方向向量
        Vector3 directionToNextWaypoint = waypoints[(currentWaypointIndex + 1) % waypoints.Length].position - transform.position;
        directionToNextWaypoint.y = 0f;

        // 当前物体的右侧向量
        Vector3 rightDirection = transform.right;

        // 判断下一个waypoint相对位置
        float dot = Vector3.Dot(rightDirection, directionToNextWaypoint);
        Quaternion targetRotation;

        if (dot > 0f)
        {
            // 在物体的右侧，旋转角度+90度
            targetRotation = Quaternion.Euler(0f, 90f, 0f) * transform.rotation;
        }
        else
        {
            // 在物体的左侧，旋转角度-90度
            targetRotation = Quaternion.Euler(0f, -90f, 0f) * transform.rotation;
        }


        // 旋转过程
        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 90f * Time.deltaTime);
            yield return null;
        }

        // 旋转完成，更新索引和状态
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        isRotating = false;

        // 判断是否到达最后一个路点
        if (currentWaypointIndex == waypoints.Length - 1)
        {
            // 销毁物品
            Destroy(gameObject);
        }
    }
}
