![enter image description here](https://cdn.discordapp.com/attachments/916248167941566534/1242993594235883540/image.png?ex=664fdb7e&is=664e89fe&hm=f9aa3292ac41ad3007a7c806fc68347ed934546a6071756849816e5d63b5c4e7&)



Player 오브젝트의 움직임과 Animation 기능을 구현한 Script입니다.



```
public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer spriter;
    Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        Vector3 worldPos = Camera.main.WorldToViewportPoint(transform.position);
        if (worldPos.x < 0.1f) worldPos.x = 0.1f;
        if (worldPos.x > 0.9f) worldPos.x = 0.9f;
        
        transform.position = Camera.main.ViewportToWorldPoint(worldPos);
    }

    private void FixedUpdate()
    {
        Vector2 move = inputVec * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    private void LateUpdate()
    {
        if(inputVec.x != 0 && CompareTag("Chibi"))
        {
            spriter.flipX = inputVec.x > 0;
        }

        if(inputVec.x != 0 && CompareTag("Gordo"))
        {
            if(inputVec.x < 0)
            {
                transform.localScale = new Vector2(0.25f, 0.22f);
            }
            else if(inputVec.x > 0) 
            {
                transform.localScale = new Vector2(-0.25f, 0.22f);
            }
        }
        anim.SetFloat("Speed",inputVec.magnitude);
    }
}
```
