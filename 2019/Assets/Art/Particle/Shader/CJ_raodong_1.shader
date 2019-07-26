// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:32719,y:32693,varname:node_4795,prsc:2|emission-9306-OUT,alpha-5153-OUT;n:type:ShaderForge.SFN_Clamp01,id:5153,x:32416,y:33036,varname:node_5153,prsc:2|IN-4273-OUT;n:type:ShaderForge.SFN_Vector1,id:7232,x:31982,y:32982,varname:node_7232,prsc:2,v1:0;n:type:ShaderForge.SFN_Smoothstep,id:4273,x:32168,y:33058,varname:node_4273,prsc:2|A-7232-OUT,B-7395-OUT,V-569-OUT;n:type:ShaderForge.SFN_Subtract,id:569,x:31674,y:32970,varname:node_569,prsc:2|A-2347-A,B-231-OUT;n:type:ShaderForge.SFN_Slider,id:7395,x:31701,y:33176,ptovrint:False,ptlb:Smoothness,ptin:_Smoothness,varname:node_7185,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:2347,x:31181,y:32513,ptovrint:False,ptlb:node_7482,ptin:_node_7482,varname:node_7482,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-7350-OUT;n:type:ShaderForge.SFN_VertexColor,id:3220,x:31153,y:32832,varname:node_3220,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:231,x:31357,y:32933,varname:node_231,prsc:2|IN-3220-A;n:type:ShaderForge.SFN_Multiply,id:9306,x:31989,y:32524,varname:node_9306,prsc:2|A-9964-OUT,B-4757-RGB,C-3220-RGB,D-1465-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1465,x:31735,y:32679,ptovrint:False,ptlb:ColorMultiply,ptin:_ColorMultiply,varname:node_6234,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Color,id:4757,x:31685,y:32274,ptovrint:False,ptlb:Color_copy,ptin:_Color_copy,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:9964,x:31588,y:32473,ptovrint:False,ptlb:node_4352,ptin:_node_4352,varname:node_4352,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2347-RGB,B-9251-OUT;n:type:ShaderForge.SFN_Vector1,id:9251,x:31414,y:32548,varname:node_9251,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:7350,x:30813,y:32555,varname:node_7350,prsc:2|A-4761-OUT,B-194-UVOUT,T-3254-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4761,x:30504,y:32566,varname:node_4761,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6262-RGB;n:type:ShaderForge.SFN_Tex2d,id:6262,x:30019,y:32479,ptovrint:False,ptlb:FlowMap,ptin:_FlowMap,varname:node_978,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3254,x:30628,y:32883,varname:node_3254,prsc:2|IN-9905-A,IMIN-1055-OUT,IMAX-9294-OUT,OMIN-1868-OUT,OMAX-2594-OUT;n:type:ShaderForge.SFN_VertexColor,id:9905,x:30283,y:32794,varname:node_9905,prsc:2;n:type:ShaderForge.SFN_Vector1,id:1055,x:30267,y:32971,varname:node_1055,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9294,x:30253,y:33050,varname:node_9294,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:1868,x:30224,y:33144,ptovrint:False,ptlb:MinDist,ptin:_MinDist,varname:node_2466,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_ValueProperty,id:2594,x:30456,y:33144,ptovrint:False,ptlb:MaxDist,ptin:_MaxDist,varname:node_5064,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_TexCoord,id:194,x:30481,y:32259,varname:node_194,prsc:2,uv:2,uaff:False;proporder:7395-2347-6262-1868-2594-1465-4757-9964;pass:END;sub:END;*/

Shader "Particle/XC/CJ_raodong_1" {
    Properties {
        _Smoothness ("Smoothness", Range(0, 1)) = 1
        _node_7482 ("node_7482", 2D) = "white" {}
        _FlowMap ("FlowMap", 2D) = "white" {}
        _MinDist ("MinDist", Float ) = 0
        _MaxDist ("MaxDist", Float ) = 1
        _ColorMultiply ("ColorMultiply", Float ) = 1
        _Color_copy ("Color_copy", Color) = (1,1,1,1)
        [MaterialToggle] _node_4352 ("node_4352", Float ) = 0
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
            uniform float _Smoothness;
            uniform sampler2D _node_7482; uniform float4 _node_7482_ST;
            uniform float _ColorMultiply;
            uniform float4 _Color_copy;
            uniform fixed _node_4352;
            uniform sampler2D _FlowMap; uniform float4 _FlowMap_ST;
            uniform float _MinDist;
            uniform float _MaxDist;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord2 : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv2 : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv2 = v.texcoord2;
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
                float4 _FlowMap_var = tex2D(_FlowMap,TRANSFORM_TEX(i.uv0, _FlowMap));
                float node_1055 = 0.0;
                float2 node_7350 = lerp(_FlowMap_var.rgb.rg,i.uv2,(_MinDist + ( (i.vertexColor.a - node_1055) * (_MaxDist - _MinDist) ) / (1.0 - node_1055)));
                float4 _node_7482_var = tex2D(_node_7482,TRANSFORM_TEX(node_7350, _node_7482));
                float3 emissive = (lerp( _node_7482_var.rgb, 1.0, _node_4352 )*_Color_copy.rgb*i.vertexColor.rgb*_ColorMultiply);
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,saturate(smoothstep( 0.0, _Smoothness, (_node_7482_var.a-(1.0 - i.vertexColor.a)) )));
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0,0,0,1));
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
