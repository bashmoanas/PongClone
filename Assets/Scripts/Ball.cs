using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{

    public float speed = 30;

    public TextMeshProUGUI scoreRightText;
    public TextMeshProUGUI scoreLeftText;
    int scoreRight;
    int scoreLeft;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketLeft")
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (collision.gameObject.name == "RacketRight")
        {
            float y = HitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (collision.gameObject.name == "WallRight")
        {
            scoreLeft ++;
            scoreLeftText.text = scoreLeft.ToString();
        }

        if (collision.gameObject.name == "WallLeft")
        {
            scoreRight ++;
            scoreRightText.text = scoreRight.ToString();
        }
    }
}
