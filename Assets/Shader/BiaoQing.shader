Shader "Hidden/BiaoQing"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Less

		Pass
	{
		SetTexture[_MainTex]{
		combine Texture
	}
	}
	}
}