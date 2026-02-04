using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float speed = 10;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public GameObject winObject;
    public GameObject loseObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winObject.gameObject.SetActive(false);
        loseObject.gameObject.SetActive(false);
    }

    
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    void SetCountText()
    {
        textMeshPro.text = "Count: " + count.ToString();
        if (count >= 7)
        {
            //winObject.gameObject.SetActive(true);
            SceneManager.LoadScene("Winscene");
        }
    }

     void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f , movementY);
        rb.AddForce(speed * movement);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            count ++;
            SetCountText();
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && count < 7)
        {
            SceneManager.LoadScene("Losescene");
        }
    }
}
