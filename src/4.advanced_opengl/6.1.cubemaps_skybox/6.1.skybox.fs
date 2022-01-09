#version 330 core

in vec3 TexCoords;

out vec4 FragColor;

uniform samplerCube skyboxTexture;
uniform float exposure;

void main()
{
    const float gamma = 2.2;
    vec3 hdrColor = texture(skyboxTexture, TexCoords).rgb;
    
    // 曝光色调映射
    vec3 mapped = vec3(1.0) - exp(-hdrColor * exposure);
    // Gamma校正
    mapped = pow(mapped, vec3(1.0 / gamma));
    
    FragColor = vec4(mapped, 1.0f);
}
