using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject shot;
    public ParticleSystem playerEffect;
    public Animator playerAnimator;
    public Animator objAnim;
    [SerializeField] private GameObject _lift;
    [SerializeField] private GameObject shotPoint;
    private Vector3 vec;
    private Vector3 vec1;
    private Vector3 vec2;
    private Vector3 offset;
    private bool jump = true;
    private bool onLift;
    private bool isDead = true;
    private bool pd;
    private bool canShoot = true;
    private Rigidbody playerBody;
    [SerializeField] private Rigidbody liftBody;
    private bool lift;
    [SerializeField, Range(0, 10)] private float speed;
    [SerializeField, Range(0, 10)] private float jumpSpeed;
    [SerializeField] private GameObject deathWindow;
    [SerializeField] private GameObject finishWindow;
    [SerializeField] private GameObject playerWindow;
    [SerializeField] private Vector3[] points;
    private Text playerWindowText;
    [SerializeField] private GameObject door;
    private Rigidbody doorBody;
    private HingeJoint doorJoint;
    public Image playerHP;
    private float playerHPmax = 1;
    [SerializeField, Range(0, 50)] private float playerTimeDelay;
    private float playerRealTime;
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerWindowText = playerWindow.GetComponent<Text>();

        if (SceneManager.GetActiveScene().buildIndex == 5) { playerRealTime = playerTimeDelay; offset = shotPoint.transform.position - transform.position; playerHP.fillAmount = playerHPmax; }
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            doorBody = door.GetComponent<Rigidbody>();
            doorJoint = door.GetComponent<HingeJoint>();
        }
    }

    void Update()
    {
        if (pd) { if (playerEffect.isStopped) Time.timeScale = 0; else { Time.timeScale = 1; } }
        

        vec1 = new Vector3(0, 1, 0);
        vec2 = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        PlayerJump();
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            shotPoint.transform.position = transform.position + offset;
            BattleMod();
        }
    }
    private void FixedUpdate()
    {
        PlayerMove();
        if (lift) { LiftMove(); }
        if (!canShoot)
        {
            if (playerRealTime <= 0) { playerRealTime = playerTimeDelay; canShoot = true; }
            else { playerRealTime = playerRealTime - 1f; }
        }

    }
    public void PlayerMove()
    {

        playerBody.AddRelativeForce(vec2 * speed);
        if (Input.GetKey(KeyCode.Keypad3)) { transform.Rotate(Vector3.up, 100 * Time.deltaTime); }
        if (Input.GetKey(KeyCode.Keypad1)) { transform.Rotate(Vector3.down, 100 * Time.deltaTime); }

    }
    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && jump)
        {

            playerBody.AddForce(vec1 * jumpSpeed, ForceMode.Impulse);
            playerAnimator.SetInteger("ps", 1);
            jump = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("plane")) { jump = true; }
        if (collision.gameObject.CompareTag("enemy")) { Death(); }
        if (collision.gameObject.CompareTag("Finish")) { finishWindow.SetActive(true); Time.timeScale = 0; }
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (collision.gameObject.layer == 8) { playerHP.fillAmount = playerHP.fillAmount - 0.1f; }

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("button")) { playerWindowText.text = "Нажмите [E]"; playerWindow.SetActive(true); }
        if (other.CompareTag("lift")) { if (!lift) { playerWindowText.text = "Лифту не хватает питания, рядом должна быть кнопка"; playerWindow.SetActive(true); } }
        if (other.CompareTag("liftZone")) { onLift = true; }

        if (Input.GetKey(KeyCode.E) && other.CompareTag("button"))
        {
            objAnim.SetInteger("buttonState", 1);
            if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 2) { doorBody.isKinematic = false; doorJoint.useMotor = true; }
            if (SceneManager.GetActiveScene().buildIndex == 4) { lift = true; }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("button")) { playerWindow.SetActive(false); }
        if (other.CompareTag("lift")) { playerWindow.SetActive(false); }
        if (other.CompareTag("liftZone")) { onLift = false; }
        if (other.CompareTag("ShotZone")) { Death(); }
    }
    private void LiftMove()
    {
        if (_lift.transform.position.y <= points[1].y) { vec = Vector3.up; }
        if (_lift.transform.position.y >= points[0].y) { vec = Vector3.down; }
        if (onLift) { liftBody.AddForce(vec * 10, ForceMode.Acceleration); }
        else { liftBody.AddForce(vec * 5, ForceMode.Acceleration); }
    }
    private void BattleMod()
    {
        if (Input.GetKeyUp(KeyCode.Keypad5) && canShoot)
        {
            Instantiate(shot, shotPoint.transform.position, Quaternion.LookRotation(-transform.up, -transform.forward)); canShoot = false;
        }
        if (playerHP.fillAmount == 0)
        {
            if (isDead) { Death();  isDead = false; }
            

        }

    }
    private void Death()
    {
        //Time.timeScale = 0;
        pd = true;
        Destroy(gameObject.transform.GetChild(0).gameObject);
        playerEffect.Play();
        deathWindow.SetActive(true);
    }

}
