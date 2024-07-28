using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int numHeart;
    public int scene;

    public Image[] hearts;

    public Sprite fullHp;
    public Sprite emptyHp;

    public void takeHit(int damage) => health -= damage;

    private void FixedUpdate()
    {
        if (health > numHeart)
            health = numHeart;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
                hearts[i].sprite = fullHp;

            else
                hearts[i].sprite = emptyHp;
        }

        if (health <= 0)
            SceneManager.LoadScene(scene);
    }
}
