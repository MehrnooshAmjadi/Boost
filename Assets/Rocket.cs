using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

    Rigidbody rigidBody;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) 
        {
            case "Friendly":
                print("Ok!");
                break;
            case "Finish":
                print("Hit Finish!");
                SceneManager.LoadScene(1);
                break;
            default:
                print("Dead");
                SceneManager.LoadScene(0);
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * mainThrust);

            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation
        float rotaionThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotaionThisFrame);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotaionThisFrame);
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
    }
}
