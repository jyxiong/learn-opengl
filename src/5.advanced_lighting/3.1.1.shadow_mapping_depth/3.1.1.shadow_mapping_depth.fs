#version 330 core

//in vec2 TexCoords;
//
//uniform sampler2D diffuseMap;
//uniform float transparentFactor;

float bayerDither2(vec2 _P) {
    return mod(2.0 * _P.y + _P.x + 1.0, 4.0);
}

float bayerDither4(vec2 _P) {
    vec2 P1 = mod(_P, 2.0);
    vec2 P2 = floor(0.5 * mod(_P, 4.0));
    return 4.0 * bayerDither2(P1) + bayerDither2(P2);
}

float bayerDither8(vec2 _P) {
    vec2 P1 = mod(_P, 2.0);
    vec2 P2 = floor(0.5  * mod(_P, 4.0));
    vec2 P4 = floor(0.25 * mod(_P, 8.0));
    return 4.0 * (4.0 * bayerDither2(P1) + bayerDither2(P2)) + bayerDither2(P4);
}

void main()
{
//    float alpha = texture2D(diffuseMap, vTexcoord).a;
//    if ((bayerDither8(floor(mod(gl_FragCoord.xy, 8.0)))) / 64.0 >= transparentFactor * alpha)
//        discard;
    // gl_FragDepth = gl_FragCoord.z;
}