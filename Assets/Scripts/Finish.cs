using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject Stars;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CreateandDestroy CreateandDestroy))
        { Stars.SetActive(true); }
    }
}
