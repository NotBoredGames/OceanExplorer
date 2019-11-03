// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unluck Software/ZippyLight2D Desktop (1xLight)" {
	Properties {
		_MainTex("Texture", 2D) = "white" {}
			
		_LightColor("Light Color", Color) = (1, 1, 1, 1)
		_Contrast("Light Contrast", Float) = 1.0
	}
	
	SubShader {
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		
		Pass {
			Name "LIGHT"
			ZWrite On
			// ColorMask 0
			Blend DstColor One	
			
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			uniform sampler2D _MainTex;
			uniform float4 _LightColor;
			uniform float _Contrast;

			struct VertexInput {
				float4 vertex: POSITION;
				float4 uv: TEXCOORD0;
				float4 color: COLOR;
			};

			struct VertexOutput {
				float4 pos: SV_POSITION;
				float2 uv: TEXCOORD0;
				float4 color: COLOR;
			};

			VertexOutput vert(VertexInput input) {
				VertexOutput output;
				output.pos = UnityObjectToClipPos(input.vertex);
				output.uv = input.uv;
				output.color = input.color;
				return output;
			}

			float4 frag(VertexOutput input): COLOR {
				float4 c = tex2D(_MainTex, input.uv);
				c.rgb = c.rgb  * input.color.rgb * _LightColor.rgb;
				c.rgb *= c.a  * input.color.a * _LightColor.a;
				c *= _Contrast;
				return float4(c);
			}
			ENDCG
		}
	}
}