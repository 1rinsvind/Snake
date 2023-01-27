using TMPro;
using UnityEngine;


public class CreateandDestroy : MonoBehaviour
{
    public Control Controls;
    public GameObject bodyprefab;
    public Rigidbody Rigidbody;
    public Vector3 BodyVector;
    public int HP;
    public TMP_Text hp;
    public Food FoodScript;
    public Block BlockScript;
    public int Speed;
    public GameObject Skull;
    public GameObject Minus;
    public GameObject Death;
    public GameObject Win;
    public GameObject ResButton;
    public AudioSource Music;
    public AudioSource BlockMusic;
    public AudioSource FoodMusic;
    public GameObject Crown;

    private void Start()
    {        
        Rigidbody = GetComponent<Rigidbody>();
        Speed = 33;
        hp.text = "";
    }
    private void Update()
    {
        GetComponent<Renderer>().material.SetFloat("_Gradient", HP);
        Rigidbody.velocity = new Vector3(Speed, 0, 0);       

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Food food))
        {
            FoodMusic.Play();
            GetComponent<ParticleSystem>().Play(false);
            FoodScript = other.GetComponent<Food>();
            int FoodHP = FoodScript.HP;
            for (int e = HP + FoodHP; HP < e; HP++)
            {
                GameObject body = Instantiate(bodyprefab, (this.transform.position + BodyVector), Quaternion.identity);
                if (HP == 0)
                {
                    body.GetComponent<SnakeBody>().goal = GameObject.Find($"Player");
                }
                if (HP > 0)
                {
                    body.GetComponent<SnakeBody>().goal = GameObject.Find($"Body{ HP - 1}");
                }
                BodyVector = BodyVector + new Vector3(-7, 0, 0);
                body.name = ($"Body{HP}");
            }
            hp.text = $"{HP}";
        }

        if (other.TryGetComponent(out Block block))
        {
            BlockMusic.Play();
            Minus.GetComponent<ParticleSystem>().Play();
            BlockScript = other.GetComponent<Block>();
            int BlockHP = BlockScript.HP;

            for (int e = HP + BlockHP; HP > e; HP -= 1)
            {
                GameObject body = GameObject.Find($"Body{HP - 1}");
                Destroy(body);
                BodyVector = BodyVector - new Vector3(-7, 0, 0);
                if (HP == 0)
                    break;
            }
            hp.text = $"{HP}";
            if (HP == 0)
            {
                hp.text = "";
                Speed = 0;
                Controls.enabled = false;
                Skull.SetActive(true);
                Death.SetActive(true);
                Music.Stop();
            }
        }
        if (other.TryGetComponent(out Finish finish))
        {
            while (HP > 0)
            {
                GameObject body = GameObject.Find($"Body{HP - 1}");
                Destroy(body);
                HP -= 1;
            }

            hp.text = "";
            Speed = 0;
            Controls.enabled = false;
            Win.SetActive(true);
            ResButton.SetActive(false);
            Crown.SetActive(true);

        }
    }   
    
}