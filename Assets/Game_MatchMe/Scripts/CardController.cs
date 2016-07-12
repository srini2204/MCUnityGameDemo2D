using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace ToyBox.MatchMe
{

    public class CardController : MonoBehaviour
    {
        public CardAnimationController[] cards;
        public
        int nextMatchID;
        public Sprite[] cardSprites;

        public bool timeToShuffle;

        public ScoreManager scoreManager;

        public static Sprite sprite;
        public static CardAnimationController cardASkin;
        public static CardAnimationController cardBSkin;


        public float startTime;
        static float shuffleTime;
        float hintTime;

        public float hintDelay;
        public float shuffleDelay;

        float deltaShuffleDelay, deltaHintDelay;

        //GameManager gm;

        public bool beginSpawning;

        // Use this for initialization
        void Awake()
        {
            reset();
            startSpawning();
        }

        public void reset()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].reset();
            }
        }

        public void startSpawning()
        {
            beginSpawning = true;
            cards = GetComponentsInChildren<CardAnimationController>();
            //audioSource = GetComponent<AudioSource>();

            foreach (var item in cards)
            {
                item.cardSprites = cardSprites;
            }

            scoreManager.startTimer();

            timeToShuffle = true;
            startTime = Time.realtimeSinceStartup * 1000;
            hintTime = Time.realtimeSinceStartup * 1000;
            shuffleCards();
        }

        public void stopSpawning()
        {
            beginSpawning = false;
        }

        // Update is called once per frame
        void Update()
        {
            deltaShuffleDelay = (Time.realtimeSinceStartup * 1000) - shuffleTime;
            deltaHintDelay = (Time.realtimeSinceStartup * 1000) - hintTime;
            //check the states of all the bandits
            //notify bandits to appear
            //notify bandits to change texture
            if (beginSpawning)
            {
                if (timeToShuffle && deltaShuffleDelay > shuffleDelay)
                {
                    shuffleCards();
                }

                if (deltaHintDelay > hintDelay)
                {
                    showHint();
                    hintTime = Time.realtimeSinceStartup * 1000;
                }
            }
        }

        void showHint()
        {
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].currentSprite == sprite)
                {
                    cards[i].showHint();
                }
            }
        }

        public bool checkCards()
        {
            bool isMatch = false;
            if (cardASkin.currentSprite == cardBSkin.currentSprite)
            {
                isMatch = true;
                setMatchCards();
                scoreManager.incrementScore(2);
            }
            else
            {
                isMatch = false;
                setWrongCards();
                //Debug.Log("Cards not Matched");
            }

            timeToShuffle = true;
            shuffleTime = Time.realtimeSinceStartup * 1000;
            return isMatch;
        }

        public void setMatchCards()
        {
            cardASkin.setCardMatch();
            cardBSkin.setCardMatch();
        }

        public void setWrongCards()
        {
            cardASkin.setCardWrong();
            cardBSkin.setCardWrong();
        }

        int getNextMatchID(int min, int max)
        {
            int index = -1;

            index = Random.Range(min, max);
            return index;
        }

        void shuffleCards()
        {
            cardASkin = null;
            cardBSkin = null;
            sprite = null;

            reset();

            //shuffle the list once
            cardSprites = shuffleArray(cardSprites);
            //find the enxt id within the cards length of the sub array
            nextMatchID = getNextMatchID(0, cards.Length - 1);
            sprite = cardSprites[nextMatchID];

            Sprite[] finalSkinValues = new Sprite[cards.Length];

            for (int i = 0; i < finalSkinValues.Length; i++)
            {
                finalSkinValues[i] = cardSprites[i];
            }
            finalSkinValues[5] = cardSprites[nextMatchID];

            //shiffle the final list
            finalSkinValues = shuffleArray(finalSkinValues);

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].setCardSprite(finalSkinValues[i]);
            }

            timeToShuffle = false;
            shuffleTime = Time.realtimeSinceStartup * 1000;
            hintTime = Time.realtimeSinceStartup * 1000;
        }

        Sprite[] shuffleArray(Sprite[] arr)
        {
            List<KeyValuePair<int, Sprite>> list = new List<KeyValuePair<int, Sprite>>();
            // Add all strings from array
            // Add new random int each time
            foreach (Sprite s in arr)
            {
                list.Add(new KeyValuePair<int, Sprite>((int)(Random.value * 10), s));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            Sprite[] result = new Sprite[arr.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, Sprite> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        }
    }
}