#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

//PARAMS
float param1;
texture customTexture;
//

texture baseTexture;

sampler Sampler0 : register(s0)
{
    Texture = (baseTexture);
};
sampler Sampler1  : register(s1)
{
    Texture = (customTexture);
};

float4 TextureMask(float4 position : SV_Position, float4 color : COLOR0, float2 coords : TEXCOORD0) : COLOR0
{
  color = tex2D(Sampler0, coords);
  float4 customTexture_color = tex2D(Sampler1 , coords);
 
  color.rgb += customTexture_color.rgb * param1;

  return color;
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 TextureMask();
    }
}


float4 PixelShaderFunction(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);
    return color;
}

float4 CutOut(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);

    float threshold = param1;

    if (coords.y > threshold)
        color = float4(0, 0, 0, 0);
    
    return color;
}

float4 Gradient(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);

    if (color.a)
        color.rgb = coords.y;

    return color;
}

float4 Flip(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, float2(1 - coords.x, coords.y));
    return color;
}

float4 Rotate(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, 1 - coords);
    return color;
}

float4 Strip(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);

    if (!any(color)) return color;

    float step = param1 / 7;

    if (coords.x < (step * 1)) color = float4(1, 0, 0, 1);
    else if (coords.x < (step * 2)) color = float4(1, .5, 0, 1);
    else if (coords.x < (step * 3)) color = float4(1, 1, 0, 1);
    else if (coords.x < (step * 4)) color = float4(0, 1, 0, 1);
    else if (coords.x < (step * 5)) color = float4(0, 0, 1, 1);
    else if (coords.x < (step * 6)) color = float4(.3, 0, .8, 1);
    else                            color = float4(1, .8, 1, 1);

    return color;
}

float4 CustomTint(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);
    float4 tint = float4(param1, 0, 0, 1);

    color.rgb += color.rgb * tint.rgb;

    return color;
}

float4 HighContrast(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);

    //color.gb = color.r;

    float high = .6;
    float low = .4;

    if (color.r > high) color.r = 1;
    else if (color.r < low) color.r = 0;

    if (color.g > high) color.g = 1;
    else if (color.g < low) color.g = 0;

    if (color.b > high) color.b = 1;
    else if (color.b < low) color.b = 0;

    return color;
}

float4 Negative(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);
    color.rgb = 1 - color.rgb;

    return color;
}

float4 BlackAndWhite(float2 coords: TEXCOORD0) : COLOR0
{
    float4 color = tex2D(Sampler0, coords);
    color.gb = color.r;

    return color;
}
