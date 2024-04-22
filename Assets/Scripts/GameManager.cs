using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UnityEngine.UI.Image healthBar;
    public TMP_Text suspicion;
    public float actualHealth;
    public float maxHealth;
    public float suspicionLevel;

    private void Start()
    {

    }

    void Update()
    {
        healthBar.fillAmount = actualHealth / maxHealth;
        suspicion.text = "Sospecha: " + suspicionLevel + "%";
    }
}
