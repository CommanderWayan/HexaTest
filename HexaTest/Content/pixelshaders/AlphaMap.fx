float4x4 World;
float4x4 View;
float4x4 Projection;

// TODO: add effect parameters here.

float4 PS_COLOR() : COLOR
{
	float4 color = 1.0f;

	color.r = 0.5f;
	color.g = 0.2f;
	color.b = 0.1f;
	color.a = 0.8f;
	
	return color;
}

technique LangweiligerShader
{
   pass pass0
   {
      PixelShader = compile ps_2_0 PS_COLOR();
   }
} 
