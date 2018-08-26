using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Archievements : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("ArchUpdate");
    }
    IEnumerator ArchUpdate()
    {
        yield return new WaitForSeconds(0.05f);
        StartCoroutine("ArchFake");
    }
    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2f);
        StopCoroutine("");
        StopCoroutine("");
        StopCoroutine("");
        StopCoroutine("");
        StopCoroutine("");
        StopCoroutine("");
        StopCoroutine("");
    }
    IEnumerator Paradise()
    {
        return null;
    }
    IEnumerator INeverStop()
    {
        return null;
    }
    IEnumerator MyCarComesFirst()
    {
        return null;
    }
    IEnumerator WeFallButDontStop()
    {
        return null;
    }
    IEnumerator FastIsBetter()
    {
        return null;
    }
    IEnumerator FastThenVS()
    {
        return null;
    }
    IEnumerator MyDude()
    {
        return null;
    }
}