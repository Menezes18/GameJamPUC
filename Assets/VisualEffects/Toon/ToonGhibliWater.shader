Shader "Custom/ToonGhibliWaterURP"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (0.0, 0.5, 1.0, 1.0)
        _ShallowColor ("Shallow Color", Color) = (0.0, 0.8, 1.0, 1.0)
        _DeepColor ("Deep Color", Color) = (0.0, 0.2, 0.5, 1.0)
        _WaveSpeed ("Wave Speed", Range(0, 2)) = 0.5
        _WaveScale ("Wave Scale", Range(0, 10)) = 0.1
        _WaveHeight ("Wave Height", Range(0, 1)) = 0.1
        _Transparency ("Transparency", Range(0, 1)) = 0.8
        _SpecularColor ("Specular Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _Shininess ("Shininess", Range(0.01, 1.0)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        Pass
        {
            Tags { "LightMode"="UniversalForward" }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite On

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/SurfaceInput.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 normalWS : NORMAL;
            };

            sampler2D _MainTex;
            float4 _BaseColor;
            float4 _ShallowColor;
            float4 _DeepColor;
            float _WaveSpeed;
            float _WaveScale;
            float _WaveHeight;
            float _Transparency;
            float4 _SpecularColor;
            float _Shininess;

            Varyings vert (Attributes input)
            {
                Varyings output;

                output.positionHCS = TransformObjectToHClip(input.positionOS);
                output.uv = input.uv;
                output.worldPos = TransformObjectToWorld(input.positionOS).xyz;
                output.normalWS = TransformObjectToWorldNormal(input.positionOS);

                return output;
            }

            half4 frag (Varyings input) : SV_Target
            {
                float2 uv = input.uv;
                float3 worldPos = input.worldPos;

                // Sample the texture
                float4 texColor = tex2D(_MainTex, uv) * _BaseColor;

                // Calculate wave animation
                float wave = sin((worldPos.x + _Time.y * _WaveSpeed) * _WaveScale) +
                             cos((worldPos.z + _Time.y * _WaveSpeed) * _WaveScale);
                wave *= 0.1;

                // Toon shading step
                if (wave > 0.05)
                    wave = 0.1;
                else if (wave > -0.05)
                    wave = 0.05;
                else
                    wave = 0.0;

                texColor.rgb += wave;

                // Set alpha transparency
                texColor.a = _Transparency;

                return texColor;
            }
            ENDHLSL
        }
    }
    FallBack "Transparent/Cutout/VertexLit"
}
