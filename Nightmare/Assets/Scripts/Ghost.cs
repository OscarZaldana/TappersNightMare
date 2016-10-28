using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    private Transform myTransform;
    private RaycastHit hit;
    private Vector3 dir;
    public AudioClip laugh;
    public AudioSource audio;
    

    public float moveSpeed = 1.0f;
    private float dist = 0;
    public float maxDist = 2.0f;
    public float soundVolume = 1.0f;

	// Use this for initialization
	void Start ()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(player != null)
        {
            ChasePlayer();
        }
        
	}

    private void ChasePlayer()
    {
        dir = player.position - rb.position;
        transform.LookAt(player.transform);
        dir.Normalize();
        rb.position += dir * moveSpeed * Time.deltaTime;

    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag =="Player")
        {
            audio.PlayOneShot(laugh);
        }
    }
}
