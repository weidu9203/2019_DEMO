// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:2,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:33744,y:32721,varname:node_4013,prsc:2|emission-2253-RGB,clip-4542-OUT;n:type:ShaderForge.SFN_Tex2d,id:3557,x:32657,y:32929,varname:node_3557,prsc:2,tex:10bf6570d94e9f2409f66c39e54fb5fa,ntxv:0,isnm:False|TEX-9109-TEX;n:type:ShaderForge.SFN_OneMinus,id:828,x:32970,y:32935,varname:node_828,prsc:2|IN-3557-R;n:type:ShaderForge.SFN_Multiply,id:4542,x:33459,y:33018,varname:node_4542,prsc:2|A-828-OUT,B-9263-OUT,C-5914-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:9109,x:32248,y:32967,ptovrint:False,ptlb:mask,ptin:_mask,varname:node_9109,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:10bf6570d94e9f2409f66c39e54fb5fa,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8810,x:32714,y:33277,varname:node_8810,prsc:2,tex:10bf6570d94e9f2409f66c39e54fb5fa,ntxv:0,isnm:False|UVIN-8769-OUT,TEX-9109-TEX;n:type:ShaderForge.SFN_TexCoord,id:5824,x:32039,y:33299,varname:node_5824,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_OneMinus,id:9263,x:32970,y:33122,varname:node_9263,prsc:2|IN-8810-R;n:type:ShaderForge.SFN_Append,id:8769,x:32483,y:33392,varname:node_8769,prsc:2|A-1228-OUT,B-5824-V;n:type:ShaderForge.SFN_Add,id:1228,x:32328,y:33458,varname:node_1228,prsc:2|A-5824-U,B-6486-OUT;n:type:ShaderForge.SFN_Slider,id:4835,x:31568,y:33683,ptovrint:False,ptlb:move,ptin:_move,varname:node_4835,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_OneMinus,id:6486,x:32053,y:33564,varname:node_6486,prsc:2|IN-4835-OUT;n:type:ShaderForge.SFN_Tex2d,id:1307,x:32800,y:33531,ptovrint:False,ptlb:rongjie_tex,ptin:_rongjie_tex,varname:node_1307,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:10bf6570d94e9f2409f66c39e54fb5fa,ntxv:0,isnm:False|UVIN-8769-OUT;n:type:ShaderForge.SFN_Add,id:5914,x:33245,y:33406,varname:node_5914,prsc:2|A-1307-R,B-2462-OUT;n:type:ShaderForge.SFN_Slider,id:2627,x:32518,y:33798,ptovrint:False,ptlb:rongjie,ptin:_rongjie,varname:node_2627,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:2462,x:33057,y:33603,varname:node_2462,prsc:2,frmn:0,frmx:1,tomn:1,tomx:-1|IN-2627-OUT;n:type:ShaderForge.SFN_Color,id:2253,x:33064,y:32598,ptovrint:False,ptlb:color,ptin:_color,varname:node_2253,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Time,id:4271,x:30771,y:32668,varname:node_4271,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2991,x:31021,y:32590,varname:node_2991,prsc:2|A-3545-OUT,B-4271-T;n:type:ShaderForge.SFN_Multiply,id:9299,x:31032,y:32761,varname:node_9299,prsc:2|A-4700-OUT,B-4271-T;n:type:ShaderForge.SFN_Append,id:8111,x:31200,y:32662,varname:node_8111,prsc:2|A-2991-OUT,B-9299-OUT;n:type:ShaderForge.SFN_ValueProperty,id:4700,x:30786,y:32901,ptovrint:False,ptlb:V_copy,ptin:_V_copy,varname:_V_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:3545,x:30771,y:32554,ptovrint:False,ptlb:U_copy,ptin:_U_copy,varname:_U_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Time,id:9969,x:30835,y:32732,varname:node_9969,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2924,x:31085,y:32654,varname:node_2924,prsc:2|A-6816-OUT,B-9969-T;n:type:ShaderForge.SFN_Multiply,id:4352,x:31096,y:32825,varname:node_4352,prsc:2|A-5658-OUT,B-9969-T;n:type:ShaderForge.SFN_Append,id:5162,x:31264,y:32726,varname:node_5162,prsc:2|A-2924-OUT,B-4352-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5658,x:30850,y:32965,ptovrint:False,ptlb:V_copy_copy,ptin:_V_copy_copy,varname:_V_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:6816,x:30835,y:32618,ptovrint:False,ptlb:U_copy_copy,ptin:_U_copy_copy,varname:_U_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:9109-4835-1307-2627-2253;pass:END;sub:END;*/

Shader "Particle/XC/CJ_Dissolve_Blend" {
    Properties {
        _mask ("mask", 2D) = "white" {}
        _move ("move", Range(0, 1)) = 0
        _rongjie_tex ("rongjie_tex", 2D) = "white" {}
        _rongjie ("rongjie", Range(0, 1)) = 1
        _color ("color", Color) = (0.5,0.5,0.5,1)
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One OneMinusSrcAlpha
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float _move;
            uniform sampler2D _rongjie_tex; uniform float4 _rongjie_tex_ST;
            uniform float _rongjie;
            uniform float4 _color;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_3557 = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float2 node_8769 = float2((i.uv0.r+(1.0 - _move)),i.uv0.g);
                float4 node_8810 = tex2D(_mask,TRANSFORM_TEX(node_8769, _mask));
                float4 _rongjie_tex_var = tex2D(_rongjie_tex,TRANSFORM_TEX(node_8769, _rongjie_tex));
                clip(((1.0 - node_3557.r)*(1.0 - node_8810.r)*(_rongjie_tex_var.r+(_rongjie*-2.0+1.0))) - 0.5);
////// Lighting:
////// Emissive:
                float3 emissive = _color.rgb;
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            uniform sampler2D _mask; uniform float4 _mask_ST;
            uniform float _move;
            uniform sampler2D _rongjie_tex; uniform float4 _rongjie_tex_ST;
            uniform float _rongjie;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 node_3557 = tex2D(_mask,TRANSFORM_TEX(i.uv0, _mask));
                float2 node_8769 = float2((i.uv0.r+(1.0 - _move)),i.uv0.g);
                float4 node_8810 = tex2D(_mask,TRANSFORM_TEX(node_8769, _mask));
                float4 _rongjie_tex_var = tex2D(_rongjie_tex,TRANSFORM_TEX(node_8769, _rongjie_tex));
                clip(((1.0 - node_3557.r)*(1.0 - node_8810.r)*(_rongjie_tex_var.r+(_rongjie*-2.0+1.0))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
