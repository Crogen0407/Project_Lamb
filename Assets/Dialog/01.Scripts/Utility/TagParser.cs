using Dialog.Tag;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Dialog
{
    public static class TagParser
    {
        public static List<TextTag> ParseAnimation(ref string txt, List<TextTagSO> textAnimationList)
        {
            TextTag animation;
            List<TextTag> animations = new List<TextTag>();

            if (string.IsNullOrEmpty(txt)) return animations;

            while (true)
            {
                animation = FindTag(txt, textAnimationList);
                if (animation == null) break;

                try
                {
                    //�տ��� ���ڿ��� ª�������� �׸�ŭ �ڿ��� �ٿ������
                    int startTagSize = animation.endIndex - animation.startIndex + 1;
                    txt = txt.Remove(animation.startIndex, startTagSize);

                    for (int i = 0; i < animations.Count; i++)
                    {
                        //�ڿ��� ���� ã�Ƽ� ������ �� ŭ
                        TextTag animInfo = animations[i];
                        animInfo.startIndex -= startTagSize;
                        animInfo.endIndex -= startTagSize;
                        animations[i] = animInfo;
                    }

                    if (animation.calcurateEndIndex)
                    {
                        string tagEndText = $"</{animation.tag}>";
                        int endPos = FindTagEndPos(txt, tagEndText, animation.startIndex);
                        animation.endIndex = endPos;

                        //endPos�� �� ã���� ������
                        if (endPos == -1)
                        {
                            endPos = txt.Length;
                            animation.endIndex = txt.Length;
                        }
                        else
                        {
                            txt = txt.Remove(endPos, tagEndText.Length);

                            for (int i = 0; i < animations.Count; i++)
                            {
                                TextTag animInfo = animations[i];
                                if (animInfo.startIndex >= endPos) animInfo.startIndex -= tagEndText.Length;
                                if (animInfo.endIndex >= endPos) animInfo.endIndex -= tagEndText.Length;
                            }
                        }
                    }
                    else
                    {
                        animation.endIndex = animation.startIndex;
                    }

                    //animationInfo.animSO.SetParameter(animationInfo.param);
                    animations.Add(animation);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            List<ExcludeText> excluding = FindExcludeText(txt);

            animations.ForEach(anim =>
            {
                int lengthMinus = 0;
                int startPosMinus = 0;

                excluding.ForEach(ex =>
                {
                    int tagLength = ex.endPos - ex.startPos + 1;

                    if (anim.startIndex >= ex.endPos)
                    {
                        startPosMinus += tagLength;
                    }

                    if (ex.startPos >= anim.startIndex && ex.endPos <= anim.endIndex)
                    {
                        lengthMinus += tagLength;
                    }
                });

                anim.startIndex -= startPosMinus;
            });

            return animations;
        }

        //�ڿ��� ���� ã��
        private static TextTag FindTag(string txt, List<TextTagSO> textAnimationList)
        {
            for (int i = txt.Length - 1; i >= 0; i--)
            {
                //< ���ڸ� ã�Ƽ�
                if (txt[i] == '<')
                {
                    //������ �±� </ ���� Ȯ�����ְ�
                    if (i + 1 < txt.Length && txt[i + 1] == '/') continue;

                    int endPos = -1;
                    StringBuilder tagSb = new StringBuilder();

                    for (int j = i + 1; j < txt.Length; j++)
                    {
                        if (txt[j] == '>')     //���� ������ �� �� ��ġ ������ְ� enum�� factor�޴°� ����
                        {
                            endPos = j;
                            break;
                        }

                        tagSb.Append(txt[j]);
                    }

                    string tagStr = tagSb.ToString();
                    TextTagSO animSO = textAnimationList.Find(animation => animation.TagID == tagStr);
                    if (animSO != null && endPos > -1)
                    {
                        TextTag animInfo = animSO.textAnimation.Instantiate();
                        animInfo.textGuid = Guid.NewGuid();
                        animInfo.startIndex = i;
                        animInfo.endIndex = endPos;
                        animInfo.tag = tagStr;

                        return animInfo;
                    }
                }
            }

            return null;
        }

        //TMP ���� �±� ó��
        private static List<ExcludeText> FindExcludeText(string txt)
        {
            List<ExcludeText> taglist = new List<ExcludeText>();


            //�ڿ��� ���� ã��
            for (int i = txt.Length - 1; i >= 0; i--)
            {
                if (txt[i] == '<')
                {
                    int endPos = -1;
                    string enumTxt = "";
                    string factor = "";

                    if (i + 1 < txt.Length && txt[i + 1] == '/')
                    {
                        for (int j = i + 2; j < txt.Length; j++)
                        {
                            if (txt[j] == '>')
                            {
                                endPos = j;
                                break;
                            }

                            enumTxt += txt[j];
                        }

                        if (Enum.TryParse(enumTxt, out TMPTag t) && endPos > -1)
                        {
                            ExcludeText tagStruct = new ExcludeText(i, endPos);
                            taglist.Add(tagStruct);
                        }

                        continue;
                    }


                    //enum�� factorã�� �κ�
                    for (int j = i + 1; j < txt.Length; j++)
                    {
                        // = �� ���ڸ� �ޱ� �����Ѵٴ� ��
                        if (txt[j] == '=')
                        {
                            //���ڸ� �޾��ְ� ( =�� ������ �ؾ��� )
                            for (int k = j + 1; k < txt.Length; k++)
                            {
                                //���ڸ� �� ���� ���� �� ��ġ ���
                                if (txt[k] == '>')
                                {
                                    endPos = k;
                                    break;
                                }
                                factor += txt[k];
                            }
                            break;
                        }
                        else if (txt[j] == '>')     //���� ������ �� �� ��ġ ������ְ� enum�� factor�޴°� ����
                        {
                            endPos = j;
                            break;
                        }

                        enumTxt += txt[j];
                    }

                    //���� �ְ�, Enum�� �ִٸ�
                    if (Enum.TryParse(enumTxt, out TMPTag tag) && endPos > -1)
                    {
                        ExcludeText tagStruct = new ExcludeText(i, endPos);
                        taglist.Add(tagStruct);
                    }
                }

            }

            return taglist;
        }

        private static int FindTagEndPos(string txt, string endTxt, int minPos)
        {
            string subTxt = txt.Substring(minPos);
            int pos = subTxt.IndexOf(endTxt);

            if (pos == -1) return pos;
            return minPos + pos;
        }
    }

    public class ExcludeText
    {
        public int startPos, endPos;

        public ExcludeText(int startPos, int endPos)
        {
            this.startPos = startPos;
            this.endPos = endPos;
        }
    }
    public enum TMPTag
    {
        color,
        sup,
        sub,
        mark,
        size,
        b,
        u,
        s,
    }
}
