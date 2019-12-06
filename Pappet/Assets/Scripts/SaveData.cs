using System.Collections.Generic;

namespace SaveData
{
    [System.Serializable]
    public class StickerData
    {
        List<bool[]> stickerData = new List<bool[]>();

        public StickerData(int numSets)
        {
            stickerData.Add(new bool[10]);

            for (int i = 1; i < numSets; i++)
            {
                stickerData.Add(new bool[10]);
                for (int j = 0; j < stickerData[i].Length; j++)
                {
                    stickerData[i][j] = true;
                }
            }
        }

        public void lockSticker(int part, int set)
        {
            stickerData[set][part] = true;
        }

        public void unlockSticker(int set, int part)
        {
            stickerData[set][part] = false;
        }
        public bool isLocked(int part, int set)
        {
            return stickerData[set][part];
        }
    }
}
