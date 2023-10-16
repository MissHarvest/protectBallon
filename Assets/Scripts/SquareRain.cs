using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-2.0f, 2.0f);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);

        float size = Random.Range(1.0f, 1.5f);
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ballon"))
        {
            GameManager.Instance.Gameover();
        }
    }
}
