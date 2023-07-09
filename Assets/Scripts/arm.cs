using System.Collections;
using UnityEngine;

public class arm : MonoBehaviour
{
    public float[] torque;
    public float error = 0.001f;
    public float stepMovement;

    public Rigidbody part0;
    public Rigidbody part1;
    public Rigidbody part2;
    public Rigidbody part3;

    Quaternion t_arm0, q1_arm0, q2_arm0, q3_arm0;

    void Start()
    {
        t_arm0 = part0.transform.rotation;
        q1_arm0 = part1.transform.rotation;
        q2_arm0 = part2.transform.rotation;
        q3_arm0 = part3.transform.rotation;

        StartCoroutine(Movement());
    }

    void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            part0.AddTorque(-torque[0] * part0.mass * part0.transform.forward);
        }
        if (Input.GetKey("d"))
        {
            part0.AddTorque(torque[0] * part0.mass * part0.transform.forward);
        }

        if (Input.GetKey("w"))
        {
            part1.AddTorque(-torque[1] * part1.mass * part1.transform.forward);
        }
        if (Input.GetKey("s"))
        {
            part1.AddTorque(torque[1] * part1.mass * part1.transform.forward);
        }

        if (Input.GetKey("q"))
        {
            part2.AddTorque(-torque[2] * part2.mass * part2.transform.forward);
        }
        if (Input.GetKey("e"))
        {
            part2.AddTorque(torque[2] * part2.mass * part2.transform.forward);
        }

        if (Input.GetKey("z"))
        {
            part3.AddTorque(-torque[3] * part3.mass * part3.transform.right);
        }
        if (Input.GetKey("c"))
        {
            part3.AddTorque(torque[3] * part3.mass * part3.transform.right);
        }
    }

    IEnumerator Movement()
    {
        while (true)
        {
            yield return MoveArm(t_arm0, q1_arm0, q2_arm0, q3_arm0);

            yield return new WaitForSeconds(1);

            yield return MoveArm(Quaternion.Euler(45, 0, 0), Quaternion.Euler(45, 0, 0), Quaternion.Euler(45, 0, 0), Quaternion.Euler(45, 0, 0));

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator MoveArm(Quaternion t, Quaternion q1, Quaternion q2, Quaternion q3)
    {
        while (Mathf.Abs(Quaternion.Dot(part0.transform.rotation, t)) < 1 - error ||
               Mathf.Abs(Quaternion.Dot(part1.transform.rotation, q1)) < 1 - error ||
               Mathf.Abs(Quaternion.Dot(part2.transform.rotation, q2)) < 1 - error ||
               Mathf.Abs(Quaternion.Dot(part3.transform.rotation, q3)) < 1 - error)
        {
            part0.MoveRotation(Quaternion.RotateTowards(part0.transform.rotation, t, stepMovement));
            part1.MoveRotation(Quaternion.RotateTowards(part1.transform.rotation, q1, stepMovement));
            part2.MoveRotation(Quaternion.RotateTowards(part2.transform.rotation, q2, stepMovement));
            part3.MoveRotation(Quaternion.RotateTowards(part3.transform.rotation, q3, stepMovement));

            yield return null;
        }
    }
}
