using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;


//using UnityEngine;
//using UnityEditor;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

/* Class: FontImporter
*
* Imports .fnt files generated by AngelCode's bitmap font generator http://www.angelcode.com/products/bmfont/
*
* Make sure:
* - only XML-style .fnt files can currently be loaded
* - the font outline should be placed in the R-channel of either
* a png or a tga file.
*
* For best results I reccomend
* - disable anti aliasing (it confuses the distance field calculator a bit)
* - use font size of 256px (with DistanceFieldScaleFactor = 8 that means ~32px chars)
* - use padding of at least 16px (to allow some blurring of the distance field
* without smearing between characters). Increase this if you want a large dropshadowc
* or outline
*
* See the included arial.bmfc for an example
*/
public class FontImporter
{
    //TODO: Expose parameters to user at import time

    /* Constant: DistanceFieldScaleFactor
*
* The scale factor between the generated distance field and the original
* outline texture. DistanceField.size = Outline.size / DistanceFieldScaleFactor
*/
    //static int DistanceFieldScaleFactor = 8;

    /* Constant: InputTextureChannel
*
* Which channel from the original outline texture to use when generating the distance
* field
*/
//    static DistanceField.TextureChannel InputTextureChannel = DistanceField.TextureChannel.RED;

[MenuItem("Assets/BitmapFont/Import Font", validate = true)]
    static bool Validate()
    {
        foreach (Object o in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
        {
            string path = AssetDatabase.GetAssetPath(o.GetInstanceID());
            if (path.ToLower().EndsWith(".fnt"))
            {
						
                return true;
            }
        }

        return false;
    }


[MenuItem("Assets/BitmapFont/Import Font")]
    static void Import()
    {
        foreach (Object o in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
        {
			Debug.Log("lol");
            //Look for assets with the .fnt extension
            string path = AssetDatabase.GetAssetPath(o.GetInstanceID());
		
            if (path.ToLower().EndsWith(".fnt"))
            {
                //Find prefab for storing bitmap font
                string basePath = path.Substring(0, path.LastIndexOf("."));
                string prefabPath = basePath + "_font";
                Object prefab = AssetDatabase.LoadAssetAtPath(prefabPath + ".prefab", typeof(GameObject));
                if (prefab == null)
                {
                    prefab = PrefabUtility.CreateEmptyPrefab(prefabPath + ".prefab");
                }

                //Create prefab if it doesnt exist
                GameObject obj = null;
                if (prefab as GameObject != null)
                {
                    obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
                }
                else
                {
                    obj = new GameObject();
                }
                obj.name = prefabPath.Substring(prefabPath.LastIndexOf("/") + 1);

                //Make sure there's a BitmapFont component on it
                BitmapFont fnt = obj.GetComponent<BitmapFont>();
                if (fnt == null)
                {
					Debug.LogError("No FNT");
                    fnt = obj.AddComponent<BitmapFont>();
                }
				Debug.LogError(path + "  " + obj.GetComponent<BitmapFont>());
                //Read BitmapFont info from .fnt file
                UpdateBitmapFont(path, obj.GetComponent<BitmapFont>());

                PrefabUtility.ReplacePrefab(obj, prefab);
                GameObject.DestroyImmediate(obj);
            }
        }
    }

    /* .fnt parser taken from
*
*/
    static BitmapFont UpdateBitmapFont(string path, BitmapFont fnt)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);

        //Read font info
        XmlNode info = doc.SelectSingleNode("/font/info");
        fnt.Size = ReadFloatAttribute(info, "size");

        XmlNode common = doc.SelectSingleNode("/font/common");
        fnt.LineHeight = ReadFloatAttribute(common, "lineHeight");
        fnt.Base = ReadFloatAttribute(common, "base");
        fnt.ScaleH = ReadFloatAttribute(common, "scaleW");
        fnt.ScaleW = ReadFloatAttribute(common, "scaleH");

        //Read character info
        XmlNodeList chars = doc.SelectNodes("/font/chars/char");
        fnt.Chars = new BitmapChar[chars.Count];
        int index = 0;
        foreach (XmlNode char_node in chars)
        {
            fnt.Chars[index] = new BitmapChar();
            fnt.Chars[index].Id = ReadIntAttribute(char_node, "id");
            fnt.Chars[index].Position = ReadVector2Attributes(char_node, "x", "y");
            fnt.Chars[index].Size = ReadVector2Attributes(char_node, "width", "height");
            fnt.Chars[index].Offset = ReadVector2Attributes(char_node, "xoffset", "yoffset");
            fnt.Chars[index].XAdvance = ReadFloatAttribute(char_node, "xadvance");
            fnt.Chars[index].Page = ReadIntAttribute(char_node, "page"); 
            index++;
        }

        //Load texture pages and convert to distance fields
        XmlNodeList pages = doc.SelectNodes("/font/pages/page");
        Texture2D[] texturePages = new Texture2D[pages.Count];
        index = 0;
        foreach (XmlNode page in pages)
        {
            //Find original font texture
            string imagePath = System.IO.Path.GetDirectoryName(path) + "/" + page.Attributes["file"].Value;
			
            Texture2D inputTexture = (Texture2D)AssetDatabase.LoadAssetAtPath(imagePath, typeof(Texture2D));
			
            //Make sure font texture is readable
            TextureImporter inputTextureImp = (TextureImporter)TextureImporter.GetAtPath(imagePath);
            inputTextureImp.textureType = TextureImporterType.Advanced;
            inputTextureImp.isReadable = true;
            inputTextureImp.maxTextureSize = 4096;
            AssetDatabase.ImportAsset(imagePath, ImportAssetOptions.ForceSynchronousImport);
			
            //Create distance field from texture
            //Texture2D distanceField = DistanceField.CreateDistanceFieldTexture(inputTexture, InputTextureChannel, inputTexture.width / DistanceFieldScaleFactor);
           	//texturePages[index] = distanceField;
			texturePages[index] = inputTexture;

            index++;
        }

        //Create texture atlas
        Texture2D pageAtlas = new Texture2D(0, 0);
        fnt.PageOffsets = pageAtlas.PackTextures(texturePages, 0);

        //Save atlas as png
        byte[] pngData = pageAtlas.EncodeToPNG();
        string outputPath = path.Substring(0, path.LastIndexOf('.')) + "_dist.png";
		Debug.Log("Path: " + outputPath);
        System.IO.File.WriteAllBytes(outputPath, pngData);
        AssetDatabase.ImportAsset(outputPath, ImportAssetOptions.ForceSynchronousImport);

        //Set correct texture format
        /*TextureImporter texImp = (TextureImporter)TextureImporter.GetAtPath(outputPath);
        texImp.textureType = TextureImporterType.Advanced;
        texImp.isReadable = true;
        texImp.textureFormat = TextureImporterFormat.Alpha8;
        AssetDatabase.ImportAsset(outputPath, ImportAssetOptions.ForceSynchronousImport);*/

        //Load the saved texture atlas
        fnt.PageAtlas = (Texture2D)AssetDatabase.LoadAssetAtPath(outputPath, typeof(Texture2D));

        //Load kerning info
        XmlNodeList kernings = doc.SelectNodes("/font/kernings/kerning");
        fnt.Kernings = new BitmapCharKerning[kernings.Count];
        index = 0;
        foreach (XmlNode kerning in kernings)
        {
            BitmapCharKerning krn = new BitmapCharKerning();
            krn.FirstChar = ReadIntAttribute(kerning, "first");
            krn.SecondChar = ReadIntAttribute(kerning, "second");
            krn.Amount = ReadFloatAttribute(kerning, "amount");
            fnt.Kernings[index] = krn;
            index++;
        }

        return fnt;
    }

