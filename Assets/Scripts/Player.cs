using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;




public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Animator animator;
    InGameMenu openMainMenu;
    float speed = 5f;
    float jumpSpeed = 250.0f;
    float dX;
    float dY;
    bool faceRight;

    bool jumping = false;

    private Vector3 localScale;

    [SerializeField]
    AudioSource dyingSound;
    [SerializeField]
    AudioSource jumpingSound;
    [SerializeField]
    Canvas success;

    [SerializeField]
    Canvas failure;
    [SerializeField]
    Button successRetry;
    [SerializeField]
    Button failureRetry;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        localScale = transform.localScale;
        success.enabled = false;
        failure.enabled = false;

        failureRetry.onClick.AddListener(delegate { failRetry(); });
        successRetry.onClick.AddListener(delegate { successRe(); });



    }

    void Update()
    {
        dX = Input.GetAxis("Horizontal") * speed; 
        dY = Input.GetAxis("Vertical") * speed;

        if(Input.GetButtonDown("Jump")){
            rigidbody.AddForce(Vector2.up*jumpSpeed);
            if(jumpingSound/* .clip.length > 0 */){
                jumpingSound.Play();    
            }

        }

        if(Mathf.Abs(rigidbody.velocity.y) != 0){
            animator.SetBool("isWalking", false);
            animator.SetBool("isFlying", true);
            animator.SetBool("isIdle", true);
        }

        if (rigidbody.velocity.y == 0){
            animator.SetBool("isFlying", false);

            if (Mathf.Abs(dX) > 0){
                animator.SetBool("isWalking", true);

            }else if (dX == 0){
                animator.SetBool("isIdle", true);

            }
        }

        if (Mathf.Abs(dX) > 0){
            animator.SetBool("isWalking", true);

        }else if (dX == 0){
            animator.SetBool("isWalking", false);
        }

        if(!dyingSound){
             failure.enabled = true;
        }else{
            failure.enabled = false;
        }

    }

    void FixedUpdate() {

        if(jumping){
            rigidbody.velocity = new Vector2(dX, dY);
        }else{
            rigidbody.velocity = new Vector2(dX, rigidbody.velocity.y); 
        }
    }

    void LateUpdate(){
        if(dX > 0) {
            faceRight = true;

        }else if (dX < 0){
            faceRight = false;
        }

        if( (faceRight) && (localScale.x < 0) || (!faceRight) && (localScale.x > 0) ){
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "spike"){
            animator.SetBool("isDead", true);
            dyingSound.Play();
            Destroy(jumpingSound);
            Destroy(dyingSound, dyingSound.clip.length);
            speed = 0;
            jumpSpeed = 0;
        }

        if(other.gameObject.tag == "success"){
            Debug.Log("buradayım");
            Destroy(jumpingSound);
            speed = 0;
            jumpSpeed = 0;
            success.enabled = true;
        }
    }

    void failRetry(){
        SceneManager.LoadScene(1);
    }

    void successRe(){
        SceneManager.LoadScene(1);
    }
}
