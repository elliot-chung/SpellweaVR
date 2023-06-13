using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellcastingScript : MonoBehaviour
{
    public AudioClip Tone1;
    public AudioClip Tone2;
    public AudioClip Tone3;
    public AudioClip Tone4;
    public AudioClip Tone5;

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

            AudioClip clip = Tone1;
            if (pointNum == 1) clip = Tone1;
            if (pointNum == 2) clip = Tone2;
            if (pointNum == 3) clip = Tone3;
            if (pointNum == 4) clip = Tone4;
            if (pointNum == 5) clip = Tone5;
            AudioSource.PlayClipAtPoint(clip, positionOfPoint);

        }
    }

    public List<int> ReleaseSpell()
    {
        return order;
    }
}
