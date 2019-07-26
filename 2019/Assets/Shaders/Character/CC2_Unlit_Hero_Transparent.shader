Shader "CC2/Unlit_Hero_Transparent" {
Properties 
	{   
	    _Color("Main Color", Color) = (1,1,1,1)
		_MainTex ("Main Texture", 2D) = "white" {}		
		[MaterialToggle] _Alpha ("Translucent state", Float) = 0
		[Header(Frozen Effect)]
		[KeywordEnum(Off,On)]_FrozenEffect("Frozen state",Float) = 0
		_FrozenTex("Ice Texture", 2D) = "white" {}  
        _Cube("Reflection Cubemap", Cube) = "" {} 
	    _ReflectColor("Reflection Color", Color) = (0.77,1,1,1)  
		_Strength("Reflection Strength",Range(0, 1)) = 0.612  
        _BumpMap("Normalmap", 2D) = "bump" {} 
        _Cutoff ("Transparent",range(0,1)) = 0.65
		[Header(Shadow Effect)]
		[KeywordEnum(On,Off)]_ShadowEffect("Shadow state",Float) = 0
		_ShadowOffset("ShadowOffset",vector) = (0.3,-0.58,0,0)
        _ShadowHeight("ShadowHeight",Float) = 0.05
		/*[Header(Outline Effect)]
		[KeywordEnum(On,Off)]_OutlineEffect("Outline state",Float) = 0
		_OutlineFactor("Outline Factor", Range(0, 1)) = 0.5
		_OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
		_OutlineWidth("Outline Width", Range(0, 1)) = 0.05*/
	}
    SubShader {  
	Tags { "RenderType" = "Transparent" "Queue" = "Transparent""IgnoreProjector" = "True" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 200
		Cull Back  ZWrite On
        Pass {  
        CGPROGRAM  
		#pragma exclude_renderers ps3 xbox360 flash
	    #pragma fragmentoption ARB_precision_hint_fastest
        #pragma vertex vert  
        #pragma fragment frag  
	    #pragma multi_compile _FROZENEFFECT_OFF _FROZENEFFECT_ON
        #include "UnityCG.cginc" 
	    sampler2D_half _MainTex;
		fixed4 _Color;
		fixed _Alpha;
		//冰冻效果
        #if _FROZENEFFECT_ON
        sampler2D_half _FrozenTex;
        sampler2D_half _BumpMap;
	    samplerCUBE _Cube;           
        half4 _ReflectColor;  
        half _Strength;
		half _Cutoff;               
        #endif
        struct v2f {  
            float4 pos:SV_POSITION;
			fixed2 uv_Main : TEXCOORD0;
			fixed2 uv_Bump : NORMAL;                
            fixed3 refl : TEXCOORD1; 
        };  
        v2f vert(appdata_full v)  
        {  
            v2f o;  
            o.pos = UnityObjectToClipPos(v.vertex); 
			o.uv_Main = v.texcoord;
		    o.uv_Bump =v.normal; 
			float3 viewDir = mul(unity_ObjectToWorld, v.vertex).xyz - _WorldSpaceCameraPos;  
            float3 normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);  
            o.refl = reflect(viewDir, normalDir); 
			return o;  
        }  
        half4 frag(v2f i):COLOR  
        {  
		    fixed4 col=tex2D( _MainTex,i.uv_Main)*1.15;
            fixed4 c = fixed4(0, 0, 0, 1); 			
            #ifdef _FROZENEFFECT_ON  
			half3 bump = UnpackNormal(tex2D(_BumpMap, i.uv_Bump));  
			half4 col2= tex2D(_FrozenTex, i.uv_Main );
			half reflcol = texCUBE(_Cube, i.refl*(bump*2-1))* _Strength;
			reflcol *= col2.a;  
            col2.rgb = col2.rgb * _Color + reflcol * _ReflectColor.rgb  * 4;                  
		    col2.a = col2.a *_Cutoff;
            c = lerp(col,col2,col2.a);//输出冰冻效果
            #else			
            col=col*_Color;						
            c=fixed4(col.r,col.g,col.b,_Alpha+0.5);//输出正常效果	
            #endif  
            return c;  
        }  
        ENDCG  
        }  
		Pass
        {
            Name "MESHSHADOW"            
            Blend One OneMinusSrcAlpha 
			Cull Back
            ZWrite Off
            //ZTest Always

            Stencil 
            {
                Ref 1  //当参数允许赋值时，会把参考值赋给当前像素
                Comp NotEqual //拿Ref参考值和当前像素缓存上的值进行比较   NotEqual不等于
                Pass Replace//当模版测试和深度测试都通过时，进行处理  参考值替代原有值
            }
            
            CGPROGRAM
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag 
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma multi_compile _SHADOWEFFECT_OFF _SHADOWEFFECT_ON	
            fixed4 _ShadowOffset;
            fixed _ShadowHeight;
            
            struct v2f 
            {
                float4 pos : POSITION;              
            };
            
            v2f vert ( appdata_base v )
            {
                v2f o;
				float4 pos = mul(unity_ObjectToWorld, v.vertex);  
                if (pos.y < _ShadowHeight)  
                    pos.y = _ShadowHeight;   
                pos.xz = pos.xz - ((pos.y - _ShadowHeight) / _ShadowOffset.y) * _ShadowOffset.xz;   
                pos.y = _ShadowHeight;  
                o.pos = mul(UNITY_MATRIX_VP, pos);                       
                return o; 
            }
            
            fixed4 frag(v2f i) :COLOR 
            { 
			    #ifdef _SHADOWEFFECT_ON  
                return fixed4(0,0,0,0.3);
				#else				
				discard; // 丢弃片段
				return fixed4(0,0,0,0);
				#endif  
            } 
			ENDCG  
        }
		// 描边 
		/*Pass
		{   
		    Name "OUTLINE"     
			Cull Front
			offset 1,1
			CGPROGRAM
			#pragma fragmentoption ARB_precision_hint_fastest
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _OUTLINEEFFECT_OFF _OUTLINEEFFECT_ON	
			#include "UnityCG.cginc"
			struct vertexOutput 
            {
	        float4 pos : SV_POSITION;        
            };		     
			fixed _OutlineFactor;
			fixed4 _OutlineColor;
			fixed _OutlineWidth;			
			vertexOutput vert(appdata_base v) 
			{
			    vertexOutput o;
				o.pos = UnityObjectToClipPos(v.vertex);		
				float3 dir = normalize ( v.vertex.xyz );
		        float3 dir2 = v.normal;		
		               dir = lerp ( dir, dir2, _OutlineFactor );
		               dir = mul ( ( float3x3 ) UNITY_MATRIX_IT_MV, dir );
		        float2 offset = TransformViewToProjection ( dir.xy );
		               offset = normalize ( offset );
		        float dist = distance ( mul ( UNITY_MATRIX_M, v.vertex ), _WorldSpaceCameraPos );
				o.pos.xy += offset * o.pos.z*_OutlineWidth  / dist;
				return o;

			}


			fixed4 frag() : Color
			{    
			    #ifdef _OUTLINEEFFECT_ON  
				return _OutlineColor;
				#else				
				discard; // 丢弃片段
				return fixed4(0,0,0,1);
				#endif  
				
			}

			ENDCG
		}*/
    }   
    FallBack "Diffuse"  
}  