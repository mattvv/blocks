using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BlockHelper
{
    private static Direction[] directions =
    {
        Direction.backwards,
        Direction.down,
        Direction.foreward,
        Direction.left,
        Direction.right,
        Direction.up
    };

    public static Vector2[] FaceUVs(Direction direction, BlockType blockType)
    {
        var UVs = new Vector2[4];
        var tailePos = TexturePosition(direction, blockType);

        UVs[0] = new Vector2(
            BlockDataManager.tileSizeX * tailePos.x + BlockDataManager.tileSizeX - BlockDataManager.textureOffset,
            BlockDataManager.tileSizeY * tailePos.y + BlockDataManager.textureOffset);
        
        UVs[1] = new Vector2(
            BlockDataManager.tileSizeX * tailePos.x + BlockDataManager.tileSizeX - BlockDataManager.textureOffset,
            BlockDataManager.tileSizeY * tailePos.y + BlockDataManager.tileSizeY - BlockDataManager.textureOffset);
        
        UVs[2] = new Vector2(
            BlockDataManager.tileSizeX * tailePos.x + BlockDataManager.textureOffset,
            BlockDataManager.tileSizeY * tailePos.y + BlockDataManager.tileSizeY - BlockDataManager.textureOffset);
        
        UVs[3] = new Vector2(
            BlockDataManager.tileSizeX * tailePos.x + BlockDataManager.textureOffset,
            BlockDataManager.tileSizeY * tailePos.y + BlockDataManager.textureOffset);

        return UVs;
    }

    public static Vector2Int TexturePosition(Direction direction, BlockType blockType)
    {
        return direction switch
        {
            Direction.up => BlockDataManager.blockTextureDataDictionary[blockType].up,
            Direction.down => BlockDataManager.blockTextureDataDictionary[blockType].down,
            _ => BlockDataManager.blockTextureDataDictionary[blockType].side
        };
    }
    
    
}
