using System;
using UnityEngine;

public class Road : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var barrier = Instantiate(GameCtl.Instance.listBarrier.RandomItemInList()).transform;
        barrier.parent = transform;
        var localPos = barrier.localPosition;
        barrier.localPosition = new Vector3(0, localPos.y, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}