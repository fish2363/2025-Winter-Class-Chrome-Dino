using UnityEngine;



public class Dino : MonoBehaviour
{

    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private ScoreManager scoreManager;
    
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deadSound;
    
    [SerializeField] private int jumpPower = 5;

    private bool isGround = true;
    private Vector2 originSize;
    private Vector2 originOffset;
    
    private Rigidbody2D rigid;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private AudioSource audioSource;

   

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        originSize = boxCollider2D.size;
        originOffset = boxCollider2D.offset;
    }

    private void Update()
    {
        TryJump();
        Down();
        animator.SetBool("IsGround", isGround);
    }

    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            audioSource.PlayOneShot(jumpSound);
            isGround = false;
            rigid.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    private void Down()
    {
        if (Input.GetKey(KeyCode.DownArrow) && isGround == true)
        {
            animator.SetBool("Low",true);
            boxCollider2D.offset = new Vector2(0, -0.25f);
            boxCollider2D.size = new Vector2(originSize.x, originSize.y/2);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) && isGround == true)
        {
            animator.SetBool("Low",false);
            boxCollider2D.offset = originOffset;
            boxCollider2D.size = originSize;
        }
    }
    
    
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            if (isGround == true)
                return;
            
            isGround = true;
        }
        else if (collision.collider.CompareTag("Obstacle"))
            GameOver();
    }

    private void GameOver()
    {
        animator.SetBool("Dead",true);
        audioSource.PlayOneShot(deadSound);
        gameOverUI.SetActive(true);
        scoreManager.SetHighScore();
        
        Time.timeScale = 0;
    }
}
