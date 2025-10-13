using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Weapon weapon_data;
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
            enemy.health -= weapon_data.Danmage;
            Debug.Log("it Enemy");
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);


    }
}
