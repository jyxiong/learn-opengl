#version 330 core

in vec2 TexCoords;

uniform sampler2D diffuseTexture;

float bayerDither2x2(vec2 v) {
    return mod(3.0 * v.y + 2.0 * v.x, 4.0);
}
float bayerDither4x4(vec2 v) {
    vec2 P1 = mod(v, 2.0);
    vec2 P2 = floor(0.5 * mod(v, 4.0));
    return 4.0 * bayerDither2x2(P1) + bayerDither2x2(P2);
}
float bayerDither8x8(vec2 v) {
    vec2 P1 = mod(v, 2.0);
    vec2 P2 = floor(0.5 * mod(v, 4.0));
    vec2 P4 = floor(0.25 * mod(v, 8.0));
    return 4.0 * (4.0 * bayerDither2x2(P1) + bayerDither2x2(P2)) + bayerDither2x2(P4);
}

void main()
{
    float alpha = texture(diffuseTexture, TexCoords).a;
    if ((bayerDither8x8(floor(mod(gl_FragCoord.xy, 8.0)))) / 64.0 >= alpha)
        discard;
//    if (TexCoords.x > 0.5)
//        discard;
    // gl_FragDepth = gl_FragCoord.z;
}