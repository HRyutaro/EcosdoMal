using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundController : MonoBehaviour
{
    private bool estadoSom = true;
    [SerializeField] private AudioSource somPrincipal;
    [SerializeField] private AudioSource fundoMusical;
    [SerializeField] private AudioSource somSfx;

    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image muteImage;

    public void LigarDesligarSom()
    {
        estadoSom = !estadoSom;
        fundoMusical.enabled = estadoSom;
        somSfx.enabled = estadoSom;
        somPrincipal.enabled = estadoSom;

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
        fundoMusical.volume = value;
        somSfx.volume = value;
        somPrincipal.volume = value;
    }
}