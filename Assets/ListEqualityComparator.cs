using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ListEqualityComparator : IEqualityComparer<List<int>>
{
    public bool Equals(List<int> x, List<int> y)
    {
        int xLen = x.Count;
        int yLen = y.Count;
        if (xLen != yLen) return false;
        for(int i = 0; i < xLen; i++)
        {
            if (x[i] != y[i])
            {
                return false;
            }
        }
        return true;
    }

    public int GetHashCode(List<int> obj)
    {
        int hashcode = 0;
        foreach (int t in obj)
        {
            hashcode ^= t.GetHashCode();
        }
        return hashcode;
    }
}
