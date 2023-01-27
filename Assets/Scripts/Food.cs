using UnityEngine;
using TMPro;

public class Food : MonoBehaviour
{
    public GameObject GameObjectFood;
    public int HP;
    public TMP_Text hp;

    void Start()
    {
        HP = UnityEngine.Random.Range(1, 21);
        hp.text = $"{HP}";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CreateandDestroy CreateandDestroy))
        { Destroy(GameObjectFood); }
    }   
}
