using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Collectables : MonoBehaviour
{
    public TextMeshProUGUI[] _Pointsdisplay;
    private int _points;

    public GameObject CollectableWorth1Point;
    public GameObject CollectableWorth2Points;
    public GameObject CollectableWorth3Points;
    public GameObject CollectableWorth4Points;
    public GameObject CollectableWorth5Points;

    public GameObject player;

    public static Action OnCollectableCollected;
    public int Collectabless { get => _points; }
    // Start is called before the first frame update
    void Start()
    {
        //_points = 0;
        Collectables.OnCollectableCollected += CollectableCollected;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_points);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
                {
            if (!(OnCollectableCollected is null))
                OnCollectableCollected();

            Destroy(gameObject);
                }
                }
    private void CollectableCollected()
    {
        _points++;
    }

    public void OnDestroy()
    {
        Collectables.OnCollectableCollected -= CollectableCollected;
    }
}
