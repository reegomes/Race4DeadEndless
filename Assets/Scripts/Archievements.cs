using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Archievements : MonoBehaviour
{
    float timerArch;
    int intTimerArch;
    public static bool crash;
    public static bool collBeforeTheEnd;
    public static bool NitroIsEnable;
    public static bool VSFasterAsFuck;
    public GameObject[] archievs;
    float timerToDisplay = 1.8f;
    private void Update()
    {
        timerArch += Time.deltaTime;
        intTimerArch = (int)timerArch;
        timerToDisplay -= Time.deltaTime;
        if (timerToDisplay <= 0){
        archievs[0].SetActive(false);
        archievs[1].SetActive(false);
        archievs[2].SetActive(false);
        archievs[3].SetActive(false);
        archievs[4].SetActive(false);
        archievs[5].SetActive(false);
        archievs[6].SetActive(false); 
        }
    }
    void Awake()
    {
        StartCoroutine("ArchUpdate");
    }
    IEnumerator ArchUpdate()
    {
        yield return new WaitForSeconds(0.05f);
        StartCoroutine("ArchUpdate");
        if (ShopStats.velocity >= 10)
        {
            StartCoroutine("Paradise");
        }
        if (intTimerArch >= 300)
        {
            StartCoroutine("CantStopWontStop");
        }
        if (crash == true)
        {
            StartCoroutine("MyCarComesFirst");
        }
        if (collBeforeTheEnd == true)
        {
            StartCoroutine("ItsAllPartOfThePlan");
        }
        if (NitroIsEnable == true)
        {
            StartCoroutine("GottaGoFast");
        }
        if (VSFasterAsFuck == true)
        {
            StartCoroutine("FasterThenVS");
        }
        if (intTimerArch > 300 && crash == true && collBeforeTheEnd == true && NitroIsEnable == true && VSFasterAsFuck == true)
        {
            StartCoroutine("MyDude");
        }
    }
    IEnumerator Stop()
    {
        //yield return new WaitForSeconds(1f);
        StopCoroutine("Paradise");
        StopCoroutine("CantStopWontStop");
        StopCoroutine("MyCarComesFirst");
        StopCoroutine("ItsAllPartOfThePlan");
        StopCoroutine("GottaGoFast");
        StopCoroutine("FasterThenVS");
        StopCoroutine("MyDude");
        return null;   
    }
    IEnumerator Paradise()
    {
        StartCoroutine("Stop");
        //archievs[0].SetActive(true);
        return null;
    }
    IEnumerator CantStopWontStop()
    {
        StartCoroutine("Stop");
        //archievs[1].SetActive(true);
        collBeforeTheEnd = false;
        return null;
    }
    IEnumerator MyCarComesFirst()
    {
        StartCoroutine("Stop");
        //archievs[2].SetActive(true);
        return null;
        //yield return new WaitForSeconds (1.5f);
    }
    IEnumerator ItsAllPartOfThePlan()
    {
        StartCoroutine("Stop");
        //archievs[3].SetActive(true);
        return null;
    }
    IEnumerator GottaGoFast()
    {
        StartCoroutine("Stop");
        //archievs[4].SetActive(true);
        return null;
    }
    IEnumerator FasterThenVS()
    {
        StartCoroutine("Stop");
        //archievs[5].SetActive(true);
        return null;
    }
    IEnumerator MyDude()
    {
        StartCoroutine("Stop");
        //archievs[6].SetActive(true);
        return null;
    }
}