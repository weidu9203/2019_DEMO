// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33982,y:32680,varname:node_9361,prsc:2|emission-5852-OUT,alpha-678-OUT;n:type:ShaderForge.SFN_Tex2d,id:3990,x:32498,y:32540,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_3990,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Color,id:5084,x:32378,y:32946,ptovrint:False,ptlb:TintColor,ptin:_TintColor,varname:node_5084,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5058316,c2:0.1294334,c3:0.8382353,c4:1;n:type:ShaderForge.SFN_Multiply,id:5583,x:32945,y:32677,varname:node_5583,prsc:2|A-3990-RGB,B-9574-RGB;n:type:ShaderForge.SFN_Multiply,id:3068,x:32945,y:32890,varname:node_3068,prsc:2|A-3990-RGB,B-5084-RGB,C-2781-RGB;n:type:ShaderForge.SFN_Color,id:9574,x:32498,y:32738,ptovrint:False,ptlb:Edge_Color,ptin:_Edge_Color,varname:node_9574,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Tex2d,id:4099,x:32428,y:33150,ptovrint:False,ptlb:Mask_1,ptin:_Mask_1,varname:node_4099,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:678,x:33191,y:33136,varname:node_678,prsc:2|A-3990-A,B-9574-A,C-4099-R,D-5036-OUT;n:type:ShaderForge.SFN_Lerp,id:2491,x:33338,y:32768,varname:node_2491,prsc:2|A-5583-OUT,B-3068-OUT,T-6777-OUT;n:type:ShaderForge.SFN_Smoothstep,id:5036,x:32862,y:33479,varname:node_5036,prsc:2|A-6220-OUT,B-1635-OUT,V-1077-OUT;n:type:ShaderForge.SFN_Slider,id:1635,x:31982,y:33590,ptovrint:False,ptlb:Ruanying,ptin:_Ruanying,varname:node_1635,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0.5,cur:0.598817,max:1;n:type:ShaderForge.SFN_OneMinus,id:6220,x:32476,y:33381,varname:node_6220,prsc:2|IN-1635-OUT;n:type:ShaderForge.SFN_Smoothstep,id:6777,x:32888,y:33655,varname:node_6777,prsc:2|A-6220-OUT,B-1635-OUT,V-7076-OUT;n:type:ShaderForge.SFN_Tex2d,id:2887,x:31823,y:33865,ptovrint:False,ptlb:Rongjie_Tex,ptin:_Rongjie_Tex,varname:node_2887,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:5627,x:32081,y:33890,varname:node_5627,prsc:2|A-2887-R,B-6595-OUT;n:type:ShaderForge.SFN_Vector1,id:6595,x:31878,y:34039,varname:node_6595,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:8376,x:32370,y:33876,varname:node_8376,prsc:2|A-5627-OUT,B-4429-OUT;n:type:ShaderForge.SFN_Add,id:4887,x:32370,y:34048,varname:node_4887,prsc:2|A-5627-OUT,B-9107-OUT;n:type:ShaderForge.SFN_Clamp01,id:1077,x:32576,y:33864,varname:node_1077,prsc:2|IN-8376-OUT;n:type:ShaderForge.SFN_Clamp01,id:7076,x:32576,y:34066,varname:node_7076,prsc:2|IN-4887-OUT;n:type:ShaderForge.SFN_Slider,id:9024,x:30886,y:34192,ptovrint:False,ptlb:Edge_Width,ptin:_Edge_Width,varname:_Ruanying_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:-1;n:type:ShaderForge.SFN_Add,id:6465,x:31490,y:34190,varname:node_6465,prsc:2|A-9024-OUT,B-1195-OUT;n:type:ShaderForge.SFN_VertexColor,id:2781,x:30484,y:34501,varname:node_2781,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:2844,x:30897,y:34698,varname:node_2844,prsc:2|IN-2781-A;n:type:ShaderForge.SFN_Multiply,id:4260,x:31116,y:34677,varname:node_4260,prsc:2|A-3097-OUT,B-2844-OUT;n:type:ShaderForge.SFN_Vector1,id:3097,x:30897,y:34609,varname:node_3097,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:1195,x:31446,y:34675,varname:node_1195,prsc:2|A-4260-OUT,B-1338-OUT;n:type:ShaderForge.SFN_Slider,id:1338,x:30919,y:34985,ptovrint:False,ptlb:Rongjie,ptin:_Rongjie,varname:node_1338,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2796224,max:2;n:type:ShaderForge.SFN_Clamp01,id:3817,x:31761,y:34199,varname:node_3817,prsc:2|IN-6465-OUT;n:type:ShaderForge.SFN_Multiply,id:4429,x:32052,y:34206,varname:node_4429,prsc:2|A-3817-OUT,B-5368-OUT;n:type:ShaderForge.SFN_Multiply,id:9107,x:32045,y:34638,varname:node_9107,prsc:2|A-1195-OUT,B-5368-OUT;n:type:ShaderForge.SFN_Vector1,id:5368,x:31836,y:34505,varname:node_5368,prsc:2,v1:-2.01;n:type:ShaderForge.SFN_ValueProperty,id:7444,x:33295,y:33027,ptovrint:False,ptlb:Glow,ptin:_Glow,varname:node_7444,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5852,x:33567,y:32797,varname:node_5852,prsc:2|A-2491-OUT,B-7444-OUT;proporder:7444-3990-5084-9574-4099-1635-2887-9024-1338;pass:END;sub:END;*/

