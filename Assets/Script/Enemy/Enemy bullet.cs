using UnityEngine;

public class Enemybullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    // use transform to make it go forward 
    private void Update()
    {
        this.transform.Translate(Vector3.up * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            PlayerC player = collision.gameObject.GetComponent<PlayerC>();

            player.getHit(5);
            
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);


    }
}
