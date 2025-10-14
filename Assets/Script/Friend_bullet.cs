using UnityEngine;

public class Friend_bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Destroy(this.gameObject, 5f);
    }

    // use transform to make it go forward 
    private void Update()
    {
        this.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log("it Enemy");
            enemy.getHit(5);

            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);


    }
}
