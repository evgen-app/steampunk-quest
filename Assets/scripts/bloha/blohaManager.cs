using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class blohaManager : MonoBehaviour
{

    [SerializeField] private GameObject dialog;
    [SerializeField] private GameObject WinDialog;

    [SerializeField] private GameObject filter;
    [SerializeField] private float speed;
    [SerializeField] private VariableJoystick variableJoystick;
    [SerializeField] private List<GameObject> labirints;
    private Rigidbody2D rb;
    private Vector3 startPosition;
    private bool showDialog = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        startPosition = gameObject.transform.position;
        Instantiate(labirints[PlayerPrefs.GetInt("chestNumber")], gameObject.transform.parent);
    }
    public void FixedUpdate()
    {
        Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;

        if(direction.x != 0 && direction.y != 0)
        {
            if (direction.x > 0)
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, -Convert.ToSingle(180 / Math.PI * (Math.Acos(direction.y / (Math.Sqrt(direction.x * direction.x + direction.y * direction.y))))));

            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0f, 0f, Convert.ToSingle(180 / Math.PI * (Math.Acos(direction.y / (Math.Sqrt(direction.x * direction.x + direction.y * direction.y))))));

            }
        }

        rb.AddForce(direction * speed * Time.fixedDeltaTime);
        if (showDialog && (Input.touchCount > 0 || Input.anyKeyDown))
        {
            dialog.SetActive(false);
            filter.SetActive(false);
            showDialog = false;
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation = new Quaternion();
            rb.angularVelocity = 0f;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "aim")
        {
            Debug.Log("Вы Выиграли");
            Destroy(collision.gameObject);
            WinDialog.SetActive(true);
            filter.SetActive(true);

        }
        else
        {
            dialog.SetActive(true);
            filter.SetActive(true);
            showDialog = true;
            rb.velocity = new Vector2(0f, 0f);
            gameObject.transform.position = startPosition;
        }
    }
    public void chestOpen()
    {
        PlayerPrefs.SetInt("chest" + PlayerPrefs.GetInt("chestNumber").ToString(), 1);
        SceneManager.UnloadScene("BlohaGame");
        //происходит то, чтобы сундук открывался
    }

}


