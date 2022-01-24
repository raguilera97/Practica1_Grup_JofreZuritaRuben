using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsController : MonoBehaviour, Interactable
{
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator anim;
    public Collider2D bounds;
    private bool playerInRange;
    public Dialogue dialogue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    public void Interact()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        AdvancedDialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

    private void Awake()
    {
        playerInRange = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange)
        {
            Move();
        }
            
    }

    private void Move()
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
        
    }

    void ChangeDirection()
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                directionVector = Vector3.right;
                break;
            case 1:
                directionVector = Vector3.up;
                break;
            case 2:
                directionVector = Vector3.left;
                break;
            case 3:
                directionVector = Vector3.down;
                break;
            default:
                break;
        }
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        anim.SetFloat("MoveX", directionVector.x);
        anim.SetFloat("MoveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while(temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            anim.SetBool("InTrigger", true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            anim.SetBool("InTrigger", false);
            playerInRange = false;
        }
    }
}
