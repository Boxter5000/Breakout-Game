using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkelsVFX;
    [SerializeField] Sprite[] hitSprites;
        

    level Level;

    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        Level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            Level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        int SpriteIndex = timesHit - 1;
        if(hitSprites[SpriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[SpriteIndex];
        }
        else
        {
            Debug.LogError("Sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        Level.BlockDestroid();
        TriggerSparkelsVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparkelsVFX()
    {
        GameObject sparkels = Instantiate(blockSparkelsVFX, transform.position, transform.rotation);
        Destroy(sparkels, 2f);
    }
}
