float4x4 World;
float4x4 View;
float4x4 Projection;

// TODO: add effect parameters here.
sampler TextureSampler : register(s0);

float4 PS(float4 color : COLOR0, float2 texCoord : TEXCOORD0) : COLOR0
{
    float4 Color = tex2D(TextureSampler, texCoord); 

    Color = float4(0, 0, 0, Color.r);

    return Color;
}

technique Vicky
{
    pass P0
    {
        PixelShader = compile ps_2_0 PS();
    }
}
