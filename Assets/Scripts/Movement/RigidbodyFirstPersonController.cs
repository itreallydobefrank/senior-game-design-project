using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [RequireComponent(typeof (Rigidbody))]
    [RequireComponent(typeof (CapsuleCollider))]
    public class RigidbodyFirstPersonController : MonoBehaviour
    {
        [Serializable]
        public class MovementSettings
        {
            public float ForwardSpeed = 8.0f; 
            public float BackwardSpeed = 4.0f; 
            public float StrafeSpeed = 4.0f;   
            public float SpeedInAir = 8.0f;
            public float JumpForce = 30f;
            public float runSpeed = 7.0f;
            public float slideSpeed = 5.0f;

            [HideInInspector] public float CurrentTargetSpeed = 8f;
            
#if !MOBILE_INPUT
            private bool m_Running;
#endif

            public void UpdateDesiredTargetSpeed(Vector2 input)
            {
	            if (input == Vector2.zero) return;
				if (input.x > 0 || input.x < 0)
				{
					//strafing
					CurrentTargetSpeed = StrafeSpeed;
				}
				if (input.y < 0)
				{
					//backwards
					CurrentTargetSpeed = BackwardSpeed;
				}
				if (input.y > 0)
				{
					//forwards
					CurrentTargetSpeed = ForwardSpeed;
				}

            }
        }

        public bool canrotate;
        public Camera cam;
        public MovementSettings movementSettings = new MovementSettings();
        public MouseLook mouseLook = new MouseLook();
        public Vector3 relativevelocity;

        public DetectObs detectGround;


        public bool Wallrunning;

        //Slide
        Rigidbody rig;
        CapsuleCollider collider;
        float originalHeight;
        public float reducedHeight;
        public float slideSpeed = 5f;


        private Rigidbody m_RigidBody;
        private CapsuleCollider m_Capsule;
        private float m_YRotation;
        private bool  m_IsGrounded;

        private float slideTimer = 0.0f;
    

        public Vector3 Velocity
        {
            get { return m_RigidBody.velocity; }
        }

        public bool Grounded
        {
            get { return m_IsGrounded; }
        }

        void Start()
        {
            collider = GetComponent<CapsuleCollider>();
            rig = GetComponent<Rigidbody>();
            originalHeight = collider.height;
        }

        private void Awake()
        {
            canrotate = true;
            m_RigidBody = GetComponent<Rigidbody>();
            m_Capsule = GetComponent<CapsuleCollider>();
            mouseLook.Init (transform, cam.transform);
        }


        private void Update()
        {
            relativevelocity = transform.InverseTransformDirection(m_RigidBody.velocity);
            if (m_IsGrounded)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    NormalJump();
                }

            }

        }


        private void LateUpdate()
        {
            if (canrotate)
            {
                RotateView();
            }
            else
            {
                mouseLook.LookOveride(transform, cam.transform);
            }
         

        }
        public void CamGoBack(float speed)
        {
            mouseLook.CamGoBack(transform, cam.transform, speed);

        }
        public void CamGoBackAll ()
        {
            mouseLook.CamGoBackAll(transform, cam.transform);

        }

        private void Sliding(){
            if(timer >= limit){
                isSliding = false;
            } 
            collider.height = reducedHeight;
            rig.AddForce(transform.forward * slideSpeed, ForceMode.VelocityChange);
        }

        private void up(){
            collider.height = originalHeight;
        }

        //Sliding condition variables
        private float timer = 0.0f;
        private float limit = 0.2f;
        bool isSliding;
        private float spamTimer = 0.0f;
        private float spamLimit = 3.0f;
        private bool spamTimerActive = false;

        private void FixedUpdate()
        {
            GroundCheck();
            Vector2 input = GetInput();

            float h = input.x;
            float v = input.y;
            Vector3 inputVector = new Vector3(h, 0, v);
            inputVector = Vector3.ClampMagnitude(inputVector, 1);

            //Time sliding
            if(isSliding == true)
            {
                timer += Time.deltaTime;
            } 
            //prevents spamming of slide
            if(spamTimerActive){
               spamTimer += Time.deltaTime; 
               if(spamTimer >= spamLimit){
                   spamTimerActive = false;
               }
            }

            //grounded
            if ((Mathf.Abs(input.x) > float.Epsilon || Mathf.Abs(input.y) > float.Epsilon) && m_IsGrounded && !Wallrunning)
            {
                if (Input.GetAxisRaw("Vertical") > 0.3f)
                {
                    if(Input.GetKey("left shift")){
                        m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * movementSettings.runSpeed * Mathf.Abs(inputVector.z));

                    if(Input.GetKey("c") && !isSliding &&!spamTimerActive){
                        isSliding = true; 
                        spamTimerActive = true;
                    }
                    
                    if(isSliding){
                        Sliding();
                    } else {
                        up();
                    }

                    } else {
                        m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * movementSettings.ForwardSpeed * Mathf.Abs(inputVector.z));
                    }
                }
                



                if (Input.GetAxisRaw("Vertical") < -0.3f)
                {
                    m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * -movementSettings.BackwardSpeed * Mathf.Abs(inputVector.z));
                }
                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * movementSettings.StrafeSpeed * Mathf.Abs(inputVector.x), 0, 0);
                }
                if (Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * -movementSettings.StrafeSpeed * Mathf.Abs(inputVector.x), 0, 0);
                }

            }
            //inair
            if ((Mathf.Abs(input.x) > float.Epsilon || Mathf.Abs(input.y) > float.Epsilon) && !m_IsGrounded  && !Wallrunning)
            {
                if (Input.GetAxisRaw("Vertical") > 0.3f)
                {
                    m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * movementSettings.SpeedInAir * Mathf.Abs(inputVector.z));
                }
                if (Input.GetAxisRaw("Vertical") < -0.3f)
                {
                    m_RigidBody.AddRelativeForce(0, 0, Time.deltaTime * 1000f * -movementSettings.SpeedInAir * Mathf.Abs(inputVector.z));
                }
                if (Input.GetAxisRaw("Horizontal") > 0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * movementSettings.SpeedInAir * Mathf.Abs(inputVector.x), 0, 0);
                }
                if (Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    m_RigidBody.AddRelativeForce(Time.deltaTime * 1000f * -movementSettings.SpeedInAir * Mathf.Abs(inputVector.x), 0, 0);
                }

            }

     
        }

        public void NormalJump()
        {
            m_RigidBody.velocity = new Vector3(m_RigidBody.velocity.x, 0f, m_RigidBody.velocity.z);
            m_RigidBody.AddForce(new Vector3(0f, movementSettings.JumpForce, 0f), ForceMode.Impulse);
        }
        public void SwitchDirectionJump()
        {
            m_RigidBody.velocity = transform.forward * m_RigidBody.velocity.magnitude;
            m_RigidBody.AddForce(new Vector3(0f, movementSettings.JumpForce, 0f), ForceMode.Impulse);
        }

        private Vector2 GetInput()
        {
            
            Vector2 input = new Vector2
                {
                    x = Input.GetAxisRaw("Horizontal"),
                    y = Input.GetAxisRaw("Vertical")
                };
			movementSettings.UpdateDesiredTargetSpeed(input);
            return input;
        }


        private void RotateView()
        {
            if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

            float oldYRotation = transform.eulerAngles.y;
            mouseLook.LookRotation (transform, cam.transform);
        }


        // sphere cast to check ground
        private void GroundCheck()
        {
          if(detectGround.Obstruction)
            {
                m_IsGrounded = true;
            }
          else
            {
                m_IsGrounded = false;

            }
        }
    }
}
