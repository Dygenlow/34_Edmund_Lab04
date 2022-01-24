using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private int coins;
    public float speed;
    Rigidbody PlayerRigidbody;
    public Text coinsCollected;
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);

        if(coins >= 4)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Hazard"))
        {
            SceneManager.LoadScene("GameLose");
        }

        if(collision.gameObject.tag.Equals("Coin"))
        {
            coins++;
            coinsCollected.GetComponent<Text>().text = "Coins Collected: " + coins;
            Destroy(collision.gameObject);
        }
    }
}
