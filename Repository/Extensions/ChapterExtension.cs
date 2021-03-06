﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.HttpClients;

namespace DomainModel.Extensions
{
    public static class ChapterExtension
    {

        public static void GetDesciption(this Chapter chapter, string key, ref string returnTaricCode, ref string returnTaricLevel, ref string returnTaricDescr)
        {
            int keyLength = key.Length;

            while (key.Length < 10)
            {
                key = key + "0";
            }

            var trCode = "";
            var trLevel = "";
            var trDescr = "";
            if (chapter != null)
            {

                var hsHeading = CheckSubHeading(key, keyLength, 4, chapter, ref trCode, ref trLevel, ref trDescr);
                if (hsHeading == null && chapter.SubChapters.Count > 0)
                {
                    var tariffKey = FindWhichChaptersContainsNumber(key, 4, chapter.SubChapters);
                    hsHeading = CheckSubHeading(key, keyLength, 4,
                        chapter.SubChapters.FirstOrDefault(
                            x => x.TariffKey == tariffKey), ref trCode, ref trLevel, ref trDescr);
                }
                var hsSubHeading = hsHeading != null ? CheckSubHeading(key, keyLength, 6, hsHeading, ref trCode, ref trLevel, ref trDescr) : null;
                if (hsSubHeading == null && hsHeading?.SubChapters.Count > 0)
                {
                    var tariffKey = FindWhichChaptersContainsNumber(key, 6, hsHeading.SubChapters);
                    hsSubHeading = CheckSubHeading(key, keyLength, 6,
                        hsHeading.SubChapters.FirstOrDefault(
                            x => x.TariffKey == tariffKey), ref trCode, ref trLevel, ref trDescr);
                }
                var cnSubHeading = hsSubHeading != null ? CheckSubHeading(key, keyLength, 8, hsSubHeading, ref trCode, ref trLevel, ref trDescr) : null;
                if (cnSubHeading == null && hsSubHeading?.SubChapters.Count > 0)
                {
                    var tariffKey = FindWhichChaptersContainsNumber(key, 8, hsSubHeading.SubChapters);
                    cnSubHeading = CheckSubHeading(key, keyLength, 8,
                        hsSubHeading.SubChapters.FirstOrDefault(
                            x => x.TariffKey == tariffKey), ref trCode, ref trLevel, ref trDescr);
                }
                var internalChapter = cnSubHeading?.SubChapters.FirstOrDefault(x => x.TariffKey.StartsWith(key.Substring(0, 8)));
                var somathing = cnSubHeading != null ? CheckSubHeading(key, keyLength, 10, cnSubHeading, ref trCode, ref trLevel, ref trDescr) : null;
            }

            returnTaricCode = trCode;
            returnTaricLevel = trLevel;
            returnTaricDescr = trDescr.Replace("<br>", "").Replace("</br>", "");
        }

        private static string FindWhichChaptersContainsNumber(string key,int substring, List<Chapter> chapters)
        {
            string[] subchapters = chapters.Select(x => x.TariffKey).ToArray();
            double[] numbers = chapters.Select(x => double.Parse(x.TariffKey.Substring(0,substring))).ToArray();
            var returnNumber = subchapters[0];
            var keyNumber = double.Parse(key.Substring(0, substring));
            for (int index = 1; index < numbers.Length; index++)
            {
                if (keyNumber > numbers[index])
                {
                    returnNumber = subchapters[index];
                }
            }
            return returnNumber;

        }


        private static Chapter CheckSubHeading(string key, int keyLength, int lengthToCHeck, Chapter fatherChapter,
            ref string trCode, ref string trLevel, ref string trDescr)
        {
            Chapter tempChapter;
            if (keyLength < lengthToCHeck) return null;
            if (fatherChapter == null) return null;
            var tempLisr = fatherChapter.SubChapters.Where(x => x.TariffKey.Substring(0, lengthToCHeck).Equals(key.Substring(0, lengthToCHeck)))
                .ToList();
            var tempLisr2 = fatherChapter.SubChapters.Where(x => x.TariffKey.Substring(0, lengthToCHeck - 1).Equals(key.Substring(0, lengthToCHeck - 1)))
                .ToList();

            var tempLisr3 = fatherChapter.SubChapters.Where(x => x.TariffKey.Substring(0, lengthToCHeck - 2).Equals(key.Substring(0, lengthToCHeck - 2)))
                .ToList();
            if (tempLisr.Count > 0)
            {
                tempChapter = tempLisr.FirstOrDefault();
            }
            else if (tempLisr2.Count > 0)
            {
                var lastChapter = tempLisr2.FirstOrDefault();
                var tempList = lastChapter?.SubChapters
                    .Where(x => x.TariffKey.Substring(0, lengthToCHeck).Equals(key.Substring(0, lengthToCHeck))).ToList();
                tempChapter = tempList?.FirstOrDefault();
            }
            else if (tempLisr3.Count > 0)
            {
                var selectedChapter = tempLisr3.FirstOrDefault();
                var tempList = selectedChapter?.SubChapters
                    .Where(x => x.TariffKey.Substring(0, lengthToCHeck).Equals(key.Substring(0, lengthToCHeck))).ToList();
                tempChapter = tempList?.FirstOrDefault();
            }
            else
            {
                var lastChapter = fatherChapter.SubChapters.LastOrDefault();
                var tempList = lastChapter?.SubChapters
                    .Where(x => x.TariffKey.Substring(0, lengthToCHeck).Equals(key.Substring(0, lengthToCHeck))).ToList();
                tempChapter = tempList?.FirstOrDefault();
            }
            if (tempChapter == null) return null;
            trCode = tempChapter.TariffKey;
            trLevel = tempChapter.Level;
            trDescr += tempChapter.Descr;
            return tempChapter;
        }
    }
}
