using UnityEngine;

public class Ball : MonoBehaviour
{
    // config parrameter
    [SerializeField] Paddle paddle1;
    [SerializeField] float HorizontalsVelocity = 2f;
    [SerializeField] float VerticlaVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    

    //state
    Vector2 PaddleToBallVector;
    bool hasStardet = false;

    // Cacht component references
    AudioSource myAudioSource;
    Rigidbody2D myRigitBody2D;

    void Start()
    {
        PaddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigitBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!hasStardet)
        {
            LockBallToPaddle();
            LaunchOnClick();
        }
    }

    private void LaunchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigitBody2D.velocity = new Vector2(HorizontalsVelocity, VerticlaVelocity);
            hasStardet = true;
        }
    }

    private void LockBallToPaddle()
    {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + PaddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(0f, randomFactor),
            Random.Range(0f, randomFactor));

        if (hasStardet)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigitBody2D.velocity += velocityTweak;
        }
    }
}
