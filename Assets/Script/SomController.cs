using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SomController : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource somUm;
    [SerializeField] private AudioSource somDois;
    [SerializeField] private AudioSource somTres;

    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image muteImage;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        somUm.enabled = estadoSom;
        somDois.enabled = estadoSom;
        somTres.enabled = estadoSom;

        if (estadoSom)
        {
            muteImage.sprite = somLigadoSprite;
        }
        else
        {
            muteImage.sprite = somDesligadoSprite;
        }
    }

    public void VolumeMusical(float value)
    {
        somUm.volume = value;
        somDois.volume = value;
        somTres.volume = value;
    }
}
