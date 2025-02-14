using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private int _health;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        MedicineChest.takeMedicineChest += UseMedicineChest;
    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(-1, 0, 0) * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(1, 0, 0) * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0, 0, -1) * _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0, 0, 1) * _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -20 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 20 * Time.deltaTime, 0);
        }

    }

    private void FixedUpdate()
    {
        _rb.angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.U))
        {
            _rb.velocity = Vector3.left * _speed;
        }
        if (Input.GetKey(KeyCode.J))
        {
            _rb.velocity = Vector3.right * _speed;
        }
        if (Input.GetKey(KeyCode.H))
        {
            _rb.velocity = Vector3.back * _speed;
        }
        if (Input.GetKey(KeyCode.K))
        {
            _rb.velocity = Vector3.forward * _speed;
        }

        if (Input.GetKey(KeyCode.Y))
        {
            _rb.angularVelocity = Vector3.down * _speed;
        }
        if (Input.GetKey(KeyCode.I))
        {
            _rb.angularVelocity = Vector3.up * _speed;
        }
    }

    public void UseMedicineChest(int bonusHealth)
    {
        _health += bonusHealth;
        Debug.Log("HP:"+_health);
    }

    private void OnDestroy()
    {
        MedicineChest.takeMedicineChest -= UseMedicineChest;
    }
}
