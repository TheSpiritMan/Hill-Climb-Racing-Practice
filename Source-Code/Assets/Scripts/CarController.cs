using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{


    // [HideInInspector]
    public float fuel = 1;
    public float fuelconsumption = 0.1f;
    public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float speed = 20;
    public float carTorque = 10;
    public float tireTorque = 0;
    public float movement;
    public UnityEngine.UI.Image gasCanImage;

   

    // Use this for initialization
    void Start()
    {
        //not used
    }

    // Update is called once per frame
    void Update()
    {

        //Modifiy gas can fill amount
        movement = Input.GetAxis("Horizontal");

        gasCanImage.fillAmount = fuel;
    }

    private void FixedUpdate()
    {

        //Calc tire torque
        tireTorque = -movement * speed * Time.fixedDeltaTime;

        //Add torque to wheels
        if (fuel > 0)
        {
            backTire.AddTorque(tireTorque);
            frontTire.AddTorque(tireTorque);
        }
        fuel -= fuelconsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
    }
}

