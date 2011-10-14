float4x4 World;
float4x4 View;
float4x4 Projection;

// TODO: add effect parameters here.
sampler firstSampler;
float2 targetSize; 

float4 PS_COLOR(float2 texCoord: TEXCOORD0) : COLOR
{
	float4 color = tex2D(firstSampler, texCoord);
	return color;
}

technique LangweiligerShader
{
   pass pass0
   {
      PixelShader = compile ps_2_0 PS_COLOR();
   }
} 
