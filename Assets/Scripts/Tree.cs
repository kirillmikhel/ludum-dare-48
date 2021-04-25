using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Polybrush;

public class Tree : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth = 4;
    public int logDropAmount = 1;

    private MeshRenderer _meshRenderer;
    private DropOnDestroy _dropOnDestroy;
    public bool IsDead => currentHealth <= 0;

    // Start is called before the first frame update
    void Start()
    {
        _dropOnDestroy = GetComponent<DropOnDestroy>();
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReceiveDamage(int damage)
    {
        currentHealth = Mathf.Max(0, currentHealth - damage);

        if (IsDead)
        {
            for (var i = 0; i < logDropAmount; i++)
            {
                _dropOnDestroy.Drop(transform.position + Vector3.up);
            }

            Destroy(gameObject);
            return;
        }

        StartCoroutine(DisplayDamage());
    }

    private IEnumerator DisplayDamage()
    {
        var material = _meshRenderer.material;

        var color = material.color;

        material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        material.color = color;
    }
}