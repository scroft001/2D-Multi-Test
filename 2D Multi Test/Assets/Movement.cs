using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    private float speed = 10f;
    public Animator anim;
    public Text scoreText;
    private float score = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        transform.position += input.normalized * speed * Time.deltaTime;
        if(input == Vector3.zero)
        {
            anim.SetBool("isWalking", false); 
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit " + collision.collider.name);
        if (collision.collider.CompareTag("Collectible"))
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
