using System.Collections;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ArcCircleScript : MonoBehaviour
{
    public int segments;
    public float radius;
    public float lineWidth = 0.2f;
    public float arc;
    LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }


    void CreatePoints()
    {
        line.widthMultiplier = lineWidth;
        line.material.color = Color.white;

        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (arc / segments);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        float x;
        float y;
        float z = 0f;

        Vector3 oldPos = Vector3.zero;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            Vector3 newPos = new Vector3(x, y, z);
            Gizmos.DrawLine(oldPos, transform.position + newPos);
            oldPos = transform.position + newPos;

            angle += (arc / segments);
        }
    }
#endif
}