Shader "Particle/XC/CJ_Run_Dissolve_Blend" {
    Properties {
        _Glow ("Glow", Float ) = 1
        _MainTex ("MainTex", 2D) = "white" {}
        [HDR]_TintColor ("TintColor", Color) = (0.5058316,0.1294334,0.8382353,1)
        [HDR]_Edge_Color ("Edge_Color", Color) = (1,0,0,1)
        _Mask_1 ("Mask_1", 2D) = "white" {}
        _Ruanying ("Ruanying", Range(0.5, 1)) = 0.598817
        _Rongjie_Tex ("Rongjie_Tex", 2D) = "white" {}
        _Edge_Width ("Edge_Width", Range(0, -1)) = 0
        _Rongjie ("Rongjie", Range(0, 2)) = 0.2796224
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _TintColor;
            uniform float4 _Edge_Color;
            uniform sampler2D _Mask_1; uniform float4 _Mask_1_ST;
            uniform float _Ruanying;
            uniform sampler2D _Rongjie_Tex; uniform float4 _Rongjie_Tex_ST;
            uniform float _Edge_Width;
            uniform float _Rongjie;
            uniform float _Glow;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
////// Lighting:
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float node_6220 = (1.0 - _Ruanying);
                float4 _Rongjie_Tex_var = tex2D(_Rongjie_Tex,TRANSFORM_TEX(i.uv0, _Rongjie_Tex));
                float node_5627 = (_Rongjie_Tex_var.r+1.0);
                float node_1195 = ((2.0*(1.0 - i.vertexColor.a))+_Rongjie);
                float node_5368 = (-2.01);
                float3 emissive = (lerp((_MainTex_var.rgb*_Edge_Color.rgb),(_MainTex_var.rgb*_TintColor.rgb*i.vertexColor.rgb),smoothstep( node_6220, _Ruanying, saturate((node_5627+(node_1195*node_5368))) ))*_Glow);
                float3 finalColor = emissive;
                float4 _Mask_1_var = tex2D(_Mask_1,TRANSFORM_TEX(i.uv0, _Mask_1));
                fixed4 finalRGBA = fixed4(finalColor,(_MainTex_var.a*_Edge_Color.a*_Mask_1_var.r*smoothstep( node_6220, _Ruanying, saturate((node_5627+(saturate((_Edge_Width+node_1195))*node_5368))) )));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
