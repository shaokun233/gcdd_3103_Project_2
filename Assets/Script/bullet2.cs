using UnityEngine;

public class bullet2 : MonoBehaviour
{
    // after 5 sec, destory it.
    void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    // use transform to make it go forward 
    private void Update()
    {
        this.transform.Translate(Vector3.forward *10 * Time.deltaTime);
    }

    //if it hit the enemy, reduce enemy health, and destroy it self, if it not enemy, just destory it self
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
           Enemy enemy =  collision.gameObject.GetComponent<Enemy>();
            enemy.health -= 20;
            Debug.Log("it Enemy");
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);


    }
}
