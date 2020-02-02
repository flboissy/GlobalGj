using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Classes;
using UnityEngine.UI;

public class ActionableComponent : MonoBehaviour
{

    private bool isSelected;
    private SpriteRenderer spriteRenderer;
    private Renderer myRenderer;
    public Sprite selectedSprite;
    public Sprite notSelectedSprite;
    public bool isVisible;

    public float health;
    private float currentHealth;

    public Image healthBar;

    public bool getIsVisible()
    {
        return isVisible;
    }

    public void setIsSelected(bool val)
    {
        isSelected = val;
    }

    public bool getIsSelected()
    {
        return isSelected;
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myRenderer = GetComponent<Renderer>();
        currentHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
        if (CheckIfVisibilityChange(isVisible, spriteRenderer.isVisible))
        {
            isVisible = spriteRenderer.isVisible;
            GameManager.Instance.UpdateSelectableComponenent();
        }

        if (isSelected)
        {
            spriteRenderer.sprite = selectedSprite;
        }
        else
        {
            spriteRenderer.sprite = notSelectedSprite;
        }
    }

    public void StartCooldownCoroutine(Action action)
    {
        StartCoroutine(CoolDownCoroutine(action));
    }

    public bool CheckIfVisibilityChange(bool currentVal, bool newVal)
    {
        return currentVal != newVal;
    }

    IEnumerator CoolDownCoroutine(Action action)
    {
        action.inCooldown = true;
        yield return new WaitForSeconds(action.Cooldown);
        action.inCooldown = false;
    }

    public void TakeDamages(float amount)
    {
        this.currentHealth -= amount;
        if(currentHealth < 0)
        {
            GameManager.Instance.LoseComponent(this);
        }
        float toto = (currentHealth * health) / 100;
        this.healthBar.fillAmount = toto;
    }
}
