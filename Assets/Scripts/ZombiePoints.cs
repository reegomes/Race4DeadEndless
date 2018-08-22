using UnityEngine;

public class ZombiePoints : MonoBehaviour
{
    public void Update()
    {
        RaycastHit zombiehit;
        if (Physics.Raycast(transform.position, transform.up * -1, out zombiehit, 50f))
        {
            Debug.Log("Zumbi colidindo com o chão.");
            Debug.DrawLine(transform.position, zombiehit.point, Color.red);
        }
        else
        {
            Invoke("AddPoints", 5f);
        }
    }
    public void AddPoints(){
        ShopStats.points++;
        Debug.Log(ShopStats.points);
        Destroy(this.gameObject);
        // Adicionar ao transform do savepoint dos zumbis, entre os prédios;
        //this.transform.position = new Vector3(0f,0f,0f);
    }
}