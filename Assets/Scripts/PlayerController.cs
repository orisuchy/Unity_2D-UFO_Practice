using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    public Text countText;
    public Text dizzyTimer;
    public Text speedBoostTimer;
    public Text winText;
    public float speed;
    private Rigidbody2D rb2d;
    private int count;
    private float timeBoost=10;
    private bool activeBoost=false;
    private float timeDizzy=10;
    private bool activeDizzy=false;
    
    void Start(){
        rb2d=GetComponent<Rigidbody2D>();
        count=0;
        winText.text="";
        dizzyTimer.text = "";
        speedBoostTimer.text = "";
        SetCountText();
    }
    void FixedUpdate(){
        
        float moveHorizontal=Input.GetAxis("Horizontal");
        float moveVertical=Input.GetAxis("Vertical");
        Vector2 movement=new Vector2(moveHorizontal,moveVertical);
        if(activeBoost){
            if(timeBoost>0){
                timeBoost-= Time.deltaTime;
                speedBoostTimer.text = "End of speed boost: " + System.Math.Round(timeBoost).ToString();
            }
            else{
                speed=10;
                activeBoost=false;
                timeBoost=10;
                speedBoostTimer.text = "";
            }
            
        }
        if(activeDizzy){
            if(timeDizzy>0){
                timeDizzy-= Time.deltaTime;
                dizzyTimer.text = "End of dizzy: " + System.Math.Round(timeDizzy).ToString();
            }
            else{
                speed = speed / 7;
                activeDizzy=false;
                timeDizzy=10;
                dizzyTimer.text = "";
            }
            
        }
        rb2d.AddForce(movement*speed);
        if(Input.GetKey("escape")){
            Application.Quit();
        }

    }
    
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
        else if(other.gameObject.CompareTag("SpeedBoost")){
            other.gameObject.SetActive(false);
            speed=speed*7;
            activeBoost=true;
            
        }
        else if(other.gameObject.CompareTag("Saw")){            
            count=count-2;
            SetCountText();
            if(!activeDizzy){
                speed=-speed;
                activeDizzy=true;
            }
            
        }

    }
    void SetCountText(){
        countText.text="Count: "+count.ToString();
        if(count>=11){
            winText.text="You win!!";
        }
    }    
}
