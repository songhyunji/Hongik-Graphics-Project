Shader "Custom/Water2"
{
	Properties{
		_BumpMap("NormalMap", 2D) = "bump" {}
		_Cube("Cubemap", Cube) = "" {}
	}
	SubShader{
		Tags {"RengerType" = "Transparent" "Queue" = "Transparent"}

		CGPROGRAM
		#pragma surface surf Lambert alpha:fade vertex:vert

		samplerCUBE _Cube;
		sampler2D _BumpMap;
	
		struct Input {
			float2 uv_BumpMap;
			float3 worldRefl;
			float3 viewDir;
			INTERNAL_DATA
		};
		
		void surf(Input IN, inout SurfaceOutput o) {
			float3 normal1 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap + _Time.x * 0.05));
			float3 normal2 = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap - _Time.x * 0.05));
			o.Normal = (normal1 + normal2) / 2;
			float3 refcolor = texCUBE(_Cube, WorldReflectionVector(IN, o.Normal));

			//rim term
			float rim = saturate(dot(o.Normal, IN.viewDir));
			rim = pow(1 - rim, 1.5);

			o.Albedo = refcolor * rim * 2;
			o.Alpha = saturate(rim + 0.5);
		}

		void vert(inout appdata_full v) {
			v.vertex.y += sin(abs((v.texcoord.y * 2 - 1) * 12) + _Time.y) * 3;
		}

		ENDCG
	}
	FallBack "Legacy Shaders/Transparent/Vertexlit"
}
