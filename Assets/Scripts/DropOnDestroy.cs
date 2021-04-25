using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    public GameObject prefab;

    public void Drop(Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }
}
