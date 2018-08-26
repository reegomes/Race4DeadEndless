using UnityEngine;

public class RayCastPlayer : MonoBehaviour
{

    float timerArch;
    int intTimerArch;
    int archColl;
    void Update()
    {
        timerArch += Time.deltaTime;
        intTimerArch = (int)timerArch;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up * -1, out hit, 40f))
        {
            //Debug.Log("Colidiu");
            Debug.DrawLine(transform.position, hit.point, Color.green);
            if (intTimerArch >= 60)
            {
                Archievements.crash = true;
            }
        }
        else
        {
            //Debug.Log("Não Colidiu");
            Debug.DrawLine(transform.position, hit.point, Color.yellow);
            archColl = ShopStats.points; 
            Invoke("EndGame", 3f);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            ShopStats.points++;
            //Debug.Log(ShopStats.points);
        }
    }
    void EndGame()
    {
        Time.timeScale = 0f;
        if (archColl > ShopStats.points){
            Archievements.collBeforeTheEnd = true;
        }
        
        Debug.Log("Perdeu");
    }
}
