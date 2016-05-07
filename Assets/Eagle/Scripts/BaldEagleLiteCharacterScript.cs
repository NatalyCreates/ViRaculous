using UnityEngine;
using System.Collections;

public class BaldEagleLiteCharacterScript : MonoBehaviour {
	public Animator baldEagleAnimator;
	Rigidbody baldEagleRigid;
	public bool isFlying=false;
	public float upDown=0f;
	public float forwardAcceleration=0f;
	public float yawVelocity=0f;
	public float groundCheckDistance=5f;
	public bool soaring=false;
	public bool isGrounded=true;
	public float forwardSpeed=0f;
	public float maxForwardSpeed=300f;
	public float meanForwardSpeed=30f;
	public float speedDumpingTime=.1f;
	public float groundedCheckOffset=1f;

    public AudioClip CollisionSound;
	public AudioClip BackgroundSound;
	public AudioClip CookieMonster;
	private AudioSource cookieMonster;
	private AudioSource backgroundAudio;
	private AudioSource collisionAudio;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Candy")
        {
            //Attack();
			TextUpdater.Score += 10;
			Destroy(other.gameObject);
			if (TextUpdater.Score % 50 == 0) {
				cookieMonster.PlayOneShot(CookieMonster, 0.8F);
			} else {
				collisionAudio.PlayOneShot(CollisionSound, 2.0F);
			}


        }
    }

	void Start(){
		baldEagleAnimator = GetComponent<Animator> ();
		baldEagleRigid = GetComponent<Rigidbody> ();
		collisionAudio = gameObject.AddComponent<AudioSource>();
		backgroundAudio = gameObject.AddComponent<AudioSource>();
		cookieMonster = gameObject.AddComponent<AudioSource>();
		backgroundAudio.PlayOneShot(BackgroundSound, 0.1F);
	}

    void Update(){
		Move ();
		if (baldEagleAnimator.GetCurrentAnimatorClipInfo (0) [0].clip.name == "GlideForward" ) {
			if(soaring){
				soaring=false;
				baldEagleAnimator.SetBool ("IsSoaring", false);
				baldEagleAnimator.applyRootMotion = false;
			}
		}else if(baldEagleAnimator.GetCurrentAnimatorClipInfo (0) [0].clip.name == "HoverOnce" ){
			forwardSpeed=meanForwardSpeed*.5f;
			baldEagleAnimator.applyRootMotion = false;
			isFlying = true;
		}
		GroundedCheck ();
	}

	void GroundedCheck() {
        if (gameObject.transform.position.y <= 0.3f)
        {
            if (!soaring && !isGrounded)
            {
                Landing();
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = false;
        }

        /*
		RaycastHit hit;
		if (Physics.Raycast (transform.position+Vector3.up*groundedCheckOffset, Vector3.down, out hit, groundCheckDistance)) {
			if (!soaring && !isGrounded ) {
				Landing ();
				isGrounded = true;		
			}
		} else {
			isGrounded=false;
		}
        */
	}

	public void Landing(){
		baldEagleAnimator.SetBool ("Landing",true);
		baldEagleAnimator.applyRootMotion = true;
		//baldEagleRigid.useGravity = true;
		isFlying = false;
	}
	
	public void Soar(){
        Debug.Log("soar");
        if (isGrounded)
        {
            Debug.Log("was grounded");
            baldEagleAnimator.SetBool("Landing", false);
            baldEagleAnimator.SetBool("IsSoaring", true);
            baldEagleRigid.useGravity = false;
            soaring = true;
            isGrounded = false;
        }
    }

	public void Attack(){
		baldEagleAnimator.SetTrigger ("Attack");
	}
	
	public void Hit(){
		baldEagleAnimator.SetTrigger ("Hit");
	}

	public void Move(){
		baldEagleAnimator.SetFloat ("Forward",forwardAcceleration);
		baldEagleAnimator.SetFloat ("Turn",yawVelocity);
		baldEagleAnimator.SetFloat ("UpDown",upDown);
		baldEagleAnimator.SetFloat ("UpVelocity",baldEagleRigid.velocity.y);

		if(isFlying ) {

			if(forwardAcceleration<0f){
				baldEagleRigid.velocity=transform.up*upDown+transform.forward*forwardSpeed;	
			}else{
				baldEagleRigid.velocity=transform.up*(upDown+( forwardSpeed-meanForwardSpeed))+transform.forward*forwardSpeed;
			}

			transform.RotateAround(transform.position,Vector3.up,Time.deltaTime*yawVelocity*100f);
			forwardSpeed=Mathf.Lerp(forwardSpeed,0f,Time.deltaTime*speedDumpingTime);
			forwardSpeed=Mathf.Clamp( forwardSpeed+forwardAcceleration*Time.deltaTime,0f,maxForwardSpeed);
			upDown=Mathf.Lerp(upDown,0,Time.deltaTime*3f);	
		}
	}
}
