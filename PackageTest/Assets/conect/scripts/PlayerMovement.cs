using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public bool isMoving = false;
    private Vector3 targetPosition;
    public float speed = 1f;
    private Animator animator;
    private bool run;
    private bool afk;
 public bool paused=false; 
    // Start is called before the first frame update
      public void play()
    {
        paused = false;
        Time.timeScale = 1f;
    }
    public void Pause()
    {
          paused = true;
        Time.timeScale = 0f;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        
       
       
    }

    private void Update()   
    { if(paused==false)
    {if (Input.GetMouseButton(0))
        {
            // Check if the mouse is over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return; // Exit the method and don't execute player movement code
            }

            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        if (isMoving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);

            // Define a coroutine to check for movement
            IEnumerator CheckMovement()
            {
                Vector3 initialPosition = transform.position;

                // Wait for a short period of time
                yield return new WaitForSeconds(0.1f);

                // Check if the position has changed
                if (transform.position == initialPosition)
                {
                    isMoving = false;
                }
            }

            StartCoroutine(CheckMovement());
        }
    
  

        

           
            Vector3 direction = targetPosition - transform.position;

            
            direction.Normalize();

          
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            
            if (direction.x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Rotate left
            }
            else if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Rotate right
            }

           
        
          
          if (isMoving==true)
        {
            run = true;
            afk = false;
        }
        else
        {
            run = false;
            afk = true;
        }
        animator.SetBool("run", run);
        animator.SetBool("afk", afk);

    }
    else
    { return;

    }    
        
    

    }
}

