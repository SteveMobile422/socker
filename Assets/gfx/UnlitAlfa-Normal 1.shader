// Unlit shader. Simplest possible textured shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "Unlit/TextureAlfaCull" {
Properties {
	_MainTex ("Base (RGB)", 2D) = "white" {}
}

SubShader {
	Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	Blend SrcAlpha OneMinusSrcAlpha
	LOD 100
	
	Pass {
		Lighting Off
		Cull front
		SetTexture [_MainTex] { combine texture } 
	}
		Pass {
		Lighting Off
		cull back
		SetTexture [_MainTex] { combine texture } 
	}
}
}
