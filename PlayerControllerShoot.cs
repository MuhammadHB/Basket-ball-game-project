using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerShoot : MonoBehaviour
{
    public float force = 100f;

    private Vector2 defualtBallPostition;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private Rigidbody2D rb;

         void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

        rb.isKinematic = true;
        defualtBallPostition= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = GetMousePosition();


        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosition = GetMousePosition();
            Vector2 power = startPosition- endPosition;
            rb.isKinematic = false;
            rb.AddForce(power * force, ForceMode2D.Force);


        }
    }

    private Vector2 GetMousePosition()

    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }



}
