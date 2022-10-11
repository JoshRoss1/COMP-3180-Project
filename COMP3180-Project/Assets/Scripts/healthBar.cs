using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    private const float MAX_HEALTH = 100f;

    public float health = MAX_HEALTH;

    private Image healthImage;

    // Start is called before the first frame update
    void Start()
    {
        healthImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / MAX_HEALTH;
    }
}
