using UnityEngine;
using System;
using UnityEngine.UI;

namespace ToyBox.MainMenu
{
    public class ReSkinAnimation : MonoBehaviour
    {
        public string relativePath;
        public string spriteSheetName;
        public Sprite substituteMissingSprite;

        string suffixBeginPattern = "_";

        void LateUpdate()
        {

            var subSprites = Resources.LoadAll<Sprite>(relativePath + "/" + spriteSheetName);

            var spriteImg = GetComponent<Image>();
            {

                //To do :: find sprites based on frame suffix
                string spriteName = spriteImg.sprite.name;
                //var newSprite = Array.Find(subSprites, item => item.name == spriteName);
                var newSprite = Array.Find(subSprites, item => isSuffixMatch(item.name, spriteName, suffixBeginPattern));

                if (newSprite)
                {
                    spriteImg.sprite = newSprite;
                }
                else if (substituteMissingSprite)
                {
                    spriteImg.sprite = substituteMissingSprite;
                }
            }
        }

        bool isSuffixMatch(string stringA, string stringB, string suffixBeginPattern)
        {
            bool result = false;

            int indexA = -1;
            int indexB = -1;

            string suffixA = string.Empty;
            string suffixB = string.Empty;

            indexA = stringA.LastIndexOf(suffixBeginPattern);
            indexB = stringB.LastIndexOf(suffixBeginPattern);

            if (indexA >= 0 && indexB >= 0)
            {
                suffixA = stringA.Substring(indexA, stringA.Length - indexA);
                suffixB = stringB.Substring(indexB, stringB.Length - indexB);

                if (suffixA == suffixB)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}