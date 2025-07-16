using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public Transform centerObject;
    public float speed = 1.0f;
    public float radiusX = 5.0f;
    public float radiusZ = 3.0f;
    public Vector3 inclination = new Vector3(30, 0, 0);
    public int segments = 100;

    private float angle;

    void Update()
    {
        angle += speed * Time.deltaTime;
        float x = Mathf.Cos(angle) * radiusX;
        float z = Mathf.Sin(angle) * radiusZ;

        Vector3 orbitPos = new Vector3(x, 0, z);
        Quaternion tilt = Quaternion.Euler(inclination);
        orbitPos = tilt * orbitPos;

        transform.position = centerObject.position + orbitPos;
    }


    void OnDrawGizmos()
    {
        if (centerObject == null)
            return;

        Gizmos.color = Color.cyan;

        Vector3 prevPoint = Vector3.zero;
        for (int i = 0; i <= segments; i++)
        {
            float t = (float)i / segments * Mathf.PI * 2;
            float x = Mathf.Cos(t) * radiusX;
            float z = Mathf.Sin(t) * radiusZ;
            Vector3 point = new Vector3(x, 0, z);

            Quaternion tilt = Quaternion.Euler(inclination);
            point = tilt * point;
            point += centerObject.position;

            if (i > 0)
                Gizmos.DrawLine(prevPoint, point);

            prevPoint = point;
        }
    }
}
