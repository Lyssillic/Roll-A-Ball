using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI RedCount;
    public TextMeshProUGUI OrangeCount;
    public TextMeshProUGUI YellowCount;
    public TextMeshProUGUI GreenCount;
    public TextMeshProUGUI BlueCount;
    public TextMeshProUGUI PurpleCount;

    public TextMeshProUGUI Achievement;
    public TextMeshProUGUI FinalAchievement;

    private Rigidbody rb;
    private int[] count = {0, 0, 0, 0, 0, 0};
    
    private float movementX;
    private float movementY;
    public Color32 red = new Color32(255, 56, 0, 255);
    public Color32 orange = new Color32(255, 176, 0, 255);
    public Color32 yellow = new Color32(255, 241, 0, 255);
    public Color32 green = new Color32(0, 255, 55, 255);
    public Color32 blue = new Color32(0, 47, 255, 255);
    public Color32 purple = new Color32(95, 0, 255, 255);

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetCountText();
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText() {
        RedCount.text = "Red #: " + count[0].ToString();
        OrangeCount.text = "Orange #: " + count[1].ToString();
        YellowCount.text = "Yellow #: " + count[2].ToString();
        GreenCount.text = "Green #: " + count[3].ToString();
        BlueCount.text = "Blue #: " + count[4].ToString();
        PurpleCount.text = "Purple #: " + count[5].ToString();

        if (count[0] == 9) {
            Achievement.text = "Achievement Scarlet Fever: Find all Red PickUps";
        }
        if (count[1] == 9) {
            Achievement.text = "Achievement Tangerine Dream: Find all Orange PickUps";
        }
        if (count[2] == 9) {
            Achievement.text = "Achievement Stay Gold: Find all Yellow PickUps";
        }
        if (count[3] == 9) {
            Achievement.text = "Achievement Emerald City: Find all Green PickUps";
        }
        if (count[4] == 9) {
            Achievement.text = "Achievement Cerulean Sea: Find all Blue PickUps";
        }
        if (count[5] == 9) {
            Achievement.text = "Achievement Purple Flurp: Find all Purple PickUps";
        }
        
        if (count[0] == 9 && count[1] == 9 && count[2] == 9 && count[3] == 9 && count[4] == 9 && count[5] == 9) {
            FinalAchievement.text = "Final Achievement: Find all colored Pickups";
            Achievement.text = "";
            RedCount.text = "";
            OrangeCount.text = "";
            YellowCount.text = "";
            GreenCount.text = "";
            BlueCount.text = "";
            PurpleCount.text = "";
        }
    }

    void Update() {
        if (Input.GetKeyDown("escape")) {
            Application.Quit();
        }
     }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);

            Color32 objColor;
            objColor = other.gameObject.GetComponent<MeshRenderer>().material.color;
            
            if (objColor.Equals(red)) 
            {
                count[0] += 1;
                gameObject.GetComponent<Renderer>().material.color = red;
            } 
            else if (objColor.Equals(orange))
            {
                count[1] += 1;
                gameObject.GetComponent<Renderer>().material.color = orange;
            }
            else if (objColor.Equals(yellow))
            {
                count[2] += 1;
                gameObject.GetComponent<Renderer>().material.color = yellow;
            }
            else if (objColor.Equals(green))
            {
                count[3] += 1;
                gameObject.GetComponent<Renderer>().material.color = green;
            }
            else if (objColor.Equals(blue))
            {
                count[4] += 1;
                gameObject.GetComponent<Renderer>().material.color = blue;
            }
            else if (objColor.Equals(purple))
            {
                count[5] += 1;
                gameObject.GetComponent<Renderer>().material.color = purple;
            }

            SetCountText();
        }
    }
}
