using UnityEngine;
using System.Collections;

public class EagleControl : MonoBehaviour {

    public Animator baldEagleAnimator;
    public Rigidbody baldEagleRigid;
    public AudioClip CollisionSound;
    //public AudioClip BackgroundSound;
    //private AudioSource backgroundAudio;
    private AudioSource collisionAudio;

    float forwardAcceleration = 0f;
    float yawVelocity = 0f;
    float upDown = 0f;
    float forwardSpeed = 25f;

    enum AnimState { Ground, Fly };
    AnimState animState;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            //Attack();
            Destroy(other.gameObject);
            collisionAudio.PlayOneShot(CollisionSound, 2.0F);
            TextUpdater.Score += 10;
        }
    }

    // Use this for initialization
    void Start () {

        animState = AnimState.Ground;

        baldEagleAnimator = GetComponent<Animator>();
        baldEagleRigid = GetComponent<Rigidbody>();

        collisionAudio = gameObject.AddComponent<AudioSource>();
        //backgroundAudio = gameObject.AddComponent<AudioSource>();
        //backgroundAudio.PlayOneShot(BackgroundSound, 0.1F);

        baldEagleAnimator.SetBool("Landing", false);
        baldEagleAnimator.SetBool("IsSoaring", false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick 1 button 1"))
        {
            Debug.Log("Soar");
            animState = AnimState.Fly;
            Soar();
        }


        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        if (animState == AnimState.Ground)
        {
            forwardAcceleration = v;
            yawVelocity = h;

            baldEagleAnimator.SetFloat("Forward", forwardAcceleration);
            baldEagleAnimator.SetFloat("Turn", yawVelocity);
        }
        else
        {
            //forwardAcceleration = 3f;
            upDown = v;
            //baldEagleAnimator.SetFloat("Forward", forwardAcceleration);
            //baldEagleAnimator.SetFloat("UpDown", upDown);
            //baldEagleAnimator.SetFloat("UpVelocity", baldEagleRigid.velocity.y);

            yawVelocity = h;
            baldEagleAnimator.SetFloat("Turn", yawVelocity);



            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * yawVelocity * 100f);

            transform.position += transform.forward * Time.deltaTime * forwardSpeed;

            float yPos = Mathf.Min(gameObject.transform.position.y + upDown, 80f);

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, yPos, gameObject.transform.position.z);



            

            //forwardSpeed = Mathf.Lerp(forwardSpeed, 0f, Time.deltaTime * 0.1f);
            //upDown = Mathf.Lerp(upDown, 0, Time.deltaTime * 3f);

        }
        //baldEagleAnimator.SetFloat("UpVelocity", baldEagleRigid.velocity.y);


        if (animState == AnimState.Fly)
        {

            if (forwardAcceleration < 0f)
            {
                //baldEagleRigid.velocity = transform.up * upDown + transform.forward * forwardSpeed;
            }
            else {
                //baldEagleRigid.velocity = transform.up * (upDown + (forwardSpeed - meanForwardSpeed)) + transform.forward * forwardSpeed;
            }

            //
            //forwardSpeed = Mathf.Lerp(forwardSpeed, 0f, Time.deltaTime * speedDumpingTime);
            //forwardSpeed = Mathf.Clamp(forwardSpeed + forwardAcceleration * Time.deltaTime, 0f, maxForwardSpeed);
            //upDown = Mathf.Lerp(upDown, 0, Time.deltaTime * 3f);
        }


        if (gameObject.transform.position.y <= 0.01f)
        {
            Debug.Log("Close to Land    ");
            if (baldEagleAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Flap")
            {
                Debug.Log(gameObject.transform.position.y);
                if (animState != AnimState.Ground)
                {
                    Debug.Log("Land");
                    animState = AnimState.Ground;
                    Land();
                }
            }
            
        }
        else
        {
            animState = AnimState.Fly;
        }
    }

    void Soar()
    {
        animState = AnimState.Fly;
        baldEagleAnimator.SetBool("Landing", false);
        baldEagleAnimator.SetBool("IsSoaring", true);
    }

    void Land()
    {
        animState = AnimState.Ground;
        baldEagleAnimator.SetBool("Landing", true);
        baldEagleAnimator.SetBool("IsSoaring", false);
        //baldEagleAnimator.applyRootMotion = true;
    }
}
