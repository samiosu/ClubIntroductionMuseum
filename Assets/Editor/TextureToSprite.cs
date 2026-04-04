using UnityEngine;
using UnityEditor;

public class TextureToSprite : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        if(assetPath.Contains("Assets/Images"))
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Single;
        }
    }
}