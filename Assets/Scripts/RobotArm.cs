using System.Collections;
using UnityEngine;

public class RobotArm : MonoBehaviour
{
    public Transform targetPosition; // 目标位置
    public float movementSpeed = 1f; // 移动速度

    private Rigidbody[] rbs;

    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        StartCoroutine(AutoMoveArm());
    }

    IEnumerator AutoMoveArm()
    {
        while (true)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetPosition.position - transform.position);
            float elapsedTime = 0f;

            while (elapsedTime < 1f)
            {
                elapsedTime += Time.deltaTime * movementSpeed;
                // 使用插值平滑地旋转每个部分
                for (int i = 0; i < rbs.Length; i++)
                {
                    Quaternion currentRotation = rbs[i].rotation;
                    Quaternion newRotation = Quaternion.Lerp(currentRotation, targetRotation, elapsedTime);
                    rbs[i].MoveRotation(newRotation);
                }

                yield return null;
            }

            yield return new WaitForSeconds(1f); // 等待一秒

            // 返回初始位置
            Quaternion initialRotation = Quaternion.identity;
            elapsedTime = 0f;

            while (elapsedTime < 1f)
            {
                elapsedTime += Time.deltaTime * movementSpeed;
                // 使用插值平滑地旋转每个部分
                for (int i = 0; i < rbs.Length; i++)
                {
                    Quaternion currentRotation = rbs[i].rotation;
                    Quaternion newRotation = Quaternion.Lerp(currentRotation, initialRotation, elapsedTime);
                    rbs[i].MoveRotation(newRotation);
                }

                yield return null;
            }

            yield return new WaitForSeconds(1f); // 等待一秒
        }
    }
}
