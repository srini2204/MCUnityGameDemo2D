using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

namespace ToyBox.MatchMe
{
    public enum CardState
    {
        IDLE,
        HINTING,
        SELECTED,        
        MATCHED,
        WRONG
    }

    public class CardAnimationController : MonoBehaviour, IPointerClickHandler
    {

        public Animator cardAnimator;
        public CardState cardState = CardState.IDLE;
        
        public Sprite[] cardSprites;
        public Sprite currentSprite;

        public Image selected;
        public Image card;

        // Use this for initialization
        void Awake()
        {
            cardAnimator = this.GetComponentInChildren<Animator>();
        }

        //Handler for touch and mouse click
        public void OnPointerClick(PointerEventData eventData)
        {
            if (cardState == CardState.IDLE || cardState == CardState.HINTING)
            {
                if (CardController.cardASkin == null)
                {
                    CardController.cardASkin = this;
                    setCardSelected(false);
                }
                else if (CardController.cardBSkin == null)
                {
                    CardController.cardBSkin = this;
                    setCardSelected(true);
                }
            }
        }

        //sets the card as selected card
        void setCardSelected(bool isBothSelected)
        {

            selected.enabled = true;
            cardState = CardState.SELECTED;

            if (isBothSelected)
            {
                SendMessageUpwards("checkCards");
            }
        }

        //sets tha card as matched card
        public void setCardMatch()
        {
            cardState = CardState.MATCHED;
            cardAnimator.SetTrigger("match");
            Debug.Log("Card Match");
        }

        //set card as wrong card
        public void setCardWrong()
        {
            selected.enabled = false;
            cardState = CardState.WRONG;
        }

        //reset card state
        public void reset()
        {
            cardAnimator.SetTrigger("flip");
            cardState = CardState.IDLE;
            selected.enabled = false;
        }

        public void setCardSprite(Sprite sprite)
        {
            currentSprite = sprite;
            card.sprite = sprite;
        }

        public void showHint()
        {
            if(cardState == CardState.IDLE)
            {
                cardAnimator.SetTrigger("hint");
            }
        }
        
    }
}