using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Chunk
{
    public static void LoopThroughTheBlocks(ChunkData chunkData, Action<int, int, int> actionToPerform)
    {
        for (var index = 0; index < chunkData.blocks.Length; index++)
        {
            var position = GetPositionFromIndex(chunkData, index);
            actionToPerform(position.x, position.y, position.z);

        }
    }

    private static Vector3Int GetPositionFromIndex(ChunkData chunkData, int index)
    {
        //convert 1d array index to 3d array index
        var x = index % chunkData.chunkSize;
        var y = (index / chunkData.chunkSize) % chunkData.chunkHeight;
        var z = index / (chunkData.chunkSize * chunkData.chunkHeight);

        return new Vector3Int(x, y, z);
    }

    private static int GetIndexFromPosition(ChunkData chunkData, int x, int y, int z)
    {
        //convert 3d array index to 1d array index
        return x + chunkData.chunkSize * y + chunkData.chunkSize * chunkData.chunkHeight * z;
    }

    private static bool InRange(ChunkData chunkData, int axisCoordinate)
    {
        return axisCoordinate >= 0 && axisCoordinate < chunkData.chunkSize;
    }

    private static bool InRangeHeight(ChunkData chunkData, int yCoordinate)
    {
        return yCoordinate >= 0 && yCoordinate < chunkData.chunkHeight;
    }

    public static BlockType GetBlockFromChunkCoordinates(ChunkData chunkData, int x, int y, int z)
    {
        if (InRange(chunkData, z) && InRangeHeight(chunkData, y) && InRange(chunkData, z))
        {
            var index = GetIndexFromPosition(chunkData, x, y, z);
            return chunkData.blocks[index];
        }

        throw new Exception("Need to ask World for appropriate Chunk");
    }

    public static void SetBlock(ChunkData chunkData, Vector3Int localPosition, BlockType block)
    {
        if (InRange(chunkData, localPosition.x) && InRangeHeight(chunkData, localPosition.y) &&
            InRange(chunkData, localPosition.z))
        {
            var index = GetIndexFromPosition(chunkData, localPosition.x, localPosition.y, localPosition.z);
            chunkData.blocks[index] = block;
        }
        else
        {
            throw new Exception("Need to ask World for appropriate Chunk");
        }
    }

    public static Vector3Int GetBlockInChunkCoordinates(ChunkData chunkData, Vector3Int pos)
    {
        return new Vector3Int
        {
            x = pos.x - chunkData.worldPosition.x,
            y = pos.y - chunkData.worldPosition.y,
            z = pos.z - chunkData.worldPosition.z
        };
    }
    
    internal static MeshData GetChunkMeshData(ChunkData chunkData)
    {
        var meshData = new MeshData(true);

        //todo: fill later;
        
        return meshData;
    }
}