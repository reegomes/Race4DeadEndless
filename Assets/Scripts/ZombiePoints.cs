using UnityEngine;

public class ZombiePoints : MonoBehaviour
{
    public void Update()
    {
        RaycastHit zombiehit;
        
        if (Physics.Raycast(this.transform.position, transform.up * -1, out zombiehit, 10f))
        {
            Invoke("AddPoints", 5f);
            Debug.DrawLine(transform.position, zombiehit.point, Color.blue);
        }
        else
        {
            Debug.Log("Zumbi colidindo com o chão.");
            Debug.DrawLine(transform.position, zombiehit.point, Color.red);
        }
    }
    public void AddPoints(){
        ShopStats.points++;
        Debug.Log("Pontos: " + ShopStats.points);
        Destroy(this.gameObject);
        // Adicionar ao transform do savepoint dos zumbis, entre os prédios;
        //this.transform.position = new Vector3(0f,0f,0f);
    }
}