using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public static class Extension
{
    public static T RandomItemInList<T>(this List<T> listItem)
    {
        return listItem[Random.Range(0, listItem.Count)];
    }
}