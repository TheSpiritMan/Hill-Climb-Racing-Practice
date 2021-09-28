using UnityEngine;

public class CarController: MonoBehaviour
{

    public float fuel = 1;
    public float fuelConsumption = 0.1f;
    public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float speed = 20;
    public float carTorque = 10;

    public float tireTorque = 0;

    public float movement;
    public UnityEngine.UI.Image gasCanImage;

    public float thrust = 0f;
    public GameObject thrustingEffect;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            thrust += 10f;
            movement = 1;
        }
        else
        {
            movement = 0;
        }

        //Modifiy gas can fill amount
        gasCanImage.fillAmount = fuel;
    }

    private void FixedUpdate() {
        tireTorque = -movement * speed * Time.fixedDeltaTime;
        backTire.AddTorque(tireTorque);
        frontTire.AddTorque(tireTorque);

        thrust -= 10.0f;

        if (thrust <= 0)
            thrust = 0;

        if (thrust > 0)
        {
            
            thrustingEffect.SetActive(true);

            carRigidbody.AddRelativeForce(Vector2.right * thrust);

        }
        else
        {
          
            thrustingEffect.SetActive(false);
        }

        fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
    }


}  