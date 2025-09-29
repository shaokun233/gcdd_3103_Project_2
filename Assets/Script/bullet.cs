using UnityEngine;

public class bullet : MonoBehaviour
{
    //when this object awake, use rigibody to make it go forward, and after 5 sec, destory it.
    void Awake()
    {
        this.transform.GetComponent<Rigidbody>().linearVelocity = transform.forward * 10;
        Destroy(this.gameObject, 5f);
    }


    //if it hit the enemy, reduce enemy health, and destroy it self, if it not enemy, just destory it self
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.health -= 10;
            Debug.Log("it Enemy");
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);

    }

}