    static int ReadIntAttribute(XmlNode node, string attribute)
    {
        return int.Parse(node.Attributes[attribute].Value, System.Globalization.NumberFormatInfo.InvariantInfo);
    }
    static float ReadFloatAttribute(XmlNode node, string attribute)
    {
        return float.Parse(node.Attributes[attribute].Value, System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    static Vector2 ReadVector2Attributes(XmlNode node, string attributeX, string attributeY)
    {
        return new Vector2(ReadFloatAttribute(node, attributeX), ReadFloatAttribute(node, attributeY));
    }



	
// Add menu named "Do Something" to the main menu
[MenuItem ("FontImporter/Import BMFont")]
static void ImportBMFont() {
		
		GameObject _gameObject = Selection.gameObjects[0];
		
		
		Component[] _components = _gameObject.GetComponents(typeof(Component));
		
		foreach(Component _component in _components){
			Debug.Log("_component: " + _component.GetType());
		}
}	
	
	
[MenuItem ("FontImporter/Import BMFont", true)]
static bool ValidateImportBMFont() {
		
		
		if (Selection.gameObjects.Length != 1) return false;
		
		return true;
}	
	
	
	
	
	

// Add menu named "Do Something" to the main menu
[MenuItem ("FontImporter/Save Font Texture")]
static void SaveFontTexture () {
		
		GameObject _gameObject = Selection.activeGameObject;
		
		TextMesh _textMesh = _gameObject.GetComponent<TextMesh>();
		
		
		Texture2D fontTex = (Texture2D)_textMesh.font.material.mainTexture;
		
		Color[] pixels = fontTex.GetPixels();
		
		
		Texture2D tex = new Texture2D (fontTex.width, fontTex.height, TextureFormat.ARGB32, false);
		
		tex.SetPixels(pixels);
		
		
			byte[] pngData = tex.EncodeToPNG(); 
			if(pngData != null){	
    			File.WriteAllBytes("Assets/Fonts/FontTexture.png", pngData);					
			}		
		
}	
	
	
[MenuItem ("FontImporter/Save Font Texture", true)]
static bool ValidateSaveFontTexture () {
		
	//GameObject[] gameObjects = Selection.gameObjects;
		
		if (Selection.activeObject == null) return false;
		
		GameObject _gameObject = Selection.activeGameObject;
		
		//if (gameObjects.Length == 1) return false;
		if (_gameObject == null) return false;
		
		if (_gameObject.GetComponent<TextMesh>() == null) return false;
		
		//if (_gameObject.renderer == null) return false;
		
		//if (_gameObject.renderer.sharedMaterial = null) return false;
		
		//if (_gameObject.renderer.sharedMaterial.mainTexture = null) return false;
		
		return true;
}
	
}