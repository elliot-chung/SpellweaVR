using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcastingScript : MonoBehaviour
{
    private List<int> order;
    private LineRenderer lineRenderer;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        order = new List<int>();
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = material;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.positionCount = order.Count;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = order.Count;
    }

    public void PointTouched(int pointNum, Vector3 positionOfPoint)
    {
        if (!order.Contains(pointNum))
        {
            order.Add(pointNum);
            lineRenderer.positionCount = order.Count;
            lineRenderer.SetPosition(order.Count - 1, positionOfPoint);
        }
    }

    public List<int> ReleaseSpell()
    {
        return order;
    }
}
