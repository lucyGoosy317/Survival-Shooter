using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float speed = 0.01f;
    public float obsticalRange = 5.0f;
    public Animator anime;
    public int zombieHealth = 10;
    bool keepPlaying = true;
    //public List<AudioSource>zombieSounds= new List<AudioSource>();
    public AudioClip zombieGrowl;
    public AudioClip zombieWalk;

    private bool _alive;
    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
        
       // zombieSounds[0] =  GetComponentInChildren<AudioSource>();
       // zombieSounds[1] = GetComponentInChildren<AudioSource>();
        //zombieSounds[2]= GetComponentInChildren<AudioSource>();
        anime = GetComponentInChildren<Animator>();
        StartCoroutine(playSoundAfterDely());
        StartCoroutine(ZombieWalk());
    }
    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //zombieWalking.Play();
        //checks to see if the enemy is alive
        if (_alive)
        {
            //if they are they keep moving foward
            anime.SetInteger("Condition", 1);
            transform.Translate(0, 0, speed * Time.deltaTime/5);
            Debug.Log("Zombie is walking");
            

        }
        else
        {
            keepPlaying = false;
            anime.SetInteger("Condition", 3);
            return;
        }      
        //check to see if the enemy ran into an obstical
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray,0.75f, out hit))
        {
            if (hit.distance<obsticalRange)
            {
                anime.SetInteger("Condition",0);
                Debug.Log("zombie ran into something");
                float angle = Random.Range(-110, 110);
                transform.Rotate(0,angle,0);
            }
        }
        //
    }

    public void SetAlive(bool isAlive)
    {
        _alive = isAlive;
    }

    IEnumerator playSoundAfterDely()
    {

        while (keepPlaying)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(zombieGrowl);
            

           // zombieSounds[1].Play();
            Debug.Log("Zombie growl");
            yield return new WaitForSeconds(10);
        }
        
    }
    IEnumerator ZombieWalk()
    {

        while (keepPlaying)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(zombieWalk);


            // zombieSounds[1].Play();
            Debug.Log("Zombie walk");
            yield return new WaitForSeconds(2f);
        }

    }


}
