using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class QueueManager : MonoBehaviour
{
    private List<QueuePoint> points = new List<QueuePoint>();


    private void Awake()
    {
        if (DI.di.queueManager != null)
        {
            Destroy(gameObject);
            return;
        }
        DI.di.SetQueueManager(this);
        for (int i = 0; i < transform.childCount; i++)
        {
            var point = transform.GetChild(i).GetComponent<QueuePoint>();
            if (point != null) points.Add(point);
        }

        Debug.Log($"QueueManager {points.Count} points");
        Assert.IsTrue(points.Count > 0, "Please Add Queue Points");
    }

    public Transform GetNextPoint()
    {
        if (points.Count == 0) return null;
        for (int i = 0; i < points.Count; i++)
        {
            if (!points[i].isOccupied)
            {
                points[i].isOccupied = true;
                return points[i].transform;
            }
        }
        return null;
    }

    public bool IsQueueEmpty()
    {
        foreach (var point in points)
        {
            if (point.isOccupied) return false;
        }
        return true;
    }
}
