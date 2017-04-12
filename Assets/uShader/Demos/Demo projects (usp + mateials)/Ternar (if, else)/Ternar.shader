Shader "uSE/Ternar" { 
	Properties { 
		[Header (Textures and Bumpmaps)]_Texture("Texture", 2D) = "white" {}
		[Header (Variables)]_Separator("Separator", float) = 0.5
	}
	SubShader {
		LOD 300
		Tags {
			"Queue" = "Geometry"
			"RenderType" = "Opaque"
		}

		Fog {
			Mode Global
			Density 0
			Color (1, 1, 1, 1) 
			Range 0, 300
		}

		Stencil {
			Ref 0
			Comp Always
			Pass Keep
			Fail Keep
			ZFail Keep
		}

		Cull Off
		ZWrite  On
		ColorMask   RGBA

		CGPROGRAM 
		#pragma surface surf Standard 
		#include "UnityCG.cginc"

		sampler2D _Texture;
		float _Separator;
		float3 _p0_pi0_nc0_o4;
		float4 _p0_pi0_nc9_o0;
		float3 _p0_pi0_nc9_o1;
		float _p0_pi0_nc9_o2;
		float4 _p0_pi0_nc10_o0;
		float3 _p0_pi0_nc10_o1;
		float _p0_pi0_nc10_o2;
		float4 _p0_pi0_nc11_o3;
		float3 _p0_pi0_nc11_o4;
		float _p0_pi0_nc11_o5;
		float3 _p0_pi0_nc11_o6;
		float _p0_pi0_nc13_o1;
		float _p0_pi0_nc13_o2;
		float _p0_pi0_nc13_o3;
		float _p0_pi0_nc14_o0;
		float _p0_pi0_nc17_o0;

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
			float2 uv_Texture;
			float3 viewDir;
			float3 worldPos;
			float3 worldRefl;
			float3 worldNormal;
			float4 screenPos;
			float4 color : COLOR;

			INTERNAL_DATA
		};

		void surf (Input IN, inout SurfaceOutputStandard o) {
			_p0_pi0_nc9_o1 = float4(0.07839534, 0.1881115, 0.3676471, 1).rgb;
			_p0_pi0_nc9_o0 = float4(0.07839534, 0.1881115, 0.3676471, 1);
			_p0_pi0_nc10_o1 = float4(0.875, 0.7720588, 0.8295639, 1).rgb;
			_p0_pi0_nc9_o2 = float4(0.07839534, 0.1881115, 0.3676471, 1).a;
			_p0_pi0_nc10_o0 = float4(0.875, 0.7720588, 0.8295639, 1);
			_p0_pi0_nc11_o4 = tex2D(_Texture, IN.uv_Texture).rgb;
			_p0_pi0_nc10_o2 = float4(0.875, 0.7720588, 0.8295639, 1).a;
			_p0_pi0_nc11_o3 = tex2D(_Texture, IN.uv_Texture);
			_p0_pi0_nc13_o2 = (_p0_pi0_nc11_o4).y;
			_p0_pi0_nc11_o5 = tex2D(_Texture, IN.uv_Texture).a;
			_p0_pi0_nc11_o6 = UnpackNormal(tex2D(_Texture, IN.uv_Texture));
			_p0_pi0_nc13_o1 = (_p0_pi0_nc11_o4).x;
			_p0_pi0_nc14_o0 = _Separator;
			_p0_pi0_nc13_o3 = (_p0_pi0_nc11_o4).z;
			_p0_pi0_nc0_o4 = (_p0_pi0_nc13_o2) >= (_p0_pi0_nc14_o0) ? (_p0_pi0_nc9_o1) : (_p0_pi0_nc10_o1);
			_p0_pi0_nc17_o0 = 0.5;
			o.Albedo = _p0_pi0_nc0_o4;
			o.Metallic = _p0_pi0_nc17_o0;
			o.Smoothness = _p0_pi0_nc17_o0;
		}
		ENDCG

	}
	FallBack "Diffuse"
}
