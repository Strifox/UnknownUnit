using System.Collections;
using System.Collections.Generic;
using Assets.Entities;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SellBtn : MonoBehaviour
{
    public Tower SelectedTower;

    [SerializeField] private Text PaybackText;

    private int payback;

    public int Payback
    {
        get { return payback; }
        set { payback = value; this.PaybackText.text = "Get: " + value; }
    }
    // Use this for initialization
    void Start()
    {
        Payback = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                SelectedTower = hit.collider.gameObject.GetComponent<Tower>();
                Payback = this.SelectedTower.BaseCost / 4;
            }
        }
    }

    public void SellTower()
    {
        if (SelectedTower != null)
        {
            GameManager.Instance.Gold += Payback;
            this.SelectedTower.gameObject.SetActive(false);
            SelectedTower = null;
            Payback = 0;
        }
    }
}
