using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementsScript : MonoBehaviour
{
    private Color gray = Color.gray;

    //normal achievements
    public static bool amongusAchievement, bonked, blinko, bronze, silver, gold, splat, stuck, boom, supersonic, invalid, anakin, author, backrooms, ten;
    public RawImage amongusImage;
    public TMP_Text amongusText, bonkedText, blinkoText, bronzeText, silverText, goldText, splatText, stuckText, boomText, supersonicText, invalidText, anakinText, authorText, backroomsText, tenText;
    public RawImage bonkedImage, blinkoImage, bronzeImage, silverImage, goldImage, splatImage, stuckImage, boomImage, supersonicImage, invalidImage, anakinImage, authorImage, backroomsImage, tenImage;
    public Texture authorImageRevealed, backroomsImageRevealed, tenImageRevealed;


    // Start is called before the first frame update
    void Start()
    {
        //normal achievements
        if(!amongusAchievement){amongusImage.color = gray; amongusText.color = gray;}
        if(!bonked){bonkedImage.color = gray; bonkedText.color = gray;}
        if(!blinko){blinkoImage.color = gray; blinkoText.color = gray;}
        if(!bronze){bronzeImage.color = gray; bronzeText.color = gray;}
        if(!silver){silverImage.color = gray; silverText.color = gray;}
        if(!gold){goldImage.color = gray; goldText.color = gray;}
        if(!splat){splatImage.color = gray; splatText.color = gray;}
        if(!stuck){stuckImage.color = gray; stuckText.color = gray;}
        if(!boom){boomImage.color = gray; boomText.color = gray;}
        if(!supersonic){supersonicImage.color = gray; supersonicText.color = gray;}
        if(!invalid){invalidImage.color = gray; invalidText.color = gray;}
        if(!anakin){anakinImage.color = gray; anakinText.color = gray;}

        //secret achievements
        if(author){authorImage.texture = authorImageRevealed; authorText.text = "Author"; authorImage.color = Color.white; authorText.color = Color.white;}
        else{authorImage.color = gray; authorText.color = gray;}
        if(backrooms){backroomsImage.texture = backroomsImageRevealed; backroomsText.text = "Backrooms"; backroomsImage.color = Color.white; backroomsText.color = Color.white;}
        else{backroomsImage.color = gray; backroomsText.color = gray;}
        if(ten){tenImage.texture = tenImageRevealed; tenText.text = "10x Blinko"; tenImage.color = Color.white; tenText.color = Color.white;}
        else{tenImage.color = gray; tenText.color = gray;}
    }
}