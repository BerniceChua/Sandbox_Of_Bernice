Shader "uSE/Glass" { 
	Properties { 
		_Cutoff_ ("Cutoff", Range(0,1)) = 0
		[Header (Textures and Bumpmaps)]_Refractionmap("Refraction map", 2D) = "white" {}
		_Specular("Specular", 2D) = "white" {}
		[Header (Variables)]_RefractionPower("RefractionPower", float) = 0.28
		_Brightness("Brightness", float) = 0.15
		_NormalMaping("NormalMaping", float) = -0.3
		_Occlusion("Occlusion", float) = 1
		_Smoothness("Smoothness", float) = 1
		_SpecularPower("SpecularPower", float) = 1
	}
	SubShader {
		LOD 300
		Tags {
			"Queue" = "Transparent"
			"RenderType" = "Opaque"
		}

		GrabPass {
			Name "BASE"
			Tags { "LightMode" = "Always" }
		}
		Cull Off
		ColorMask   RGBA

		CGPROGRAM 
		#pragma surface surf StandardSpecular vertex:vert 
		#pragma target 4.0
		#include "UnityCG.cginc"

		float _Cutoff_;
		sampler2D _Refractionmap;
		sampler2D _Specular;
		float _RefractionPower;
		float _Brightness;
		float _NormalMaping;
		float _Occlusion;
		float _Smoothness;
		float _SpecularPower;
		sampler2D _GrabTexture : register(s0);
		uniform half4 _GrabTexture_TexelSize;

		struct appdata{
			float4 vertex    : POSITION;  // The vertex position in model space.
			float3 normal    : NORMAL;    // The vertex normal in model space.
			float4 texcoord  : TEXCOORD0; // The first UV coordinate.
			float4 texcoord1 : TEXCOORD1; // The second UV coordinate.
			float4 texcoord2 : TEXCOORD2; // The third UV coordinate.
			float4 tangent   : TANGENT;   // The tangent vector in Model Space (used for normal mapping).
			float4 color     : COLOR;     // Per-vertex color.
		};

		struct Input{
			float2 uv_Refractionmap;
			float2 uv_Specular;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;
			float4 proj1;
			float4 position : POSITION;

			INTERNAL_DATA
		};

		void vert (inout appdata v, out Input data){
			UNITY_INITIALIZE_OUTPUT(Input,data);
			data.position = mul(UNITY_MATRIX_MVP, v.vertex);
			data.proj1 = ComputeScreenPos(data.position);
			COMPUTE_EYEDEPTH(data.proj1.z);
			#if UNITY_UV_STARTS_AT_TOP
				data.proj1.y = (data.position.w - data.position.y) * 0.5;
			#endif
		}

		void surf (Input IN, inout SurfaceOutputStandardSpecular o) {
			o.Smoothness = normalize(tex2D(_Refractionmap, IN.uv_Refractionmap).rgb) * _Smoothness;
			o.Specular = tex2D(_Specular, IN.uv_Refractionmap).rgb * _SpecularPower;
			o.Occlusion = _Occlusion * normalize(tex2D(_Refractionmap, IN.uv_Refractionmap).rgb);
			o.Albedo = tex2Dproj(_GrabTexture, IN.proj1 + abs(UnpackNormal(tex2D(_Refractionmap, IN.uv_Refractionmap)).r * UnpackNormal(tex2D(_Refractionmap, IN.uv_Refractionmap)).g * UnpackNormal(tex2D(_Refractionmap, IN.uv_Refractionmap)).b * _RefractionPower - _RefractionPower / 16 ) - _RefractionPower / 8 + _RefractionPower / 15) + _Brightness;
			o.Normal = UnpackNormal(tex2D(_Specular, IN.uv_Refractionmap)) * _NormalMaping;
			if(o.Alpha < _Cutoff_) discard;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
