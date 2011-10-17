float4x4 World;
float4x4 View;
float4x4 Projection;

float Strength;

texture Texture0;
sampler2D sampler0 = sampler_state
{
   Texture = (Texture0);
   MIPFILTER = LINEAR;
   MAGFILTER = LINEAR;
   MINFILTER = LINEAR;
};

sampler sampler1 : register(s1); 

float4 PS_COLOR(float2 texCoord: TEXCOORD0) : COLOR
{
	float4 color0 = tex2D(sampler0, texCoord);
	float4 mask = tex2D(sampler1, texCoord);

	color0.a -= mask.r;

	return color0;
}

technique AlphaBlend
{
   pass pass0
   {
      PixelShader = compile ps_2_0 PS_COLOR();
   }
} 
