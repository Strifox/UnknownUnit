using UnityEngine;

namespace Assets.Scripts
{
    public class Hover : Singleton<Hover>
    {
        private SpriteRenderer spriteRenderer;

        // Use this for initialization
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            FollowMouse();
        }

        private void FollowMouse()
        {
            if (spriteRenderer.enabled)
            {

                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
        }

        public void Activate(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
            spriteRenderer.enabled = true;
        }

        public void Deactivate()
        {
            spriteRenderer.enabled = false;
            GameManager.Instance.TowerBtn = null;
        }
    }
}
