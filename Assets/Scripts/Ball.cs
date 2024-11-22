using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    float speed = 10f;

    void Start()
    {
        Vector2 Shoot = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        Shoot.Normalize();
        rb.AddForce(Shoot * speed, ForceMode2D.Impulse);

        Destroy(gameObject, 20f);
    }
}
