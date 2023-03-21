using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for(int i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;

            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if(scale <= 0)
        {
            scale = 0.0001f;
        }

        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;

        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for(int y = 0; y < mapHeight; y++)
        {
            for(int x = 0; x < mapWidth; x++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = (x - halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y - halfHeight) / scale * frequency + octaveOffsets[i].y;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if (noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if (noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x, y] = noiseHeight;
            }
        }

        int tempWidth = mapWidth;

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < tempWidth/2; x++)
            {
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);

                //Debug.Log("(" + (mapWidth - x) + "," + y + ")");
                noiseMap[mapWidth - x - 1, y] = noiseMap[x, y];

                //if (x == 0 & y == 0)
                //{
                //    noiseMap[mapWidth - 1, mapHeight - 1] = noiseMap[x, y];
                //    continue;
                //}

                //int reflectX = x - (mapWidth / 2);
                //int reflectY = y - (mapHeight / 2);
                //if (reflectX == 0)
                //{
                //    reflectX = mapWidth - 1;
                //}
                //if (reflectY == 0)
                //{
                //    reflectY = mapHeight - 1;
                //}

                //if(reflectX == mapWidth -1)
                //{
                //    reflectX = 0;
                //}
                //if(reflectY == mapHeight-1)
                //{
                //    reflectY = 0;
                //}

                //reflectX *= -1;
                //reflectY *= -1;

                //Debug.Log("(" + x + "," + y + ")");
                //Debug.Log("(" + reflectX + "," + reflectY + ")");

                //noiseMap[reflectX, reflectY] = noiseMap[x, y];

            }
            //tempWidth--;
        }

        return noiseMap;
    }
}
