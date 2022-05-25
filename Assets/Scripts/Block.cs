using UnityEngine;

public class Block : MonoBehaviour
{
    public float durability { get; private set; }

    private void Start()
    {
        this.Reset();
    }

    public void Hit()
    {
        durability -= Time.deltaTime;
        if (durability <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Reset()
    {
        durability = 1;
    }

    private void Update()
    {
        Hit();
    }
}
